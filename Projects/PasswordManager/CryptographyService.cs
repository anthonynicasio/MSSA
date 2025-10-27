using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services
{
    // Provides cryptographic operations for password hashing and data encryption
    public class CryptographyService
    {
        private const int SaltSize = 32; // 256 bits
        private const int KeySize = 32;  // 256 bits for AES-256
        private const int IvSize = 16;   // 128 bits for AES block size
        private const int Iterations = 100000; // PBKDF2 iterations

        // Hashes a password with a random salt using PBKDF2
        public (string hash, string salt) HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            // Generate random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash password with salt using PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(KeySize);
                return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
            }
        }

        // Verifies a password against a stored hash and salt
        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(storedSalt))
                return false;

            try
            {
                byte[] salt = Convert.FromBase64String(storedSalt);
                byte[] hash = Convert.FromBase64String(storedHash);

                // Hash the provided password with the stored salt
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] testHash = pbkdf2.GetBytes(KeySize);

                    // Compare hashes using constant-time comparison to prevent timing attacks
                    return ConstantTimeEquals(hash, testHash);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Derives an encryption key from a password using PBKDF2
        public byte[] DeriveKey(string password, byte[] salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            if (salt == null || salt.Length != SaltSize)
                throw new ArgumentException($"Salt must be exactly {SaltSize} bytes", nameof(salt));

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(KeySize);
            }
        }

        // Encrypts data using AES-256-CBC
        public string EncryptData(string plaintext, string password)
        {
            if (string.IsNullOrEmpty(plaintext))
                throw new ArgumentException("Plaintext cannot be null or empty", nameof(plaintext));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            // Generate random salt and IV
            byte[] salt = new byte[SaltSize];
            byte[] iv = new byte[IvSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                rng.GetBytes(iv);
            }

            // Derive key from password
            byte[] key = DeriveKey(password, salt);

            // Encrypt the data
            byte[] encryptedData;
            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor())
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                    csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                    csEncrypt.FlushFinalBlock();
                    encryptedData = msEncrypt.ToArray();
                }
            }

            // Combine salt + IV + encrypted data
            byte[] result = new byte[SaltSize + IvSize + encryptedData.Length];
            Array.Copy(salt, 0, result, 0, SaltSize);
            Array.Copy(iv, 0, result, SaltSize, IvSize);
            Array.Copy(encryptedData, 0, result, SaltSize + IvSize, encryptedData.Length);

            // Clear sensitive data from memory
            Array.Clear(key, 0, key.Length);
            Array.Clear(encryptedData, 0, encryptedData.Length);

            return Convert.ToBase64String(result);
        }

        // Decrypts data using AES-256-CBC
        public string DecryptData(string encryptedData, string password)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new ArgumentException("Encrypted data cannot be null or empty", nameof(encryptedData));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            try
            {
                byte[] data = Convert.FromBase64String(encryptedData);

                if (data.Length < SaltSize + IvSize)
                    throw new ArgumentException("Invalid encrypted data format");

                // Extract salt, IV, and encrypted data
                byte[] salt = new byte[SaltSize];
                byte[] iv = new byte[IvSize];
                byte[] encrypted = new byte[data.Length - SaltSize - IvSize];

                Array.Copy(data, 0, salt, 0, SaltSize);
                Array.Copy(data, SaltSize, iv, 0, IvSize);
                Array.Copy(data, SaltSize + IvSize, encrypted, 0, encrypted.Length);

                // Derive key from password
                byte[] key = DeriveKey(password, salt);

                // Decrypt the data
                string plaintext;
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = key;
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor())
                    using (var msDecrypt = new MemoryStream(encrypted))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }

                // Clear sensitive data from memory
                Array.Clear(key, 0, key.Length);
                Array.Clear(encrypted, 0, encrypted.Length);

                return plaintext;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to decrypt data. Invalid password or corrupted data.", ex);
            }
        }

        // Securely generates a random password
        public string GenerateSecurePassword(int length = 16, bool includeSymbols = true)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 characters", nameof(length));

            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string chars = lowercase + uppercase + digits;
            if (includeSymbols)
                chars += symbols;

            var password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                // Ensure at least one character from each category
                password.Append(GetRandomChar(lowercase, rng));
                password.Append(GetRandomChar(uppercase, rng));
                password.Append(GetRandomChar(digits, rng));
                if (includeSymbols)
                    password.Append(GetRandomChar(symbols, rng));

                // Fill remaining length with random characters
                int remaining = length - password.Length;
                for (int i = 0; i < remaining; i++)
                {
                    password.Append(GetRandomChar(chars, rng));
                }

                // Shuffle the password to avoid predictable patterns
                return ShuffleString(password.ToString(), rng);
            }
        }

        private char GetRandomChar(string chars, RandomNumberGenerator rng)
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            uint randomValue = BitConverter.ToUInt32(randomBytes, 0);
            return chars[(int)(randomValue % chars.Length)];
        }

        private string ShuffleString(string input, RandomNumberGenerator rng)
        {
            char[] chars = input.ToCharArray();
            for (int i = chars.Length - 1; i > 0; i--)
            {
                byte[] randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                uint randomValue = BitConverter.ToUInt32(randomBytes, 0);
                int j = (int)(randomValue % (i + 1));

                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return new string(chars);
        }

        // Constant-time comparison to prevent timing attacks
        private bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}