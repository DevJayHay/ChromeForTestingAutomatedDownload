using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOs
{
	public class Channels
	{

		[JsonPropertyName("Beta")]
		public ChannelMetaData Beta { get; set; } = new ChannelMetaData();

		[JsonPropertyName("Canary")]
		public ChannelMetaData Canary { get; set; } = new ChannelMetaData();

		[JsonPropertyName("Dev")]
		public ChannelMetaData Dev { get; set; } = new ChannelMetaData();

		[JsonPropertyName("Stable")]
		public ChannelMetaData Stable { get; set; } = new ChannelMetaData();
	}
}