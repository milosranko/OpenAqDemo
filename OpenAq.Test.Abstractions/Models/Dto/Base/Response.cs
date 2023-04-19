namespace OpenAq.Test.Integrations.Abstractions.Models.Dto.Base;

public class Response<T> where T : class
{
	public int Page { get; set; }
	public int PageSize { get; set; }
	public int Total { get; set; }
	public IEnumerable<string> Errors { get; set; }
	public T[] Results { get; set; }
}

public static class Response
{
	public static Response<T> Empty<T>() where T : class
	{
		return new Response<T>
		{
			Errors = Enumerable.Empty<string>(),
			Page = 0,
			PageSize = 0,
			Total = 0,
			Results = Array.Empty<T>()
		};
	}
}
