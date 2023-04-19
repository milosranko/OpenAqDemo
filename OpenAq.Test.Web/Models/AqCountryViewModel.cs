using System.ComponentModel.DataAnnotations;

namespace OpenAq.Test.Web.Models;

public class AqCountryViewModel
{
	public string CountriesLabel { get; set; } = "Please select country";
	public string SubmitLabel { get; set; } = "Submit";
	public IEnumerable<CountryViewModel> CountriesDropDownList { get; set; } = Enumerable.Empty<CountryViewModel>();
	[Required(ErrorMessage = "Country must be selected")]
	public string? SelectedCountryCode { get; set; }
}
