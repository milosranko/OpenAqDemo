using OpenAq.Test.Integrations.Services.HttpClients.Base;

namespace OpenAq.Test.Integrations.Services.HttpClients;

internal sealed class OpenAqClient : ClientBase
{
	private static string _apiUrl;
	private static bool _isInitialized = false;

	public static void Initialize(string apiUrl)
	{
		if (string.IsNullOrEmpty(_apiUrl))
		{
			_apiUrl = apiUrl;
			_isInitialized = true;
		}
	}

	private static readonly Lazy<HttpClient> _instance = new(() => CreateClient(_apiUrl));
	internal static HttpClient Instance => _instance.Value;
	internal static bool IsInitialized => _isInitialized;
}
