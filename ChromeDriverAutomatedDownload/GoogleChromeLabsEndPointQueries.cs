using Microsoft.Extensions.Logging;

namespace ChromeForTestingAutomatedDownload
{
	public class GoogleChromeLabsEndpointQueries
	{
		private readonly ILogger<GoogleChromeLabsEndpointQueries> _logger;
		private static readonly HttpClient _httpClient = new HttpClient();

		public GoogleChromeLabsEndpointQueries(ILogger<GoogleChromeLabsEndpointQueries> logger)
		{
			_logger = logger;

		}

		public static async Task<string> GetKnownGoodVersionsAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/known-good-versions.json");
		}

		public async Task<string> GetKnownGoodVersionsWithDownloadAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/known-good-versions-with-downloads.json");
		}

		public static async Task<string> GetLastKnownGoodVersionsAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/last-known-good-versions.json");
		}

		public async Task<string> GetLastKnownGoodVersionsWithDownloadAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/last-known-good-versions-with-downloads.json");
		}

		public static async Task<string> GetLatestPatchVersionsPerBuildAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/latest-patch-versions-per-build.json");
		}

		public async Task<string> GetLatestPatchVersionsPerBuildAsyncWithDownloads()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/latest-patch-versions-per-build-with-downloads.json");
		}

		public static async Task<string> GetLatestVersionsPerMilestoneAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/latest-versions-per-milestone.json");
		}

		public static async Task<string> GetLatestVersionsPerMilestoneWithDownloadAsync()
		{
			return await _httpClient.GetStringAsync(
				"https://googlechromelabs.github.io/chrome-for-testing/latest-versions-per-milestone-with-downloads.json");
		}
	}
}