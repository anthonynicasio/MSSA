using System;
using System.Linq;
using System.Threading.Tasks;
using PasswordManager.Models;
using PasswordManager.Services;
using PasswordManager.UI;
using PasswordManager.Utilities;

namespace PasswordManager.UI
{
    // Main menu service that orchestrates the user interface
    public class MenuService
    {
        private readonly CryptographyService _cryptoService;
        private readonly VaultService _vaultService;
        private readonly PasswordService _passwordService;
        private readonly FileService _fileService;
        private readonly InputService _inputService;

        private string _masterPassword;
        private bool _isAuthenticated;

        public MenuService(
            CryptographyService cryptoService,
            VaultService vaultService,
            PasswordService passwordService,
            FileService fileService,
            InputService inputService)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
            _vaultService = vaultService ?? throw new ArgumentNullException(nameof(vaultService));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        // Starts the main application loop
        public async Task RunAsync()
        {
            try
            {
                _inputService.DisplayHeader("🔐 Secure Password Manager", "Your passwords, secured and organized");

                // Initialize master password
                if (!await InitializeMasterPasswordAsync())
                    return;

                // Load vault
                await LoadVaultAsync();

                // Main menu loop
                await MainMenuLoopAsync();
            }
            catch (Exception ex)
            {
                _inputService.DisplayError($"Application error: {ex.Message}");
                _inputService.PressAnyKey();
            }
        }

        // Initializes or verifies master password
        private async Task<bool> InitializeMasterPasswordAsync()
        {
            if (!_fileService.MasterHashExists())
            {
                return await SetupNewMasterPasswordAsync();
            }
            else
            {
                return await VerifyMasterPasswordAsync();
            }
        }

        // Sets up a new master password for first-time users
        private async Task<bool> SetupNewMasterPasswordAsync()
        {
            _inputService.DisplayInfo("Welcome! Let's set up your master password.");
            Console.WriteLine("This password will encrypt all your stored credentials.");
            Console.WriteLine("Make sure it's strong and memorable - you cannot recover it if lost!");
            Console.WriteLine();

            while (true)
            {
                string password = _inputService.ReadPassword("Enter master password: ");

                if (string.IsNullOrWhiteSpace(password))
                {
                    _inputService.DisplayError("Master password cannot be empty.");
                    continue;
                }

                // Validate password strength
                var strengthResult = _passwordService.ValidatePasswordStrength(password);

                Console.WriteLine();
                var color = Console.ForegroundColor;
                Console.ForegroundColor = strengthResult.GetStrengthColor();
                Console.WriteLine($"Password Strength: {strengthResult.GetStrengthText()}");
                Console.ForegroundColor = color;

                if (strengthResult.Feedback.Length > 0)
                {
                    foreach (string feedback in strengthResult.Feedback)
                    {
                        Console.WriteLine($"  • {feedback}");
                    }
                    Console.WriteLine();
                }

                if (strengthResult.Strength == PasswordStrength.Weak)
                {
                    if (!_inputService.ReadConfirmation("Password is weak. Use anyway?", false))
                        continue;
                }

                string confirmPassword = _inputService.ReadPassword("Confirm master password: ");

                if (password != confirmPassword)
                {
                    _inputService.DisplayError("Passwords do not match. Please try again.");
                    continue;
                }

                try
                {
                    var (hash, salt) = _cryptoService.HashPassword(password);
                    await _fileService.SaveMasterHashAsync(hash, salt);
                    _masterPassword = password;
                    _isAuthenticated = true;

                    _inputService.DisplaySuccess("Master password set successfully!");
                    return true;
                }
                catch (Exception ex)
                {
                    _inputService.DisplayError($"Failed to save master password: {ex.Message}");
                    return false;
                }
            }
        }

