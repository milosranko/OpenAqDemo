using System.ComponentModel.DataAnnotations;

namespace OpenAq.Test.Web.Models;

public class AqCityViewModel
{
	public string SelectedCountryLabel { get; set; } = "Selected country:";
	[Required(ErrorMessage = "Country is required")]
	public string SelectedCountryCode { get; set; }
	public string? SelectedCountryName { get; set; }
	public string SubmitLabel { get; set; } = "Submit";
	public string CityLabel { get; set; } = "Please select city";
	public IEnumerable<string> Cities { get; set; } = Enumerable.Empty<string>();
	[Required(ErrorMessage = "City must be selected")]
	public string? SelectedCity { get; set; }
}
