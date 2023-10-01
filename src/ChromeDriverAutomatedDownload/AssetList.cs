#nullable enable
using ChromeForTestingAutomatedDownload.DTOs;
using Microsoft.Extensions.Logging;

namespace ChromeForTestingAutomatedDownload
{
	public class AssetList
	{
		private readonly IChromeVersionModelFactory _factory;
		private readonly IVersion _version;
		private readonly ILogger<AssetList> _logger;


		public AssetList(IChromeVersionModelFactory factory, IVersion version, ILogger<AssetList> logger)
		{
			_factory = factory;
			_version = version;
			_logger = logger;

		}

		public async Task<Dictionary<string, string>> GetAssetListAsync<T>(Binary _binary, Platform _platform)
			where T : IChromeVersionModel, IDownload
		{
			var platform = PlatformString.GetPlatformString(_platform) ?? string.Empty;

			await _factory.CreateInstanceAsync<T>();

			var versionObject = _version.GetVersionObject().Values;

			return _binary switch
			{
				Binary.Chrome => GetByVersion(versionObject, platform, x => x.Downloads.Chrome),
				Binary.ChromeDriver => GetByVersion(versionObject, platform, x => x.Downloads.ChromeDriver),
				Binary.ChromeHeadlessShell => GetByVersion(versionObject, platform,
					x => x.Downloads.ChromeHeadlessShell),
				_ => null
			} ?? throw new InvalidOperationException();
		}

		private static Dictionary<string, string> GetByVersion(
			IEnumerable<IVersionObject> versionObject,
			string platform,
			Func<IVersionObject, IEnumerable<PlatformMetaData>> selectFunc)
		{
			return versionObject
				.ToDictionary(x => x.Version,
					x => selectFunc(x).Where(platformMetaData =>
							(platformMetaData.Platform ?? string.Empty).Equals(platform))
						.Select(platformMetaData => platformMetaData.Url)
						.FirstOrDefault())
				.Where(x => string.IsNullOrEmpty(x.Value) == false)
				.ToDictionary(x => x.Key, x => x.Value ?? string.Empty);
		}
	}
}