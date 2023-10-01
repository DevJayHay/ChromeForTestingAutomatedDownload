using System.Text.Json.Serialization;
using ChromeForTestingAutomatedDownload.DTOs;
using Microsoft.Extensions.Logging;

namespace ChromeForTestingAutomatedDownload
{
	public class LatestVersionsPerMilestoneWithDownload
	{
		public class ChromeVersionModel : IChromeVersionModel, IDownload, IVersion, IDownloadByMajorRelease,
			IDownloadByFullVersion
		{
			private readonly AssetList _assetList;
			private readonly ILogger<ChromeVersionModel> _logger;

			public ChromeVersionModel(AssetList assetList, ILogger<ChromeVersionModel> logger)
			{
				_assetList = assetList;
				_logger = logger;
			}

			[JsonPropertyName("milestones")]
			public Dictionary<string, Milestones> Milestones { get; set; } = new Dictionary<string, Milestones>();

			[JsonPropertyName("timestamp")]
			public DateTime TimeStamp { get; set; }

			public Func<Task<string>> QueryEndpointAsync { get; set; } = GoogleChromeLabsEndpointQueries
				.GetLatestVersionsPerMilestoneWithDownloadAsync;


			public async Task<string> GetMostRecentAssetURLAsync(Binary binary, Platform platform)
			{
				var platformList = await GetPlatformListAsync(binary, platform);

				return platformList?.OrderByDescending(x => x.Key)
					.FirstOrDefault().Value;
			}

			public async Task<string> GetAssetURLByFullVersionNumberAsync(Binary binary, Platform platform,
				string fullVersionNumber)
			{
				var platformList = await GetPlatformListAsync(binary, platform);

				return platformList?
					.FirstOrDefault(x =>
						x.Key.Equals(fullVersionNumber, StringComparison.InvariantCultureIgnoreCase)).Value;
			}

			public async Task<string> GetMostRecentAssetURLByMajorReleaseNumberAsync(Binary binary,
				Platform platform, int majorReleaseNumber)
			{
				var platformList = await GetPlatformListAsync(binary, platform);

				return platformList?.OrderByDescending(x => x.Key)
					.FirstOrDefault(x => x.Key.Split('.')[0].Equals(majorReleaseNumber.ToString())).Value;
			}

			public Dictionary<string, IVersionObject> GetVersionObject()
			{
				return Milestones.ToDictionary(x => x.Key, x => (IVersionObject)x.Value);
			}

			private async Task<Dictionary<string, string>> GetPlatformListAsync(Binary binary, Platform platform)
			{
				return await _assetList.GetAssetListAsync<ChromeVersionModel>(binary, platform);
			}
		}
	}
}