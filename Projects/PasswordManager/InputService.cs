using System;
using System.Text;

namespace PasswordManager.UI
{
    // Handles user input with validation and security features
    public class InputService
    {
        // Reads a password from the console with masked input
        public string ReadPassword(string prompt = "Password: ")
        {
            Console.Write(prompt);
            var password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Backspace:
                        if (password.Length > 0)
                        {
                            password.Remove(password.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        break;
                    case ConsoleKey.Escape:
                        // Clear the current input
                        while (password.Length > 0)
                        {
                            password.Remove(password.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        if (!char.IsControl(key.KeyChar))
                        {
                            password.Append(key.KeyChar);
                            Console.Write("*");
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }

        // Reads a line of input with optional validation
        public string ReadLine(string prompt, bool required = false, int maxLength = 0)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (required && string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("This field is required. Please try again.");
                    continue;
                }

                if (maxLength > 0 && input.Length > maxLength)
                {
                    Console.WriteLine($"Input cannot exceed {maxLength} characters. Please try again.");
                    continue;
                }

                break;
            } while (true);

            return input;
        }

        // Reads an integer with validation
        public int ReadInteger(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if (value < min || value > max)
                {
                    if (min != int.MinValue && max != int.MaxValue)
                        Console.WriteLine($"Please enter a number between {min} and {max}.");
                    else if (min != int.MinValue)
                        Console.WriteLine($"Please enter a number >= {min}.");
                    else if (max != int.MaxValue)
                        Console.WriteLine($"Please enter a number <= {max}.");
                    continue;
                }

                break;
            } while (true);

            return value;
        }

        // Asks for yes/no confirmation
        public bool ReadConfirmation(string prompt, bool defaultValue = false)
        {
            string suffix = defaultValue ? " [Y/n]: " : " [y/N]: ";

            while (true)
            {
                Console.Write(prompt + suffix);
                string input = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                    return defaultValue;

                switch (input)
                {
                    case "y":
                    case "yes":
                        return true;
                    case "n":
                    case "no":
                        return false;
                    default:
                        Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
                        continue;
                }
            }
        }

        // Reads a choice from a list of options
        public int ReadChoice(string prompt, string[] options, bool allowCancel = false)
        {
            if (options == null || options.Length == 0)
                throw new ArgumentException("Options cannot be null or empty", nameof(options));

            while (true)
            {
                Console.WriteLine(prompt);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                if (allowCancel)
                    Console.WriteLine("0. Cancel");

                int maxChoice = options.Length;
                int minChoice = allowCancel ? 0 : 1;

                int choice = ReadInteger("Enter your choice: ", minChoice, maxChoice);

                if (choice == 0 && allowCancel)
                    return -1; // Indicates cancellation

                return choice - 1; // Convert to 0-based index
            }
        }

        // Reads a file path with validation
        public string ReadFilePath(string prompt, bool mustExist = false, bool forSaving = false)
        {
            while (true)
            {
                string path = ReadLine(prompt, true);

                try
                {
                    // Basic path validation
                    if (path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
                    {
                        Console.WriteLine("Invalid characters in path. Please try again.");
                        continue;
                    }

                    if (mustExist && !System.IO.File.Exists(path))
                    {
                        Console.WriteLine("File does not exist. Please try again.");
                        continue;
                    }

                    if (forSaving)
                    {
                        string directory = System.IO.Path.GetDirectoryName(path);
                        if (!string.IsNullOrEmpty(directory) && !System.IO.Directory.Exists(directory))
                        {
                            if (ReadConfirmation($"Directory '{directory}' does not exist. Create it?", true))
                            {
                                try
                                {
                                    System.IO.Directory.CreateDirectory(directory);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Failed to create directory: {ex.Message}");
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        // Check if file already exists and confirm overwrite
                        if (System.IO.File.Exists(path))
                        {
                            if (!ReadConfirmation($"File '{path}' already exists. Overwrite?", false))
                                continue;
                        }
                    }

                    return path;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid path: {ex.Message}");
                }
            }
        }

        // Displays a selection menu and returns the selected index
        public int DisplaySelectionMenu<T>(string title, T[] items, Func<T, string> displaySelector, bool allowCancel = true)
        {
            if (items == null || items.Length == 0)
                throw new ArgumentException("Items cannot be null or empty", nameof(items));

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(title);
                Console.WriteLine(new string('=', title.Length));

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1,2}. {displaySelector(items[i])}");
                }

                if (allowCancel)
                    Console.WriteLine(" 0. Cancel");

                Console.WriteLine();

                int maxChoice = items.Length;
                int minChoice = allowCancel ? 0 : 1;

                int choice = ReadInteger("Select an option: ", minChoice, maxChoice);

                if (choice == 0 && allowCancel)
                    return -1; // Indicates cancellation

                return choice - 1; // Convert to 0-based index
            }
        }

        // Pauses execution and waits for user input
        public void PressAnyKey(string message = "Press any key to continue...")
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }


        // Clears the console screen
        public void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch (Exception)
            {
                // If clear fails, just add some newlines
                Console.WriteLine(new string('\n', 50));
            }
        }

        // Displays a header with formatting
        public void DisplayHeader(string title, string subtitle = null)
        {
            Console.WriteLine();
            Console.WriteLine(new string('═', Math.Max(title.Length, subtitle?.Length ?? 0) + 4));
            Console.WriteLine($"  {title}");
            if (!string.IsNullOrEmpty(subtitle))
            {
                Console.WriteLine($"  {subtitle}");
            }
            Console.WriteLine(new string('═', Math.Max(title.Length, subtitle?.Length ?? 0) + 4));
            Console.WriteLine();
        }

        // Displays an error message with formatting
        public void DisplayError(string message)
        {
            var originalColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✗ Error: {message}");
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }

        // Displays a success message with formatting
        public void DisplaySuccess(string message)
        {
            var originalColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ {message}");
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }

        // Displays a warning message with formatting
        public void DisplayWarning(string message)
        {
            var originalColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"⚠ Warning: {message}");
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }

