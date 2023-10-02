using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class ChromeBaseObject
	{
		[JsonPropertyName("platform")]
		public string platform { get; set; }

		[JsonPropertyName("url")]
		public string url { get; set; }
	}
}