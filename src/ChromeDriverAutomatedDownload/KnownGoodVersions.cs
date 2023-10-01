using System.Text.Json.Serialization;
using ChromeForTestingAutomatedDownload.DTOs;

namespace ChromeForTestingAutomatedDownload
{
	public class KnownGoodVersions
	{
		public class ChromeVersionModel : IChromeVersionModel
		{

			[JsonPropertyName("timestamp")]
			public DateTime TimeStamp { get; set; }

			[JsonPropertyName("versions")]
			public List<VersionMetaData> Versions { get; set; } = new List<VersionMetaData>();

			public Func<Task<string>> QueryEndpointAsync { get; set; } =
				GoogleChromeLabsEndpointQueries.GetKnownGoodVersionsAsync;
		}
	}
}