        // Displays an info message with formatting
        public void DisplayInfo(string message)
        {
            var originalColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ℹ {message}");
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }

        // Creates a formatted table from data
        public void DisplayTable(string[] headers, string[][] rows, int[] columnWidths = null)
        {
            if (headers == null || headers.Length == 0)
                throw new ArgumentException("Headers cannot be null or empty", nameof(headers));

            if (rows == null)
                rows = new string[0][];

            // Calculate column widths if not provided
            if (columnWidths == null)
            {
                columnWidths = new int[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                {
                    columnWidths[i] = headers[i].Length;
                    foreach (var row in rows)
                    {
                        if (i < row.Length && row[i] != null)
                        {
                            columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                        }
                    }
                    columnWidths[i] = Math.Min(columnWidths[i], Console.WindowWidth / headers.Length - 3);
                }
            }

            // Display header
            DisplayTableRow(headers, columnWidths, true);

            // Display separator
            for (int i = 0; i < headers.Length; i++)
            {
                Console.Write(new string('-', columnWidths[i] + 2));
                if (i < headers.Length - 1)
                    Console.Write("+");
            }
            Console.WriteLine();

            // Display rows
            foreach (var row in rows)
            {
                DisplayTableRow(row, columnWidths, false);
            }
        }

        private void DisplayTableRow(string[] columns, int[] widths, bool isHeader)
        {
            for (int i = 0; i < columns.Length && i < widths.Length; i++)
            {
                string value = i < columns.Length ? (columns[i] ?? "") : "";

                // Truncate if too long
                if (value.Length > widths[i])
                    value = value.Substring(0, widths[i] - 3) + "...";

                if (isHeader)
                {
                    var originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {value.PadRight(widths[i])} ");
                    Console.ForegroundColor = originalColor;
                }
                else
                {
                    Console.Write($" {value.PadRight(widths[i])} ");
                }

                if (i < columns.Length - 1)
                    Console.Write("|");
            }
            Console.WriteLine();
        }
    }
}