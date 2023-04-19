using System.Net.Http.Headers;

namespace OpenAq.Test.Integrations.Services.HttpClients.Base;

internal abstract class ClientBase
{
	protected static HttpClient CreateClient(string address)
	{
		var client = new HttpClient
		{
			BaseAddress = new Uri(address)
		};

		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };

		return client;
	}
}
