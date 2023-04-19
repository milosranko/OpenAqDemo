using OpenAq.Test.Abstractions.Interfaces;
using OpenAq.Test.Web.Models;

namespace OpenAq.Test.Web.Services;

public class AqModelBuilderService : IAqModelBuilderService
{
	private readonly IAirQualityService _openAqService;

	public AqModelBuilderService(IAirQualityService openAqService)
	{
		_openAqService = openAqService;
	}

	public async Task<AqCountryViewModel> GetCountries()
	{
		var res = await _openAqService.GetCountries();
		var countries = res.Results
			.Select(x => new CountryViewModel { Code = x.Code, Name = x.Name })
			.ToList();

		countries.Insert(0, new CountryViewModel { Code = string.Empty, Name = string.Empty });

		var model = new AqCountryViewModel
		{
			CountriesDropDownList = countries
		};

		return model;
	}

	public async Task<AqCityViewModel> GetCities(string countryCode)
	{
		var countries = await _openAqService.GetCountries();
		var country = countries.Results.SingleOrDefault(x => x.Code.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase)) ?? throw new Exception("Invalid country code");
		var res = await _openAqService.GetCities(countryCode);
		var model = new AqCityViewModel
		{
			SelectedCountryCode = countryCode,
			SelectedCountryName = country.Name,
			Cities = res.Results.Select(x => x.Name)
		};

		return model;
	}

	public async Task<AqLocationViewModel> GetLocations(string countryCode, string city)
	{
		var countries = await _openAqService.GetCountries();
		var country = countries.Results.SingleOrDefault(x => x.Code.Equals(countryCode, StringComparison.InvariantCultureIgnoreCase)) ?? throw new Exception("Invalid country code");
		var res = await _openAqService.GetLocations(countryCode, city);
		var model = new AqLocationViewModel
		{
			SelectedCountryCode = countryCode,
			SelectedCountryName = country.Name,
			SelectedCityName = city,
			Locations = res.Results.Select(x => new LocationViewModel
			{
				Id = x.Id,
				Name = x.Name
			})
		};

		return model;
	}

	public async Task<AqMeasurementViewModel> GetMeasurements(int locationId)
	{
		var res = await _openAqService.GetMeasurements(locationId);
		var countries = await _openAqService.GetCountries();
		var model = new AqMeasurementViewModel
		{
			SelectedCityName = res.Results.First().City,
			SelectedCountryCode = res.Results.First().Country,
			SelectedCountryName = countries.Results.Single(x => x.Code.Equals(res.Results.First().Country, StringComparison.InvariantCultureIgnoreCase)).Name,
			SelectedLocationId = locationId,
			SelectedLocationName = res.Results.First().Location,
			Measurements = res.Results.Select(x => new MeasurementViewModel
			{
				Value = x.Value,
				Date = x.MeasurementDate,
				Parameter = x.Parameter,
				Unit = x.Unit
			})
		};

		return model;
	}
}
