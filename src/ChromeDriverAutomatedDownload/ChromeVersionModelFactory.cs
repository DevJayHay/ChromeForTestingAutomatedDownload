using System.Text.Json;

namespace ChromeForTestingAutomatedDownload
{
	public interface IChromeVersionModelFactory
	{
		Task<T> CreateInstanceAsync<T>() where T : IChromeVersionModel;
	}

	public class ChromeVersionModelFactory : IChromeVersionModelFactory
	{
		public async Task<T> CreateInstanceAsync<T>() where T : IChromeVersionModel
		{
			var instance = Activator.CreateInstance<T>();
			var response = await instance.QueryEndpointAsync();
			var deserializedObject = JsonSerializer.Deserialize<T>(response);
			if (deserializedObject != null) return deserializedObject;

			throw new JsonException("Failed to deserialize endpoint.");
		}
	}
}