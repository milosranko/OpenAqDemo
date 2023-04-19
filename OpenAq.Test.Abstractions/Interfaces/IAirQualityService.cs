using OpenAq.Test.Integrations.Abstractions.Models.Dto;
using OpenAq.Test.Integrations.Abstractions.Models.Dto.Base;

namespace OpenAq.Test.Abstractions.Interfaces;

public interface IAirQualityService
{
	public Task<Response<CountryDto>> GetCountries();
	public Task<Response<CityDto>> GetCities(string countryCode);
	public Task<Response<LocationDto>> GetLocations(string countryId, string city, string[]? parameters = null);
	public Task<Response<MeasurementDto>> GetMeasurements(int locationId, string[]? parameters = null);
}