        // Verifies the master password for returning users
        private async Task<bool> VerifyMasterPasswordAsync()
        {
            const int maxAttempts = 3;
            int attempts = 0;

            _inputService.DisplayInfo("Please enter your master password to continue.");

            while (attempts < maxAttempts)
            {
                string password = _inputService.ReadPassword("Master password: ");

                try
                {
                    var (storedHash, storedSalt) = await _fileService.LoadMasterHashAsync();

                    if (_cryptoService.VerifyPassword(password, storedHash, storedSalt))
                    {
                        _masterPassword = password;
                        _isAuthenticated = true;
                        _inputService.DisplaySuccess("Authentication successful!");
                        return true;
                    }
                    else
                    {
                        attempts++;
                        int remaining = maxAttempts - attempts;

                        if (remaining > 0)
                        {
                            _inputService.DisplayError($"Invalid password. {remaining} attempt(s) remaining.");
                        }
                        else
                        {
                            _inputService.DisplayError("Too many failed attempts. Access denied.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _inputService.DisplayError($"Authentication error: {ex.Message}");
                    return false;
                }
            }

            return false;
        }

        // Loads the encrypted vault
        private async Task LoadVaultAsync()
        {
            try
            {
                _inputService.DisplayInfo("Loading vault...");
                await _vaultService.LoadVaultAsync(_masterPassword);

                if (_vaultService.Count > 0)
                {
                    _inputService.DisplaySuccess($"Vault loaded successfully. {_vaultService.Count} credential(s) found.");
                }
                else
                {
                    _inputService.DisplayInfo("Empty vault loaded. Ready to add credentials.");
                }
            }
            catch (Exception ex)
            {
                _inputService.DisplayError($"Failed to load vault: {ex.Message}");
                throw;
            }
        }

        // Main menu loop
        private async Task MainMenuLoopAsync()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    _inputService.DisplayHeader($"Main Menu ({_vaultService.Count} credentials)");

                    string[] options = {
                        "View all credentials",
                        "Search credentials",
                        "Add new credential",
                        "Edit credential",
                        "Delete credential",
                        "Generate password",
                        "Export vault",
                        "Vault statistics",
                        "Change master password",
                        "Exit"
                    };

                    int choice = _inputService.ReadChoice("What would you like to do?", options, false);

                    switch (choice)
                    {
                        case 0: await ViewAllCredentialsAsync(); break;
                        case 1: await SearchCredentialsAsync(); break;
                        case 2: await AddCredentialAsync(); break;
                        case 3: await EditCredentialAsync(); break;
                        case 4: await DeleteCredentialAsync(); break;
                        case 5: await GeneratePasswordAsync(); break;
                        case 6: await ExportVaultAsync(); break;
                        case 7: await ShowVaultStatisticsAsync(); break;
                        case 8: await ChangeMasterPasswordAsync(); break;
                        case 9:
                            _inputService.DisplayInfo("Thank you for using Secure Password Manager!");
                            return;
                    }
                }
                catch (Exception ex)
                {
                    _inputService.DisplayError($"Operation failed: {ex.Message}");
                    _inputService.PressAnyKey();
                }
            }
        }

        // Displays all credentials in a formatted table
        private async Task ViewAllCredentialsAsync()
        {
            var credentials = _vaultService.GetAllCredentials();

            if (credentials.Count == 0)
            {
                _inputService.DisplayInfo("No credentials found. Add some first!");
                return;
            }

            _inputService.DisplayHeader("All Credentials");

            string[] headers = { "#", "Site", "Username", "Created", "Modified" };
            string[][] rows = new string[credentials.Count][];

            for (int i = 0; i < credentials.Count; i++)
            {
                var cred = credentials[i];
                rows[i] = new string[] {
                    (i + 1).ToString(),
                    cred.Site,
                    cred.Username,
                    cred.CreatedDate.ToString("yyyy-MM-dd"),
                    cred.ModifiedDate.ToString("yyyy-MM-dd")
                };
            }

            _inputService.DisplayTable(headers, rows);

            // Option to view details or copy password
            if (_inputService.ReadConfirmation("View details for a specific credential?", false))
            {
                await ViewCredentialDetailsAsync(credentials);
            }
        }

