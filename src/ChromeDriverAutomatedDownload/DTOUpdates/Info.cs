using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class Info
	{
		[JsonPropertyName("milestone")]
		public string Milestone { get; set; }

		[JsonPropertyName("version")]
		public string Version { get; set; }

		[JsonPropertyName("revision")]
		public string Revision { get; set; }
		
		[JsonPropertyName("downloads")]
		public Downloads Downloads { get; set; }
	}
}