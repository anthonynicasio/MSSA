using System;
using System.Threading.Tasks;
using PasswordManager.Services;
using PasswordManager.UI;

namespace PasswordManager
{

    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Configure console for better experience
                ConfigureConsole();

                // Initialize services with dependency injection pattern
                var cryptoService = new CryptographyService();
                var fileService = new FileService();
                var vaultService = new VaultService(cryptoService, fileService);
                var passwordService = new PasswordService(cryptoService);
                var inputService = new InputService();

                // Create and run the main menu service
                var menuService = new MenuService(
                    cryptoService,
                    vaultService,
                    passwordService,
                    fileService,
                    inputService);

                await menuService.RunAsync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fatal error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;

#if DEBUG
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
#endif

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        // Configures console settings for optimal user experience
        private static void ConfigureConsole()
        {
            try
            {
                // Set console title
                Console.Title = "Secure Password Manager";

                // Set console colors
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                // Clear any existing content
                Console.Clear();

                // Set encoding to support special characters
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                // Configure console size if possible
                if (OperatingSystem.IsWindows())
                {
                    try
                    {
                        Console.SetWindowSize(Math.Min(120, Console.LargestWindowWidth),
                                            Math.Min(30, Console.LargestWindowHeight));
                    }
                    catch
                    {
                        // Ignore if console size cannot be set
                    }
                }
            }
            catch (Exception)
            {
                // Ignore console configuration errors - not critical for functionality
            }
        }
    }
}