        // Shows detailed view of a selected credential
        private async Task ViewCredentialDetailsAsync(System.Collections.Generic.List<Credential> credentials = null)
        {
            credentials ??= _vaultService.GetAllCredentials();

            if (credentials.Count == 0)
            {
                _inputService.DisplayInfo("No credentials available.");
                return;
            }

            int index = _inputService.DisplaySelectionMenu("Select Credential",
                credentials.ToArray(),
                c => $"{c.Site} - {c.Username}");

            if (index == -1) return;

            var credential = credentials[index];

            _inputService.DisplayHeader("Credential Details");
            Console.WriteLine(credential.ToDetailedString());
            Console.WriteLine($"Password: {new string('*', credential.Password.Length)}");
            Console.WriteLine();

            string[] actions = { "Copy password to clipboard", "Show password", "Back to menu" };
            int action = _inputService.ReadChoice("What would you like to do?", actions);

            switch (action)
            {
                case 0:
                    await ClipboardService.CopyToClipboardAsync(credential.Password);
                    break;
                case 1:
                    Console.WriteLine($"Password: {credential.Password}");
                    _inputService.PressAnyKey("Password is visible. Press any key to continue...");
                    break;
            }
        }

        // Searches for credentials
        private async Task SearchCredentialsAsync()
        {
            string searchTerm = _inputService.ReadLine("Enter search term (site, username, or notes): ");

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                await ViewAllCredentialsAsync();
                return;
            }

            var results = _vaultService.SearchCredentials(searchTerm);

            if (results.Count == 0)
            {
                _inputService.DisplayInfo($"No credentials found matching '{searchTerm}'.");
                return;
            }

            _inputService.DisplayHeader($"Search Results for '{searchTerm}' ({results.Count} found)");

            string[] headers = { "#", "Site", "Username", "Match" };
            string[][] rows = new string[results.Count][];

