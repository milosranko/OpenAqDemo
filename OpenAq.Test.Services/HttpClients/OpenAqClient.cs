using OpenAq.Test.Integrations.Services.HttpClients.Base;

namespace OpenAq.Test.Integrations.Services.HttpClients;

internal sealed class OpenAqClient : ClientBase
{
	private static readonly Lazy<HttpClient> _instance = new(() => CreateClient("https://api.openaq.org"));
	internal static HttpClient Instance => _instance.Value;
}
