using ChromeForTestingAutomatedDownload;
using ChromeForTestingAutomatedDownload.DTOs;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

public class AssetListTests
{
	[Fact]
	public async Task GetAssetListAsync_WhenBinaryIsChrome_ShouldReturnCorrectAssetList()
	{
		// Arrange
		var factory = Substitute.For<IChromeVersionModelFactory>();
		var version = Substitute.For<IVersion>();
		var logger = Substitute.For<ILogger<AssetList>>();

		var assetList = new AssetList(factory, version, logger);

		var binary = Binary.Chrome;
		var platform = Platform.Win64; // Use the appropriate platform enum value

		
		var versionObject = new List<IVersionObject>
		{
			new VersionObject
			{
				Channel = "Stable",
				Downloads = new DownloadMetaData
				{
					Chrome = new List<PlatformMetaData>
					{
						new PlatformMetaData
						{
							Platform = "Win64",
							Url = "https://example.com/win64-chrome-url"
						},
						// Add more platform data as needed
					},
					ChromeDriver = new List<PlatformMetaData>
					{
						new PlatformMetaData
						{
							Platform = "Win64",
							Url = "https://example.com/win64-chromedriver-url"
						},
						// Add more platform data as needed
					},
					ChromeHeadlessShell = new List<PlatformMetaData>
					{
						new PlatformMetaData
						{
							Platform = "Win64",
							Url = "https://example.com/win64-chrome-headless-url"
						},
						// Add more platform data as needed
					}
				},
				Revision = "12345",
				Version = "85.0.4183.121"
			},
			// Add more VersionObject instances as needed
		};


		version.GetVersionObject().Returns(versionObject);

		// Act
		var result = await assetList.GetAssetListAsync<KnownGoodVersions.ChromeVersionModel>(binary, platform);

		// Assert
		result.Should().NotBeNull();
		result.Should().ContainKey("85.0.4183.121"); // Replace with the expected version
		result.Should().ContainValue("https://example.com/chrome-download-url"); // Replace with the expected URL
	}

	// Add similar test methods for Binary.ChromeDriver and Binary.ChromeHeadlessShell
}