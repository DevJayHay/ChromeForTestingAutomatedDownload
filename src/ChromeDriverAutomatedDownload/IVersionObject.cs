using ChromeForTestingAutomatedDownload.DTOs;

namespace ChromeForTestingAutomatedDownload
{
	public interface IVersionObject
	{
		public string Channel { get; set; }

		public DownloadMetaData Downloads { get; set; }

		public string Revision { get; set; }

		public string Version { get; set; }
	}
}