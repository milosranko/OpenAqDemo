namespace OpenAq.Test.Web.Models;

public class MeasurementViewModel
{
	public string Parameter { get; set; }
	public string Unit { get; set; }
	public decimal Value { get; set; }
	public DateTime? Date { get; set; }
}
