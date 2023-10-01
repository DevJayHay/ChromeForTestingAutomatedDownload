namespace ChromeForTestingAutomatedDownload
{
	public class ChromeLocalVersion
	{

		internal ChromeLocalVersion(string versionString)
		{
			VersionString = versionString;
		}

		public int MajorReleaseNumber
		{
			get
			{
				var majorRelease = int.TryParse(VersionString.Split(".")[0], out var _majorRelease) ? _majorRelease : 0;
				return majorRelease;
			}
		}

		public string VersionString
		{
			get;
		}
	}
}