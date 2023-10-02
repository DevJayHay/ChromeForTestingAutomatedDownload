using System.Text.Json.Serialization;

namespace ChromeForTestingAutomatedDownload.DTOUpdates
{
	public class Downloads
	{
		[JsonPropertyName("chrome")]
		public List<ChromeBaseObject> Chrome { get; set; }

		[JsonPropertyName("chromedriver")]
		public List<ChromeBaseObject> ChromeDriver { get; set; }

		[JsonPropertyName("chrome-headless-shell")]
		public List<ChromeBaseObject> ChromeHeadlessShell { get; set; }
	}

	
}