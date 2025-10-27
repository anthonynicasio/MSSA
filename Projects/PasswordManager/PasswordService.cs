using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordManager.Services
{
    // Provides password generation and strength validation services
    public class PasswordService
    {
        private readonly CryptographyService _cryptoService;

        public PasswordService(CryptographyService cryptoService)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
        }

        // Generates a secure password with specified options
        public string GeneratePassword(PasswordGenerationOptions options = null)
        {
            options ??= new PasswordGenerationOptions();

            if (options.Length < 4)
                throw new ArgumentException("Password length must be at least 4 characters");

            return _cryptoService.GenerateSecurePassword(options.Length, options.IncludeSymbols);
        }

        // Validates password strength and provides feedback
        public PasswordStrengthResult ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new PasswordStrengthResult
                {
                    Strength = PasswordStrength.Weak,
                    Score = 0,
                    Feedback = new[] { "Password is required" }
                };
            }

            var result = new PasswordStrengthResult();
            var feedback = new System.Collections.Generic.List<string>();
            int score = 0;

            // Length checks
            if (password.Length < 8)
                feedback.Add("Password should be at least 8 characters long");
            else if (password.Length >= 8)
                score += 1;

            if (password.Length >= 12)
                score += 1;

            if (password.Length >= 16)
                score += 1;

            // Character variety checks
            bool hasLower = password.Any(char.IsLower);
            bool hasUpper = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSymbol = password.Any(c => !char.IsLetterOrDigit(c));

            if (!hasLower)
                feedback.Add("Add lowercase letters");
            else
                score += 1;

            if (!hasUpper)
                feedback.Add("Add uppercase letters");
            else
                score += 1;

            if (!hasDigit)
                feedback.Add("Add numbers");
            else
                score += 1;

            if (!hasSymbol)
                feedback.Add("Add special characters");
            else
                score += 1;

            // Check for common patterns
            if (HasCommonPatterns(password))
            {
                feedback.Add("Avoid common patterns like '123', 'abc', or 'qwerty'");
                score -= 1;
            }

            // Check for repeated characters
            if (HasExcessiveRepeatedCharacters(password))
            {
                feedback.Add("Avoid repeating the same character multiple times");
                score -= 1;
            }

            // Check against common passwords
            if (IsCommonPassword(password))
            {
                feedback.Add("This appears to be a common password - choose something more unique");
                score -= 2;
            }

            // Determine strength
            result.Score = Math.Max(0, score);
            result.Strength = result.Score switch
            {
                >= 6 => PasswordStrength.Strong,
                >= 4 => PasswordStrength.Medium,
                _ => PasswordStrength.Weak
            };

            // Add positive feedback for strong passwords
            if (result.Strength == PasswordStrength.Strong && feedback.Count == 0)
            {
                feedback.Add("Excellent password strength!");
            }
            else if (result.Strength == PasswordStrength.Medium && feedback.Count == 0)
            {
                feedback.Add("Good password strength - consider making it longer for better security");
            }

            result.Feedback = feedback.ToArray();
            return result;
        }

        // Generates multiple password options for the user to choose from
        public string[] GeneratePasswordOptions(int count = 5, PasswordGenerationOptions options = null)
        {
            if (count < 1 || count > 20)
                throw new ArgumentException("Count must be between 1 and 20", nameof(count));

            options ??= new PasswordGenerationOptions();
            var passwords = new string[count];

            for (int i = 0; i < count; i++)
            {
                passwords[i] = GeneratePassword(options);
            }

            return passwords;
        }

        // Generates a memorable password using word combinations
        public string GenerateMemorablePassword(int wordCount = 4, string separator = "-")
        {
            if (wordCount < 2 || wordCount > 8)
                throw new ArgumentException("Word count must be between 2 and 8", nameof(wordCount));

            // Simple word list for memorable passwords
            string[] words = {
                "apple", "brave", "cloud", "dance", "eagle", "flame", "grace", "heart",
                "island", "jolly", "knight", "light", "magic", "night", "ocean", "peace",
                "quiet", "river", "stone", "tower", "unity", "voice", "water", "youth",
                "zebra", "anchor", "beacon", "crystal", "dragon", "forest", "garden", "happy",
                "justice", "kingdom", "legend", "mountain", "nature", "orange", "planet", "queen",
                "rainbow", "sunset", "thunder", "universe", "victory", "wisdom", "wonder", "bright"
            };

            var selectedWords = new string[wordCount];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                for (int i = 0; i < wordCount; i++)
                {
                    byte[] randomBytes = new byte[4];
                    rng.GetBytes(randomBytes);
                    uint randomValue = BitConverter.ToUInt32(randomBytes, 0);
                    int index = (int)(randomValue % words.Length);

                    // Capitalize first letter of each word
                    selectedWords[i] = char.ToUpper(words[index][0]) + words[index].Substring(1);
                }

                // Add some numbers at the end for additional security
                byte[] numberBytes = new byte[4];
                rng.GetBytes(numberBytes);
                uint numberValue = BitConverter.ToUInt32(numberBytes, 0);
                int randomNumber = (int)(numberValue % 1000);

                return string.Join(separator, selectedWords) + randomNumber.ToString("D3");
            }
        }

        // Checks if password contains common patterns
        private bool HasCommonPatterns(string password)
        {
            string lower = password.ToLowerInvariant();

            // Check for sequential characters
            string[] sequences = { "123", "234", "345", "456", "567", "678", "789", "890",
                                 "abc", "bcd", "cde", "def", "efg", "fgh", "ghi", "hij",
                                 "qwe", "wer", "ert", "rty", "tyu", "yui", "uio", "iop" };

            return sequences.Any(seq => lower.Contains(seq));
        }

        // Checks if password has excessive repeated characters
        private bool HasExcessiveRepeatedCharacters(string password)
        {
            // Check for 3 or more consecutive identical characters
            return Regex.IsMatch(password, @"(.)\1{2,}");
        }

        // Checks if password is in the list of most common passwords
        private bool IsCommonPassword(string password)
        {
            string lower = password.ToLowerInvariant();

            // List of most common passwords to avoid
            string[] commonPasswords = {
                "password", "123456", "password123", "admin", "qwerty", "letmein",
                "welcome", "monkey", "dragon", "master", "hello", "abc123",
                "123456789", "qwertyuiop", "password1", "12345678", "superman",
                "iloveyou", "trustno1", "1234567890", "starwars", "klaster",
                "freedom", "whatever", "iceman", "letmein", "123321", "diamond"
            };

            return commonPasswords.Contains(lower);
        }
    }

    // Options for password generation
    public class PasswordGenerationOptions
    {
        public int Length { get; set; } = 16;
        public bool IncludeSymbols { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool AvoidAmbiguous { get; set; } = false; // Avoid 0, O, l, I, etc.
    }


    // Result of password strength validation
    public class PasswordStrengthResult
    {
        public PasswordStrength Strength { get; set; }
        public int Score { get; set; }
        public string[] Feedback { get; set; } = Array.Empty<string>();

        public string GetStrengthText()
        {
            return Strength switch
            {
                PasswordStrength.Weak => "Weak",
                PasswordStrength.Medium => "Medium",
                PasswordStrength.Strong => "Strong",
                _ => "Unknown"
            };
        }

        public ConsoleColor GetStrengthColor()
        {
            return Strength switch
            {
                PasswordStrength.Weak => ConsoleColor.Red,
                PasswordStrength.Medium => ConsoleColor.Yellow,
                PasswordStrength.Strong => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
        }
    }
}