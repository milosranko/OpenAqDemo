namespace OpenAq.Test.Integrations.Abstractions.Models.Dto;

public class CountryDto
{
	public string Code { get; set; }
	public string Name { get; set; }
	public DateTime LastUpdated { get; set; }
	public string[] Parameters { get; set; }
}
