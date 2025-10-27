using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Utilities
{
    // Provides secure clipboard operations with auto-clear functionality
    public class ClipboardService
    {
        private static Timer _clearTimer;
        private static readonly object _lock = new object();

        // Copies text to clipboard with automatic clearing after specified time
        public static async Task CopyToClipboardAsync(string text, int clearAfterSeconds = 30)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text cannot be null or empty", nameof(text));

            if (clearAfterSeconds < 1)
                throw new ArgumentException("Clear time must be at least 1 second", nameof(clearAfterSeconds));

            try
            {
                await SetClipboardTextAsync(text);

                lock (_lock)
                {
                    // Cancel any existing timer
                    _clearTimer?.Dispose();

                    // Set up new timer to clear clipboard
                    _clearTimer = new Timer(async _ => await ClearClipboardAsync(),
                                          null,
                                          TimeSpan.FromSeconds(clearAfterSeconds),
                                          Timeout.InfiniteTimeSpan);
                }

                Console.WriteLine($"Copied to clipboard. Will clear in {clearAfterSeconds} seconds.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to copy to clipboard: {ex.Message}", ex);
            }
        }

        // Manually clears the clipboard
        public static async Task ClearClipboardAsync()
        {
            try
            {
                await SetClipboardTextAsync(string.Empty);

                lock (_lock)
                {
                    _clearTimer?.Dispose();
                    _clearTimer = null;
                }
            }
            catch (Exception)
            {
                // Ignore errors when clearing clipboard
            }
        }

        // Sets clipboard text with cross-platform support
        private static async Task SetClipboardTextAsync(string text)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                await SetClipboardWindows(text);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                await SetClipboardLinux(text);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                await SetClipboardMacOS(text);
            }
            else
            {
                throw new PlatformNotSupportedException("Clipboard operations not supported on this platform");
            }
        }

        // Sets clipboard on Windows using P/Invoke
        private static async Task SetClipboardWindows(string text)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (!OpenClipboard(IntPtr.Zero))
                        throw new InvalidOperationException("Failed to open clipboard");

                    if (!EmptyClipboard())
                        throw new InvalidOperationException("Failed to empty clipboard");

                    if (!string.IsNullOrEmpty(text))
                    {
                        IntPtr hGlobal = Marshal.StringToHGlobalUni(text);
                        if (SetClipboardData(CF_UNICODETEXT, hGlobal) == IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(hGlobal);
                            throw new InvalidOperationException("Failed to set clipboard data");
                        }
                    }
                }
                finally
                {
                    CloseClipboard();
                }
            });
        }

        // Sets clipboard on Linux using xclip or xsel
        private static async Task SetClipboardLinux(string text)
        {
            try
            {
                // Try xclip first
                await RunCommand("xclip", "-selection clipboard", text);
            }
            catch
            {
                try
                {
                    // Fallback to xsel
                    await RunCommand("xsel", "--clipboard --input", text);
                }
                catch
                {
                    throw new InvalidOperationException("Neither xclip nor xsel available for clipboard operations");
                }
            }
        }

        // Sets clipboard on macOS using pbcopy
        private static async Task SetClipboardMacOS(string text)
        {
            await RunCommand("pbcopy", "", text);
        }

        // Runs a command with input text
        private static async Task RunCommand(string command, string arguments, string input)
        {
            using var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            if (!string.IsNullOrEmpty(input))
            {
                await process.StandardInput.WriteAsync(input);
                process.StandardInput.Close();
            }

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                throw new InvalidOperationException($"Command '{command}' failed with exit code {process.ExitCode}");
        }

        // Gets clipboard text (for verification purposes)
        public static async Task<string> GetClipboardTextAsync()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return await GetClipboardWindows();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return await GetClipboardLinux();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return await GetClipboardMacOS();
            }
            else
            {
                throw new PlatformNotSupportedException("Clipboard operations not supported on this platform");
            }
        }

        private static async Task<string> GetClipboardWindows()
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (!OpenClipboard(IntPtr.Zero))
                        return string.Empty;

                    IntPtr hData = GetClipboardData(CF_UNICODETEXT);
                    if (hData == IntPtr.Zero)
                        return string.Empty;

                    IntPtr pData = GlobalLock(hData);
                    if (pData == IntPtr.Zero)
                        return string.Empty;

                    try
                    {
                        return Marshal.PtrToStringUni(pData) ?? string.Empty;
                    }
                    finally
                    {
                        GlobalUnlock(hData);
                    }
                }
                finally
                {
                    CloseClipboard();
                }
            });
        }

        private static async Task<string> GetClipboardLinux()
        {
            try
            {
                return await RunCommandWithOutput("xclip", "-selection clipboard -output");
            }
            catch
            {
                try
                {
                    return await RunCommandWithOutput("xsel", "--clipboard --output");
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        private static async Task<string> GetClipboardMacOS()
        {
            return await RunCommandWithOutput("pbpaste", "");
        }

        private static async Task<string> RunCommandWithOutput(string command, string arguments)
        {
            using var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            return process.ExitCode == 0 ? output : string.Empty;
        }

        // Windows API functions
        private const uint CF_UNICODETEXT = 13;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool CloseClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EmptyClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GlobalUnlock(IntPtr hMem);
    }
}