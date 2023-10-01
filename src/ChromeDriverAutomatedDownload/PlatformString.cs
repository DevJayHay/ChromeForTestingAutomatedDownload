namespace ChromeForTestingAutomatedDownload
{
	internal class PlatformString
	{
		public static string GetPlatformString(Platform _platform)
		{
			return _platform switch
			{
				Platform.Linux64 => "linux64",
				Platform.MacArm64 => "mac-arm64",
				Platform.MacX64 => "mac-x64",
				Platform.Win32 => "win32",
				Platform.Win64 => "win64",
				_ => null
			};
		}
	}
}