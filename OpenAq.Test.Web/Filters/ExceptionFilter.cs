namespace OpenAq.Test.Web.Filters;

public class ExceptionFilter
{
	private readonly RequestDelegate _next;
	private readonly ILogger _logger;

	public ExceptionFilter(RequestDelegate next, ILogger<ExceptionFilter> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var message = exception.Message;

		_logger.LogError(exception, message);

		context.Response.Redirect($"/home/error/?msg={message}");
	}
}
