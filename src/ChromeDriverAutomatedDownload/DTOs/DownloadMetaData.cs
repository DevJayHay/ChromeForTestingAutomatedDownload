using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOs
{
	public class DownloadMetaData
	{
		[JsonPropertyName("chrome")]
		public List<PlatformMetaData> Chrome { get; set; } = new List<PlatformMetaData>();

		[JsonPropertyName("chromedriver")]
		public List<PlatformMetaData> ChromeDriver { get; set; } = new List<PlatformMetaData>();

		[JsonPropertyName("chrome-headless-shell")]
		public List<PlatformMetaData> ChromeHeadlessShell { get; set; } = new List<PlatformMetaData>();
	}
}