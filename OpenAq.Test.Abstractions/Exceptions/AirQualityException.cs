namespace OpenAq.Test.Integrations.Abstractions.Exceptions;

public class AirQualityException : Exception
{
	public AirQualityException(string message) : base(message)
	{ }

	public AirQualityException(string message, Exception e) : base(message, e)
	{ }
}
