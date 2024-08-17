using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ChromeForTestingAutomatedDownload
{
	public class LocalVersionChecking
	{
		private static ILogger<LocalVersionChecking> _logger;

		public LocalVersionChecking(ILogger<LocalVersionChecking> logger)
		{
			_logger = logger ?? NullLogger<LocalVersionChecking>.Instance;
		}

		public static async Task<ChromeLocalVersion> GetChromeVersion()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				return await GetChromeVersionWindowsAsync();

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				return await GetChromeVersionRunProcessAsync("google-chrome", "--product-version");

			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				return await GetChromeVersionRunProcessAsync(
					Path.Combine("/", "Applications", "Google Chrome.app", "Contents", "MacOS", "Google Chrome"),
					"--version");

			throw new PlatformNotSupportedException("Your operating system is not supported.");
		}

		private static async Task<ChromeLocalVersion> GetChromeVersionWindowsAsync()
		{
			await Task.Yield();
			var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			var chromePath = Path.Combine(programFilesPath, "Google", "Chrome", "Application", "chrome.exe");

			if (!File.Exists(chromePath))
				return null; // or return a default version instance as per your design choice 

			var fileVersionInfo = FileVersionInfo.GetVersionInfo(chromePath);
			return !string.IsNullOrEmpty(fileVersionInfo.FileVersion)
				? new ChromeLocalVersion(fileVersionInfo.FileVersion)
				: null; // or return a default version instance as per your design choice 
		}

		private static async Task<ChromeLocalVersion> GetChromeVersionRunProcessAsync(string fileName, string arguments)
		{
			try
			{
				using var process = Process.Start(
					new ProcessStartInfo
					{
						FileName = fileName,
						ArgumentList = { arguments },
						UseShellExecute = false,
						CreateNoWindow = true,
						RedirectStandardOutput = true,
						RedirectStandardError = true
					}
				);

				var output = await (process?.StandardOutput ?? new StreamReader(new MemoryStream())).ReadToEndAsync();
				var error = await (process?.StandardError ?? new StreamReader(new MemoryStream())).ReadToEndAsync();
				await (process?.WaitForExitAsync() ?? new Task(() => { }));

				if (!string.IsNullOrEmpty(error))
				{
					output = output.Replace("Google Chrome ", "");
				}

				return new ChromeLocalVersion(output);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error {eMessage}", ex.Message);

				return null; // or return a default version instance as per your design choice 
			}
		}
	}
}