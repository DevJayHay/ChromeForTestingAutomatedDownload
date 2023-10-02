using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class Versions
	{

		[JsonPropertyName("downloads")]
		public Downloads Downloads { get; set; }

		[JsonPropertyName("revision")]
		public string Revision { get; set; }

		[JsonPropertyName("version")]
		public string VersionNumber { get; set; }
	}
}