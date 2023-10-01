namespace ChromeForTestingAutomatedDownload
{
	public interface IChromeVersionModel
	{
		public Func<Task<string>> QueryEndpointAsync { get; set; }
	}
}