using System.ComponentModel.DataAnnotations;

namespace OpenAq.Test.Web.Models;

public class AqLocationViewModel
{
	public string SelectedCountryLabel { get; set; } = "Selected country:";
	public string SelectedCityLabel { get; set; } = "Selected city:";
	[Required(ErrorMessage = "Country is required")]
	public string? SelectedCountryCode { get; set; }
	[Required(ErrorMessage = "City is required")]
	public string? SelectedCityName { get; set; }
	public string? SelectedCountryName { get; set; }
	public string SubmitLabel { get; set; } = "Submit";
	public string LocationLabel { get; set; } = "Please select location";
	public IEnumerable<LocationViewModel> Locations { get; set; } = Enumerable.Empty<LocationViewModel>();
	[Required(ErrorMessage = "Location must be selected")]
	public string? SelectedLocation { get; set; }
}
