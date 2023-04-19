using System.ComponentModel.DataAnnotations;

namespace OpenAq.Test.Web.Models;

public class AqMeasurementViewModel
{
	public string SelectedCountryLabel { get; set; } = "Selected country:";
	public string SelectedCityLabel { get; set; } = "Selected city:";
	public string SelectedLocationLabel { get; set; } = "Selected location:";
	[Required(ErrorMessage = "Country is required")]
	public string SelectedCountryCode { get; set; }
	public string SelectedCountryName { get; set; }
	[Required(ErrorMessage = "City is required")]
	public string SelectedCityName { get; set; }
	[Required(ErrorMessage = "Location is required")]
	public int SelectedLocationId { get; set; }
	public string SelectedLocationName { get; set; }
	public IEnumerable<MeasurementViewModel> Measurements { get; set; } = Enumerable.Empty<MeasurementViewModel>();
}
