using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOs
{
	public class Milestones
	{
		[JsonPropertyName("milestone")]
		public string Channel { get; set; } = string.Empty;

		[JsonPropertyName("downloads")]
		public DownloadMetaData Downloads { get; set; } = new DownloadMetaData();

		[JsonPropertyName("revision")]
		public string Revision { get; set; } = string.Empty;

		[JsonPropertyName("version")]
		public string Version { get; set; } = string.Empty;
	}
}