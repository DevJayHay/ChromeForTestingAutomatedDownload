using System.Text.Json.Serialization;
using ChromeForTestingAutomatedDownload.DTOs;

namespace ChromeForTestingAutomatedDownload
{
	public class LastKnownGoodVersions
	{
		public class ChromeVersionModel : IChromeVersionModel
		{

			[JsonPropertyName("channels")]
			public Channels Channels { get; set; } = new Channels();

			[JsonPropertyName("timestamp")]
			public DateTime TimeStamp { get; set; }

			public Func<Task<string>> QueryEndpointAsync { get; set; } =
				GoogleChromeLabsEndpointQueries.GetLastKnownGoodVersionsAsync;
		}
	}
}