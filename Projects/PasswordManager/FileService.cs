using System;
using System.IO;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class FileService
    {
        private readonly string _dataDirectory;
        private readonly string _masterHashFile;
        private readonly string _vaultFile;

        public FileService()
        {
            // Create data directory in user's local app data
            _dataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PasswordManager");

            _masterHashFile = Path.Combine(_dataDirectory, "master.hash");
            _vaultFile = Path.Combine(_dataDirectory, "vault.enc");

            EnsureDataDirectoryExists();
        }

        // Gets the path to the master hash file
        public string MasterHashFile => _masterHashFile;

        // Gets the path to the encrypted vault file
        public string VaultFile => _vaultFile;

        // Checks if the master hash file exists
        public bool MasterHashExists() => File.Exists(_masterHashFile);

        // Checks if the vault file exists
        public bool VaultExists() => File.Exists(_vaultFile);

        // Saves the master password hash and salt to file
        public async Task SaveMasterHashAsync(string hash, string salt)
        {
            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(salt))
                throw new ArgumentException("Hash and salt cannot be null or empty");

            const int maxRetries = 3;
            int retryCount = 0;
            Exception lastException = null;

            while (retryCount < maxRetries)
            {
                try
                {
                    // Format: hash|salt
                    string content = $"{hash}|{salt}";

                    // Remove hidden attribute if file exists
                    if (File.Exists(_masterHashFile))
                    {
                        try
                        {
                            FileAttributes attributes = File.GetAttributes(_masterHashFile);
                            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                            {
                                File.SetAttributes(_masterHashFile, attributes & ~FileAttributes.Hidden);
                                await Task.Delay(50);
                            }
                        }
                        catch
                        {
                            // Continue anyway
                        }
                    }

                    // Write to a temporary file first
                    string tempFile = _masterHashFile + ".tmp";

                    // Delete temp file if it exists
                    if (File.Exists(tempFile))
                    {
                        try
                        {
                            File.Delete(tempFile);
                            await Task.Delay(50);
                        }
                        catch
                        {
                            // Continue anyway
                        }
                    }

                    // Write to temp file
                    await File.WriteAllTextAsync(tempFile, content);
                    await Task.Delay(100);

                    // Delete the old hash file if it exists
                    if (File.Exists(_masterHashFile))
                    {
                        File.Delete(_masterHashFile);
                        await Task.Delay(100);
                    }

                    // Rename temp file to actual hash file
                    File.Move(tempFile, _masterHashFile);
                    await Task.Delay(50);

                    // Set file attributes to make it less visible to casual browsing
                    try
                    {
                        File.SetAttributes(_masterHashFile, FileAttributes.Hidden);
                    }
                    catch
                    {
                        // Ignore if we can't set hidden attribute
                    }

                    // Success - exit the retry loop
                    return;
                }
                catch (IOException ex) when (retryCount < maxRetries - 1)
                {
                    // File access error - retry
                    lastException = ex;
                    retryCount++;
                    await Task.Delay(200 * retryCount);
                }
                catch (UnauthorizedAccessException ex) when (retryCount < maxRetries - 1)
                {
                    // Permission error - retry
                    lastException = ex;
                    retryCount++;
                    await Task.Delay(200 * retryCount);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Failed to save master hash: {ex.Message}", ex);
                }
            }

            // If we get here, all retries failed
            throw new InvalidOperationException($"Failed to save master hash after {maxRetries} attempts: {lastException?.Message}", lastException);
        }

        // Loads the master password hash and salt from file
        public async Task<(string hash, string salt)> LoadMasterHashAsync()
        {
            if (!MasterHashExists())
                throw new FileNotFoundException("Master hash file not found");

            try
            {
                // Remove hidden attribute temporarily for reading
                FileAttributes attributes = FileAttributes.Normal;
                bool wasHidden = false;

                try
                {
                    attributes = File.GetAttributes(_masterHashFile);
                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        wasHidden = true;
                        File.SetAttributes(_masterHashFile, attributes & ~FileAttributes.Hidden);
                        await Task.Delay(50);
                    }
                }
                catch
                {
                    // Continue anyway
                }

                string content = await File.ReadAllTextAsync(_masterHashFile);
                string[] parts = content.Split('|');

                if (parts.Length != 2)
                    throw new InvalidOperationException("Invalid master hash file format");

                // Restore hidden attribute
                if (wasHidden)
                {
                    try
                    {
                        File.SetAttributes(_masterHashFile, attributes);
                    }
                    catch
                    {
                        // Ignore
                    }
                }

                return (parts[0], parts[1]);
            }
            catch (Exception ex) when (!(ex is FileNotFoundException))
            {
                throw new InvalidOperationException($"Failed to load master hash: {ex.Message}", ex);
            }
        }

        // Saves encrypted vault data to file
        public async Task SaveVaultAsync(string encryptedData)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new ArgumentException("Encrypted data cannot be null or empty", nameof(encryptedData));

            const int maxRetries = 3;
            int retryCount = 0;
            Exception lastException = null;

            while (retryCount < maxRetries)
            {
                try
                {
                    // Create backup of existing vault before overwriting
                    if (VaultExists())
                    {
                        await CreateBackupAsync();
                        // Wait to ensure backup is complete and handles released
                        await Task.Delay(150);
                    }

                    // Remove hidden attribute if file exists (prevents access denied on some systems)
                    if (File.Exists(_vaultFile))
                    {
                        try
                        {
                            FileAttributes attributes = File.GetAttributes(_vaultFile);
                            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                            {
                                File.SetAttributes(_vaultFile, attributes & ~FileAttributes.Hidden);
                                await Task.Delay(50);
                            }
                        }
                        catch
                        {
                            // Continue anyway
                        }
                    }

                    // Write to a temporary file first
                    string tempFile = _vaultFile + ".tmp";

                    // Delete temp file if it exists from a previous failed attempt
                    if (File.Exists(tempFile))
                    {
                        try
                        {
                            File.Delete(tempFile);
                            await Task.Delay(50);
                        }
                        catch
                        {
                            // Continue anyway
                        }
                    }

                    // Write to temp file
                    await using (var stream = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                    await using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(encryptedData);
                        await writer.FlushAsync();
                    }

                    // Wait to ensure file is closed
                    await Task.Delay(100);

                    // Delete the old vault file if it exists
                    if (File.Exists(_vaultFile))
                    {
                        File.Delete(_vaultFile);
                        await Task.Delay(100);
                    }

                    // Rename temp file to actual vault file
                    File.Move(tempFile, _vaultFile);
                    await Task.Delay(50);

                    // Set file attributes to make it less visible
                    try
                    {
                        File.SetAttributes(_vaultFile, FileAttributes.Hidden);
                    }
                    catch
                    {
                        // Ignore attribute setting failures - not critical
                    }

                    // Success - exit the retry loop
                    return;
                }
                catch (IOException ex) when (retryCount < maxRetries - 1)
                {
                    // File access error - retry
                    lastException = ex;
                    retryCount++;
                    await Task.Delay(200 * retryCount); // Exponential backoff
                }
                catch (UnauthorizedAccessException ex) when (retryCount < maxRetries - 1)
                {
                    // Permission error - retry
                    lastException = ex;
                    retryCount++;
                    await Task.Delay(200 * retryCount); // Exponential backoff
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Failed to save vault: {ex.Message}", ex);
                }
            }

            // If we get here, all retries failed
            throw new InvalidOperationException($"Failed to save vault after {maxRetries} attempts: {lastException?.Message}", lastException);
        }

        // Loads encrypted vault data from file
        public async Task<string> LoadVaultAsync()
        {
            if (!VaultExists())
                return string.Empty; // Return empty string for new vault

            try
            {
                // Remove hidden attribute temporarily for reading
                FileAttributes attributes = FileAttributes.Normal;
                bool wasHidden = false;

                try
                {
                    attributes = File.GetAttributes(_vaultFile);
                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        wasHidden = true;
                        File.SetAttributes(_vaultFile, attributes & ~FileAttributes.Hidden);
                        await Task.Delay(50);
                    }
                }
                catch
                {
                    // Continue anyway
                }

                string content = await File.ReadAllTextAsync(_vaultFile);

                // Restore hidden attribute
                if (wasHidden)
                {
                    try
                    {
                        File.SetAttributes(_vaultFile, attributes);
                    }
                    catch
                    {
                        // Ignore
                    }
                }

                return content;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load vault: {ex.Message}", ex);
            }
        }

        // Exports data to a file with proper error handling
        public async Task ExportToFileAsync(string filePath, string data)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));

            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Data cannot be null or empty", nameof(data));

            try
            {
                // Ensure the directory exists
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllTextAsync(filePath, data);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to export to file '{filePath}': {ex.Message}", ex);
            }
        }


        // Creates a backup of the current vault file
        public async Task CreateBackupAsync()
        {
            if (!VaultExists())
                return;

            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFile = Path.Combine(_dataDirectory, $"vault_backup_{timestamp}.enc");

                // Remove hidden attribute temporarily
                FileAttributes attributes = FileAttributes.Normal;
                bool wasHidden = false;

                try
                {
                    attributes = File.GetAttributes(_vaultFile);
                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        wasHidden = true;
                        File.SetAttributes(_vaultFile, attributes & ~FileAttributes.Hidden);
                        await Task.Delay(50);
                    }
                }
                catch
                {
                    // Continue anyway
                }

                // Use async file copy to avoid locking issues
                await using (var sourceStream = new FileStream(_vaultFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true))
                await using (var destStream = new FileStream(backupFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                {
                    await sourceStream.CopyToAsync(destStream);
                }

                // Restore hidden attribute on source
                if (wasHidden)
                {
                    try
                    {
                        File.SetAttributes(_vaultFile, attributes);
                    }
                    catch
                    {
                        // Ignore
                    }
                }

                // Keep only the last 5 backups to prevent disk space issues
                await CleanupOldBackupsAsync();
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Warning: Failed to create backup: {ex.Message}");
            }
        }

        // Removes old backup files, keeping only the most recent ones
        private async Task CleanupOldBackupsAsync()
        {
            try
            {
                const int maxBackups = 5;

                var backupFiles = Directory.GetFiles(_dataDirectory, "vault_backup_*.enc");
                if (backupFiles.Length <= maxBackups)
                    return;

                // Sort by creation time and delete oldest files
                Array.Sort(backupFiles, (x, y) => File.GetCreationTime(x).CompareTo(File.GetCreationTime(y)));

                int filesToDelete = backupFiles.Length - maxBackups;
                for (int i = 0; i < filesToDelete; i++)
                {
                    try
                    {
                        File.Delete(backupFiles[i]);
                    }
                    catch
                    {
                        // Continue deleting other files even if one fails
                    }
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Failed to cleanup old backups: {ex.Message}");
            }
        }

        // Gets information about the vault file
        public VaultInfo GetVaultInfo()
        {
            if (!VaultExists())
                return new VaultInfo { Exists = false };

            try
            {
                var fileInfo = new FileInfo(_vaultFile);
                return new VaultInfo
                {
                    Exists = true,
                    Size = fileInfo.Length,
                    CreatedDate = fileInfo.CreationTime,
                    ModifiedDate = fileInfo.LastWriteTime
                };
            }
            catch (Exception)
            {
                return new VaultInfo { Exists = false };
            }
        }

        // Validates that a file path is safe to write to
        public bool IsValidExportPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return false;

            try
            {
                // Check for invalid characters
                char[] invalidChars = Path.GetInvalidPathChars();
                if (filePath.IndexOfAny(invalidChars) >= 0)
                    return false;

                // Check if the directory is accessible
                string directory = Path.GetDirectoryName(Path.GetFullPath(filePath));
                return !string.IsNullOrEmpty(directory);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Ensures the data directory exists
        private void EnsureDataDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(_dataDirectory))
                {
                    Directory.CreateDirectory(_dataDirectory);

                    // Set directory attributes to make it less visible
                    try
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(_dataDirectory);
                        dirInfo.Attributes |= FileAttributes.Hidden;
                    }
                    catch
                    {
                        // Ignore if we can't set hidden attribute
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to create data directory: {ex.Message}", ex);
            }
        }
    }

    // Information about the vault file
    public class VaultInfo
    {
        public bool Exists { get; set; }
        public long Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string GetSizeString()
        {
            if (Size < 1024)
                return $"{Size} bytes";
            else if (Size < 1024 * 1024)
                return $"{Size / 1024.0:F1} KB";
            else
                return $"{Size / (1024.0 * 1024.0):F1} MB";
        }
    }
}