using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOs
{
	public abstract class Build
	{

		[JsonPropertyName("downloads")]
		public DownloadMetaData Downloads { get; set; } = new DownloadMetaData();

		[JsonPropertyName("revision")]
		public string Revision { get; set; } = string.Empty;

		[JsonPropertyName("version")]
		public string Version { get; set; } = string.Empty;
	}

}