namespace OpenAq.Test.Integrations.Abstractions.Models.Dto;

public class MeasurementDto
{
	public int LocationId { get; set; }
	public string Location { get; set; }
	public string Parameter { get; set; }
	public decimal Value { get; set; }
	public string Unit { get; set; }
	public string Country { get; set; }
	public string City { get; set; }
	public DateTime? MeasurementDate { get; set; }
}