            for (int i = 0; i < results.Count; i++)
            {
                var cred = results[i];
                string matchType = "";

                if (cred.Site.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    matchType = "Site";
                else if (cred.Username.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    matchType = "Username";
                else if (!string.IsNullOrEmpty(cred.Notes) && cred.Notes.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    matchType = "Notes";

                rows[i] = new string[] {
                    (i + 1).ToString(),
                    cred.Site,
                    cred.Username,
                    matchType
                };
            }

            _inputService.DisplayTable(headers, rows);

            if (_inputService.ReadConfirmation("View details for a specific result?", false))
            {
                await ViewCredentialDetailsAsync(results);
            }
        }

        // Adds a new credential
        private async Task AddCredentialAsync()
        {
            _inputService.DisplayHeader("Add New Credential");

            string site = _inputService.ReadLine("Site/Service name: ", true, 200);
            string username = _inputService.ReadLine("Username/Email: ", true, 100);

            // Password input with generation option
            string password;
            if (_inputService.ReadConfirmation("Generate a secure password?", true))
            {
                password = await GeneratePasswordInteractiveAsync();
            }
            else
            {
                password = _inputService.ReadPassword("Password: ");
                if (string.IsNullOrWhiteSpace(password))
                {
                    _inputService.DisplayError("Password cannot be empty.");
                    return;
                }

                // Show password strength
                var strength = _passwordService.ValidatePasswordStrength(password);
                var color = Console.ForegroundColor;
                Console.ForegroundColor = strength.GetStrengthColor();
                Console.WriteLine($"Password strength: {strength.GetStrengthText()}");
                Console.ForegroundColor = color;
            }

            string notes = _inputService.ReadLine("Notes (optional): ", false, 500);

            try
            {
                string id = await _vaultService.AddCredentialAsync(site, username, password, notes, _masterPassword);
                _inputService.DisplaySuccess($"Credential added successfully! ID: {id.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                _inputService.DisplayError(ex.Message);
            }
        }

        // Edits an existing credential
        private async Task EditCredentialAsync()
        {
            var credentials = _vaultService.GetAllCredentials();

            if (credentials.Count == 0)
            {
                _inputService.DisplayInfo("No credentials to edit.");
                return;
            }

            int index = _inputService.DisplaySelectionMenu("Select Credential to Edit",
                credentials.ToArray(),
                c => $"{c.Site} - {c.Username}");

            if (index == -1) return;

            var credential = credentials[index];

            _inputService.DisplayHeader($"Editing: {credential.Site}");

            string site = _inputService.ReadLine($"Site/Service name [{credential.Site}]: ");
            if (string.IsNullOrWhiteSpace(site)) site = credential.Site;

            string username = _inputService.ReadLine($"Username/Email [{credential.Username}]: ");
            if (string.IsNullOrWhiteSpace(username)) username = credential.Username;

            // Password handling
            string password = credential.Password;
            if (_inputService.ReadConfirmation("Change password?", false))
            {
                if (_inputService.ReadConfirmation("Generate a new password?", true))
                {
                    password = await GeneratePasswordInteractiveAsync();
                }
                else
                {
                    password = _inputService.ReadPassword("New password: ");
                    if (string.IsNullOrWhiteSpace(password))
                        password = credential.Password;
                }
            }

            string notes = _inputService.ReadLine($"Notes [{credential.Notes ?? "(none)"}]: ");
            if (string.IsNullOrWhiteSpace(notes) && !string.IsNullOrEmpty(credential.Notes))
                notes = credential.Notes;

            try
            {
                await _vaultService.UpdateCredentialAsync(credential.Id, site, username, password, notes, _masterPassword);
                _inputService.DisplaySuccess("Credential updated successfully!");
            }
            catch (Exception ex)
            {
                _inputService.DisplayError(ex.Message);
            }
        }

        // Deletes a credential
        private async Task DeleteCredentialAsync()
        {
            var credentials = _vaultService.GetAllCredentials();

            if (credentials.Count == 0)
            {
                _inputService.DisplayInfo("No credentials to delete.");
                return;
            }

            int index = _inputService.DisplaySelectionMenu("Select Credential to Delete",
                credentials.ToArray(),
                c => $"{c.Site} - {c.Username}");

            if (index == -1) return;

            var credential = credentials[index];

            _inputService.DisplayWarning($"You are about to delete: {credential.Site} - {credential.Username}");

            if (_inputService.ReadConfirmation("Are you absolutely sure?", false))
            {
                try
                {
                    bool deleted = await _vaultService.DeleteCredentialAsync(credential.Id, _masterPassword);
                    if (deleted)
                        _inputService.DisplaySuccess("Credential deleted successfully!");
                    else
                        _inputService.DisplayError("Failed to delete credential.");
                }
                catch (Exception ex)
                {
                    _inputService.DisplayError(ex.Message);
                }
            }
        }

        // Interactive password generation
        private async Task<string> GeneratePasswordInteractiveAsync()
        {
            var options = new PasswordGenerationOptions();

            // Get user preferences
            options.Length = _inputService.ReadInteger("Password length [16]: ", 4, 128);
            if (options.Length == 0) options.Length = 16;

            options.IncludeSymbols = _inputService.ReadConfirmation("Include symbols (!@#$%)?", true);

            // Generate multiple options
            string[] passwords = _passwordService.GeneratePasswordOptions(5, options);

            Console.WriteLine("\nGenerated password options:");
            for (int i = 0; i < passwords.Length; i++)
            {
                var strength = _passwordService.ValidatePasswordStrength(passwords[i]);
                var color = Console.ForegroundColor;
                Console.ForegroundColor = strength.GetStrengthColor();
                Console.WriteLine($"{i + 1}. {passwords[i]} ({strength.GetStrengthText()})");
                Console.ForegroundColor = color;
            }

            // Option to generate memorable password
            Console.WriteLine($"{passwords.Length + 1}. Generate memorable password");
            Console.WriteLine($"{passwords.Length + 2}. Generate new set");

            int choice = _inputService.ReadInteger("Select password: ", 1, passwords.Length + 2);

            if (choice <= passwords.Length)
            {
                return passwords[choice - 1];
            }
            else if (choice == passwords.Length + 1)
            {
                return _passwordService.GenerateMemorablePassword();
            }
            else
            {
                return await GeneratePasswordInteractiveAsync(); // Recursive call for new set
            }
        }

        // Standalone password generation
        private async Task GeneratePasswordAsync()
        {
            _inputService.DisplayHeader("Password Generator");

            string password = await GeneratePasswordInteractiveAsync();

            Console.WriteLine($"\nGenerated password: {password}");

            var strength = _passwordService.ValidatePasswordStrength(password);
            var color = Console.ForegroundColor;
            Console.ForegroundColor = strength.GetStrengthColor();
            Console.WriteLine($"Strength: {strength.GetStrengthText()}");
            Console.ForegroundColor = color;

            if (_inputService.ReadConfirmation("Copy to clipboard?", true))
            {
                await ClipboardService.CopyToClipboardAsync(password);
            }
        }

        // Exports vault data
        private async Task ExportVaultAsync()
        {
            _inputService.DisplayHeader("Export Vault");

            string[] exportOptions = {
                "Export to CSV (without passwords)",
                "Export to CSV (with passwords - INSECURE)",
                "Export encrypted backup",
                "Cancel"
            };

            int choice = _inputService.ReadChoice("Export format:", exportOptions);

            if (choice == 3) return;

            string defaultFileName = choice switch
            {
                0 => $"passwords_export_{DateTime.Now:yyyyMMdd}.csv",
                1 => $"passwords_full_export_{DateTime.Now:yyyyMMdd}.csv",
                2 => $"vault_backup_{DateTime.Now:yyyyMMdd}.enc",
                _ => "export.txt"
            };

            string filePath = _inputService.ReadLine($"Export file path [{defaultFileName}]: ");
            if (string.IsNullOrWhiteSpace(filePath))
                filePath = defaultFileName;

            try
            {
                string exportData = choice switch
                {
                    0 => await _vaultService.ExportToCsvAsync(false),
                    1 => await _vaultService.ExportToCsvAsync(true),
                    2 => await _vaultService.ExportEncryptedVaultAsync(_masterPassword),
                    _ => ""
                };

                await _fileService.ExportToFileAsync(filePath, exportData);
                _inputService.DisplaySuccess($"Vault exported to: {filePath}");

                if (choice == 1)
                {
                    _inputService.DisplayWarning("WARNING: Exported file contains unencrypted passwords!");
                    _inputService.DisplayWarning("Store it securely and delete when no longer needed.");
                }
            }
            catch (Exception ex)
            {
                _inputService.DisplayError($"Export failed: {ex.Message}");
            }
        }

        // Shows vault statistics
        private async Task ShowVaultStatisticsAsync()
        {
            _inputService.DisplayHeader("Vault Statistics");

            var stats = _vaultService.GetStatistics();
            var vaultInfo = _fileService.GetVaultInfo();

            Console.WriteLine($"Total Credentials: {stats.TotalCredentials}");
            Console.WriteLine($"Unique Websites: {stats.UniqueWebsites}");
            Console.WriteLine();

            Console.WriteLine("Password Strength Distribution:");
            Console.WriteLine($"  Strong:  {stats.StrongPasswords,3} ({(stats.TotalCredentials > 0 ? (double)stats.StrongPasswords / stats.TotalCredentials * 100 : 0):F1}%)");
            Console.WriteLine($"  Medium:  {stats.MediumPasswords,3} ({(stats.TotalCredentials > 0 ? (double)stats.MediumPasswords / stats.TotalCredentials * 100 : 0):F1}%)");
            Console.WriteLine($"  Weak:    {stats.WeakPasswords,3} ({(stats.TotalCredentials > 0 ? (double)stats.WeakPasswords / stats.TotalCredentials * 100 : 0):F1}%)");
            Console.WriteLine();

            if (stats.OldestCredential.HasValue)
                Console.WriteLine($"Oldest Credential: {stats.OldestCredential:yyyy-MM-dd}");

            if (stats.NewestCredential.HasValue)
                Console.WriteLine($"Newest Credential: {stats.NewestCredential:yyyy-MM-dd}");

            if (stats.LastModified.HasValue)
                Console.WriteLine($"Last Modified: {stats.LastModified:yyyy-MM-dd HH:mm:ss}");

            Console.WriteLine();
            Console.WriteLine($"Vault File Size: {vaultInfo.GetSizeString()}");

            if (vaultInfo.Exists)
            {
                Console.WriteLine($"Vault Created: {vaultInfo.CreatedDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Vault Modified: {vaultInfo.ModifiedDate:yyyy-MM-dd HH:mm:ss}");
            }

            // Validate vault integrity
            var issues = _vaultService.ValidateVault();
            if (issues.Count > 0)
            {
                Console.WriteLine();
                _inputService.DisplayWarning("Vault Issues Found:");
                foreach (string issue in issues)
                {
                    Console.WriteLine($"  • {issue}");
                }
            }
            else
            {
                Console.WriteLine();
                _inputService.DisplaySuccess("Vault integrity check passed!");
            }
        }

        // Changes the master password
        private async Task ChangeMasterPasswordAsync()
        {
            _inputService.DisplayHeader("Change Master Password");
            _inputService.DisplayWarning("This will re-encrypt your entire vault with a new password.");

            // Verify current password
            string currentPassword = _inputService.ReadPassword("Current master password: ");

            try
            {
                var (storedHash, storedSalt) = await _fileService.LoadMasterHashAsync();
                if (!_cryptoService.VerifyPassword(currentPassword, storedHash, storedSalt))
                {
                    _inputService.DisplayError("Current password is incorrect.");
                    return;
                }
            }
            catch (Exception ex)
            {
                _inputService.DisplayError($"Failed to verify current password: {ex.Message}");
                return;
            }

            // Get new password
            while (true)
            {
                string newPassword = _inputService.ReadPassword("New master password: ");

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    _inputService.DisplayError("New password cannot be empty.");
                    continue;
                }

                var strength = _passwordService.ValidatePasswordStrength(newPassword);
                Console.WriteLine();
                var color = Console.ForegroundColor;
                Console.ForegroundColor = strength.GetStrengthColor();
                Console.WriteLine($"Password Strength: {strength.GetStrengthText()}");
                Console.ForegroundColor = color;

                if (strength.Strength == PasswordStrength.Weak)
                {
                    if (!_inputService.ReadConfirmation("Password is weak. Use anyway?", false))
                        continue;
                }

                string confirmPassword = _inputService.ReadPassword("Confirm new password: ");

                if (newPassword != confirmPassword)
                {
                    _inputService.DisplayError("Passwords do not match.");
                    continue;
                }

                try
                {
                    // Save vault with new password
                    await _vaultService.SaveVaultAsync(newPassword);

                    // Update master password hash
                    var (newHash, newSalt) = _cryptoService.HashPassword(newPassword);
                    await _fileService.SaveMasterHashAsync(newHash, newSalt);

                    _masterPassword = newPassword;
                    _inputService.DisplaySuccess("Master password changed successfully!");
                    break;
                }
                catch (Exception ex)
                {
                    _inputService.DisplayError($"Failed to change master password: {ex.Message}");
                    break;
                }
            }
        }
    }
}