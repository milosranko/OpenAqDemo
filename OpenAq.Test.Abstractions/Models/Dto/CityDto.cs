namespace OpenAq.Test.Integrations.Abstractions.Models.Dto;

public class CityDto
{
	public string Name { get; set; }
	public string CountryName { get; set; }
	public DateTime LastUpdated { get; set; }
	public string[] Parameters { get; set; }
}
