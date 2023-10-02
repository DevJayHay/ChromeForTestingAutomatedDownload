namespace ChromeForTestingAutomatedDownload
{


	public interface IVersion
	{
		Dictionary<string, IVersionObject> GetVersionObject();
	}

	public interface IDownload
	{
		Task<string> GetMostRecentAssetURLAsync(Binary binary, Platform platform);
	}

	public interface IDownloadByMajorRelease
	{
		Task<string> GetMostRecentAssetURLByMajorReleaseNumberAsync(Binary binary, Platform platform,
			int majorReleaseNumber);
	}

	public interface IDownloadByFullVersion
	{
		Task<string> GetAssetURLByFullVersionNumberAsync(Binary binary, Platform platform, string fullVersionNumber);
	}
}