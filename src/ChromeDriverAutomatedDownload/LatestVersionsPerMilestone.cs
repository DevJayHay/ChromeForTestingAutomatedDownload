using System.Text.Json.Serialization;
using ChromeForTestingAutomatedDownload.DTOs;

namespace ChromeForTestingAutomatedDownload
{
	public class LatestVersionsPerMilestone
	{
		public class ChromeVersionModel : IChromeVersionModel
		{

			[JsonPropertyName("milestones")]
			public Dictionary<string, Milestones> Milestones { get; set; } = new Dictionary<string, Milestones>();

			[JsonPropertyName("timestamp")]
			public DateTime TimeStamp { get; set; }

			public Func<Task<string>> QueryEndpointAsync { get; set; } =
				GoogleChromeLabsEndpointQueries.GetLatestVersionsPerMilestoneAsync;
		}
	}
}