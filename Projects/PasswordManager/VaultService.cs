using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    /// <summary>
    /// Manages vault operations including CRUD operations for credentials
    /// </summary>
    public class VaultService
    {
        private readonly CryptographyService _cryptoService;
        private readonly FileService _fileService;
        private List<Credential> _credentials;
        private bool _isLoaded;

        public VaultService(CryptographyService cryptoService, FileService fileService)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _credentials = new List<Credential>();
            _isLoaded = false;
        }

        /// <summary>
        /// Gets the count of credentials in the vault
        /// </summary>
        public int Count => _credentials.Count;

        /// <summary>
        /// Indicates if the vault has been loaded
        /// </summary>
        public bool IsLoaded => _isLoaded;

        /// <summary>
        /// Loads the vault from disk and decrypts it
        /// </summary>
        public async Task LoadVaultAsync(string masterPassword)
        {
            if (string.IsNullOrEmpty(masterPassword))
                throw new ArgumentException("Master password cannot be null or empty", nameof(masterPassword));

            try
            {
                string encryptedData = await _fileService.LoadVaultAsync();

                if (string.IsNullOrEmpty(encryptedData))
                {
                    // New vault - initialize empty
                    _credentials = new List<Credential>();
                }
                else
                {
                    // Decrypt and deserialize existing vault
                    string jsonData = _cryptoService.DecryptData(encryptedData, masterPassword);
                    _credentials = JsonSerializer.Deserialize<List<Credential>>(jsonData) ?? new List<Credential>();
                }

                _isLoaded = true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load vault: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Saves the vault to disk with encryption
        /// </summary>
        public async Task SaveVaultAsync(string masterPassword)
        {
            if (string.IsNullOrEmpty(masterPassword))
                throw new ArgumentException("Master password cannot be null or empty", nameof(masterPassword));

            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before saving");

            try
            {
                // Serialize credentials to JSON
                string jsonData = JsonSerializer.Serialize(_credentials, new JsonSerializerOptions
                {
                    WriteIndented = false
                });

                // Encrypt the JSON data
                string encryptedData = _cryptoService.EncryptData(jsonData, masterPassword);

                // Save to file
                await _fileService.SaveVaultAsync(encryptedData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to save vault: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds a new credential to the vault
        /// </summary>
        public async Task<string> AddCredentialAsync(string site, string username, string password, string notes, string masterPassword)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before adding credentials");

            var credential = new Credential(site, username, password, notes);

            if (!credential.IsValid(out string errorMessage))
                throw new ArgumentException($"Invalid credential: {errorMessage}");

            // Check for duplicate site/username combination
            if (_credentials.Any(c => c.Site.Equals(site, StringComparison.OrdinalIgnoreCase) &&
                                     c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A credential with the same site and username already exists");
            }

            _credentials.Add(credential);
            await SaveVaultAsync(masterPassword);

            return credential.Id;
        }

        /// <summary>
        /// Updates an existing credential
        /// </summary>
        public async Task UpdateCredentialAsync(string id, string site, string username, string password, string notes, string masterPassword)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before updating credentials");

            var credential = _credentials.FirstOrDefault(c => c.Id == id);
            if (credential == null)
                throw new ArgumentException("Credential not found", nameof(id));

            // Check for duplicate site/username combination (excluding current credential)
            if (_credentials.Any(c => c.Id != id &&
                                     c.Site.Equals(site, StringComparison.OrdinalIgnoreCase) &&
                                     c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A credential with the same site and username already exists");
            }

            credential.Update(site, username, password, notes);

            if (!credential.IsValid(out string errorMessage))
                throw new ArgumentException($"Invalid credential: {errorMessage}");

            await SaveVaultAsync(masterPassword);
        }

        /// <summary>
        /// Deletes a credential from the vault
        /// </summary>
        public async Task<bool> DeleteCredentialAsync(string id, string masterPassword)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before deleting credentials");

            var credential = _credentials.FirstOrDefault(c => c.Id == id);
            if (credential == null)
                return false;

            _credentials.Remove(credential);
            await SaveVaultAsync(masterPassword);

            return true;
        }

        /// <summary>
        /// Gets all credentials (returns copies for security)
        /// </summary>
        public List<Credential> GetAllCredentials()
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before accessing credentials");

            // Return copies to prevent external modification
            return _credentials.Select(c => new Credential(c.Site, c.Username, c.Password, c.Notes)
            {
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate
            }).ToList();
        }

        /// <summary>
        /// Gets a specific credential by ID
        /// </summary>
        public Credential GetCredential(string id)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before accessing credentials");

            var credential = _credentials.FirstOrDefault(c => c.Id == id);
            if (credential == null)
                return null;

            // Return a copy for security
            return new Credential(credential.Site, credential.Username, credential.Password, credential.Notes)
            {
                Id = credential.Id,
                CreatedDate = credential.CreatedDate,
                ModifiedDate = credential.ModifiedDate
            };
        }

        /// <summary>
        /// Searches credentials by site name (case-insensitive)
        /// </summary>
        public List<Credential> SearchCredentials(string searchTerm)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before searching credentials");

            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllCredentials();

            return _credentials
                .Where(c => c.Site.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                           c.Username.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                           (!string.IsNullOrEmpty(c.Notes) && c.Notes.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .Select(c => new Credential(c.Site, c.Username, c.Password, c.Notes)
                {
                    Id = c.Id,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToList();
        }

        /// <summary>
        /// Exports vault data to CSV format
        /// </summary>
        public async Task<string> ExportToCsvAsync(bool includePasswords = false)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before exporting");

            var csv = new System.Text.StringBuilder();

            // Add header
            if (includePasswords)
                csv.AppendLine("Site,Username,Password,Notes,Created,Modified");
            else
                csv.AppendLine("Site,Username,Notes,Created,Modified");

            // Add credentials
            foreach (var credential in _credentials.OrderBy(c => c.Site))
            {
                string site = EscapeCsvField(credential.Site);
                string username = EscapeCsvField(credential.Username);
                string notes = EscapeCsvField(credential.Notes ?? "");
                string created = credential.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                string modified = credential.ModifiedDate.ToString("yyyy-MM-dd HH:mm:ss");

                if (includePasswords)
                {
                    string password = EscapeCsvField(credential.Password);
                    csv.AppendLine($"{site},{username},{password},{notes},{created},{modified}");
                }
                else
                {
                    csv.AppendLine($"{site},{username},{notes},{created},{modified}");
                }
            }

            return csv.ToString();
        }

        /// <summary>
        /// Exports encrypted vault data
        /// </summary>
        public async Task<string> ExportEncryptedVaultAsync(string masterPassword)
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before exporting");

            // This returns the raw encrypted data for backup purposes
            string jsonData = JsonSerializer.Serialize(_credentials, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return _cryptoService.EncryptData(jsonData, masterPassword);
        }

        /// <summary>
        /// Gets vault statistics
        /// </summary>
        public VaultStatistics GetStatistics()
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before getting statistics");

            var stats = new VaultStatistics
            {
                TotalCredentials = _credentials.Count,
                UniqueWebsites = _credentials.Select(c => c.Site.ToLowerInvariant()).Distinct().Count(),
                OldestCredential = _credentials.Count > 0 ? _credentials.Min(c => c.CreatedDate) : (DateTime?)null,
                NewestCredential = _credentials.Count > 0 ? _credentials.Max(c => c.CreatedDate) : (DateTime?)null,
                LastModified = _credentials.Count > 0 ? _credentials.Max(c => c.ModifiedDate) : (DateTime?)null
            };

            // Calculate password strength distribution
            foreach (var credential in _credentials)
            {
                var strength = CalculatePasswordStrength(credential.Password);
                switch (strength)
                {
                    case PasswordStrength.Weak:
                        stats.WeakPasswords++;
                        break;
                    case PasswordStrength.Medium:
                        stats.MediumPasswords++;
                        break;
                    case PasswordStrength.Strong:
                        stats.StrongPasswords++;
                        break;
                }
            }

            return stats;
        }

        /// <summary>
        /// Validates vault integrity
        /// </summary>
        public List<string> ValidateVault()
        {
            if (!_isLoaded)
                throw new InvalidOperationException("Vault must be loaded before validation");

            var issues = new List<string>();

            // Check for duplicate credentials
            var duplicates = _credentials
                .GroupBy(c => new { Site = c.Site.ToLowerInvariant(), Username = c.Username.ToLowerInvariant() })
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var duplicate in duplicates)
            {
                issues.Add($"Duplicate credential found: {duplicate.Site} - {duplicate.Username}");
            }

            // Check for invalid data
            foreach (var credential in _credentials)
            {
                if (!credential.IsValid(out string error))
                {
                    issues.Add($"Invalid credential {credential.Site}: {error}");
                }
            }

            return issues;
        }

        /// <summary>
        /// Escapes a field for CSV format
        /// </summary>
        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "";

            // If field contains comma, quote, or newline, wrap in quotes and escape quotes
            if (field.Contains(',') || field.Contains('"') || field.Contains('\n') || field.Contains('\r'))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }

        /// <summary>
        /// Calculates password strength
        /// </summary>
        private PasswordStrength CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return PasswordStrength.Weak;

            int score = 0;

            // Length scoring
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            // Character variety scoring
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(c => !char.IsLetterOrDigit(c))) score++;

            return score switch
            {
                >= 6 => PasswordStrength.Strong,
                >= 4 => PasswordStrength.Medium,
                _ => PasswordStrength.Weak
            };
        }
    }

    /// <summary>
    /// Vault statistics information
    /// </summary>
    public class VaultStatistics
    {
        public int TotalCredentials { get; set; }
        public int UniqueWebsites { get; set; }
        public int WeakPasswords { get; set; }
        public int MediumPasswords { get; set; }
        public int StrongPasswords { get; set; }
        public DateTime? OldestCredential { get; set; }
        public DateTime? NewestCredential { get; set; }
        public DateTime? LastModified { get; set; }
    }

    /// <summary>
    /// Password strength enumeration
    /// </summary>
    public enum PasswordStrength
    {
        Weak,
        Medium,
        Strong
    }
}