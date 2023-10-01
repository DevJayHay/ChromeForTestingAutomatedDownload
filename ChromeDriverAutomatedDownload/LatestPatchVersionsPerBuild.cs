using System.Text.Json.Serialization;
using ChromeForTestingAutomatedDownload.DTOs;

namespace ChromeForTestingAutomatedDownload
{
	public abstract class LatestPatchVersionsPerBuild
	{
		public class ChromeVersionModel : IChromeVersionModel
		{

			[JsonPropertyName("builds")]
			public Dictionary<string, Build> Builds { get; set; } = new Dictionary<string, Build>();

			[JsonPropertyName("timestamp")]
			public DateTime TimeStamp { get; set; }

			public Func<Task<string>> QueryEndpointAsync { get; set; } =
				GoogleChromeLabsEndpointQueries.GetLatestPatchVersionsPerBuildAsync;
		}
	}
}