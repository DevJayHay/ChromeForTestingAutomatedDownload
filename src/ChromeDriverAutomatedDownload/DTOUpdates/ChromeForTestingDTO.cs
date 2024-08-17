using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class ChromeForTestingDTO
	{
		[JsonPropertyName("timestamp")]
		public DateTime? timestamp { get; set; }

		[JsonPropertyName("versions")]
		public List<Versions> Versions { get; set; }
		
		[JsonExtensionData]
		public Dictionary<string, Info> Builds { get; set; }
		
		[JsonPropertyName("milestones")]
		public Dictionary<string, Info> Milestones { get; set; }
		
		[JsonPropertyName("channels")]
		public Channels channels { get; set; }
	}
}