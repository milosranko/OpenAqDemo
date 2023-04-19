using OpenAq.Test.Web.Models;

namespace OpenAq.Test.Web.Services;

public interface IAqModelBuilderService
{
	Task<AqCountryViewModel> GetCountries();
	Task<AqCityViewModel> GetCities(string countryCode);
	Task<AqLocationViewModel> GetLocations(string countryCode, string city);
	Task<AqMeasurementViewModel> GetMeasurements(int locationId);
}