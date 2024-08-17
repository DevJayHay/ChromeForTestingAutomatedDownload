using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class Channels
	{

		[JsonPropertyName("Beta")]
		public ChannelBaseObject Beta { get; set; }

		[JsonPropertyName("Canary")]
		public ChannelBaseObject Canary { get; set; }

		[JsonPropertyName("Dev")]
		public ChannelBaseObject Dev { get; set; }

		[JsonPropertyName("Stable")]
		public ChannelBaseObject Stable { get; set; }
	}

	public class ChannelBaseObject
	{
		[JsonPropertyName("channel")]
		public string channel { get; set; }

		[JsonPropertyName("downloads")]
		public Downloads downloads { get; set; }

		[JsonPropertyName("revision")]
		public string revision { get; set; }

		[JsonPropertyName("version")]
		public string version { get; set; }
	}
}