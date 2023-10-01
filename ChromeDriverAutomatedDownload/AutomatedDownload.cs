using System.IO.Compression;
using Microsoft.Extensions.Logging;

namespace ChromeForTestingAutomatedDownload
{
	public class AutomatedDownload
	{
		private readonly IChromeVersionModelFactory _factory;
		private readonly ILogger<AutomatedDownload> _logger;

		public AutomatedDownload(IChromeVersionModelFactory factory, ILogger<AutomatedDownload> logger)
		{
			_factory = factory;
			_logger = logger;
		}

		public async Task DownloadChromeDriver(string downloadPath = "")
		{
			if (string.IsNullOrWhiteSpace(downloadPath))
			{
				downloadPath = AppDomain.CurrentDomain.BaseDirectory;
			}

			var localVersion = await LocalVersionChecking.GetChromeVersion();
			if (localVersion != null)
			{
				var localMajorRelease = localVersion.MajorReleaseNumber;

				var model = await _factory
					.CreateInstanceAsync<LatestVersionsPerMilestoneWithDownload.ChromeVersionModel>();

				var url = await model.GetMostRecentAssetURLByMajorReleaseNumberAsync(Binary.ChromeDriver,
					Platform.Win64, localMajorRelease);

				using var httpClient = new HttpClient();

				try
				{
					var response = await httpClient.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						await DownloadFile(response, downloadPath);
					}
					else
					{
						Console.WriteLine($"Failed to download file. Status code: {response.StatusCode}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
				}
			}
		}

		private async Task DownloadFile(HttpResponseMessage response, string downloadPath)
		{
			await using var stream = await response.Content.ReadAsStreamAsync();
			var fileName = Path.GetFileName(response.RequestMessage?.RequestUri?.ToString()) ?? string.Empty;
			await using var fileStream = File.Create(Path.Combine(downloadPath, fileName));

			await stream.CopyToAsync(fileStream);

			fileStream.Position = 0; // Reset the position to the beginning as it's needed by ZipArchive

			await UnzipAndExtractDriver(fileStream, downloadPath);

			Console.WriteLine("File downloaded successfully!");
		}

		private async Task UnzipAndExtractDriver(Stream fileStream, string downloadPath)
		{
			using var archive = new ZipArchive(fileStream);
			const string driverFileName = "chromedriver.exe";

			var driver = archive.Entries.FirstOrDefault(x => x.FullName.Contains(driverFileName));

			if (driver != null)
			{
				await Task.Run(() => driver.ExtractToFile(Path.Combine(downloadPath, driverFileName), true));
			}
			else
			{
				throw new Exception($"{driverFileName} not found in the downloaded archive.");
			}
		}
	}
}