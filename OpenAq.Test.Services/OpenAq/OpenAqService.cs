using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OpenAq.Test.Abstractions.Interfaces;
using OpenAq.Test.Integrations.Abstractions.Exceptions;
using OpenAq.Test.Integrations.Abstractions.Models.Dto;
using OpenAq.Test.Integrations.Abstractions.Models.Dto.Base;
using OpenAq.Test.Integrations.Services.HttpClients;
using OpenAq.Test.Integrations.Services.OpenAq.Mappers;
using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using OpenAq.Test.Integrations.Services.OpenAq.Models.v2;
using System.Net.Http.Json;

namespace OpenAq.Test.Integrations.Services.OpenAq;

public class OpenAqService : IAirQualityService
{
	private const string CountriesApiPath = "/v2/countries";
	private const string CitiesApiPath = "/v2/cities";
	private const string LocationsApiPath = "/v2/locations";
	private const string MeasurementsApiPath = "/v2/measurements";
	private const string CountriesCacheKey = "countries";
	private const string CitiesCacheKey = "cities_{0}";
	private const string LocationsCacheKey = "locations_{0}_{1}";
	private const string MeasurementsCacheKey = "measurements_{0}";

	private readonly MemoryCacheEntryOptions _longCacheExpiration = new MemoryCacheEntryOptions()
		.SetSlidingExpiration(TimeSpan.FromSeconds(60))
		.SetAbsoluteExpiration(TimeSpan.FromDays(1));
	private readonly MemoryCacheEntryOptions _shortCacheExpiration = new MemoryCacheEntryOptions()
		.SetSlidingExpiration(TimeSpan.FromSeconds(60))
		.SetAbsoluteExpiration(TimeSpan.FromHours(1));
	private readonly IMemoryCache _cache;
	private readonly ILogger<OpenAqService> _logger;

	public OpenAqService(IMemoryCache cache, ILogger<OpenAqService> logger)
	{
		_cache = cache;
		_logger = logger;
	}

	public async Task<Response<CityDto>> GetCities(string countryCode)
	{
		var cacheKey = string.Format(CitiesCacheKey, countryCode);

		if (_cache.TryGetValue<Response<CityDto>>(cacheKey, out var cached))
		{
			if (cached != null && cached.Total > 0)
				return cached;
		}

		try
		{
			_logger.LogInformation($"{nameof(GetCities)} method, getting data from OpenAq API");

			var url = $"{CitiesApiPath}?limit=100&page=1&offset=0&sort=asc&country_id={countryCode}&order_by=city";
			var res = await OpenAqClient.Instance.GetFromJsonAsync<ApiResponse<City>>(url);

			_logger.LogInformation($"{nameof(GetCities)} method, data received from OpenAq API");

			if (res != null && res.Meta.Found > 0)
			{
				var mapped = res.Map<City, CityDto>();
				_cache.Set(cacheKey, mapped, _longCacheExpiration);

				return mapped;
			}
		}
		catch (Exception e)
		{
			throw new AirQualityException($"Error: {nameof(GetCities)}, {nameof(countryCode)}: {countryCode}", e);
		}

		return Response.Empty<CityDto>();
	}

	public async Task<Response<CountryDto>> GetCountries()
	{
		if (_cache.TryGetValue<Response<CountryDto>>(CountriesCacheKey, out var cached))
		{
			if (cached != null && cached.Total > 0)
				return cached;
		}

		try
		{
			_logger.LogInformation($"{nameof(GetCountries)} method, getting data from OpenAq API");

			var res = await OpenAqClient.Instance.GetFromJsonAsync<ApiResponse<Country>>(CountriesApiPath);

			_logger.LogInformation($"{nameof(GetCountries)} method, data received from OpenAq API");

			if (res != null && res.Meta.Found > 0)
			{
				var mapped = res.Map<Country, CountryDto>();
				_cache.Set(CountriesCacheKey, mapped, _longCacheExpiration);

				return mapped;
			}
		}
		catch (Exception e)
		{
			throw new AirQualityException($"Error: {nameof(GetCountries)}", e);
		}

		return Response.Empty<CountryDto>();
	}

	public async Task<Response<LocationDto>> GetLocations(string countryCode, string city, string[]? parameters = null)
	{
		var cacheKey = string.Format(LocationsCacheKey, countryCode, city);

		if (_cache.TryGetValue<Response<LocationDto>>(cacheKey, out var cached))
		{
			if (cached != null && cached?.Total > 0)
				return cached;
		}

		try
		{
			_logger.LogInformation($"{nameof(GetLocations)} method, getting data from OpenAq API");

			var url = $"{LocationsApiPath}?limit=100&page=1&offset=0&sort=asc&country_id={countryCode}&city={city}&order_by=lastUpdated";
			var res = await OpenAqClient.Instance.GetFromJsonAsync<ApiResponse<Location>>(url);

			_logger.LogInformation($"{nameof(GetLocations)} method, data received from OpenAq API");

			if (res != null && res.Meta.Found > 0)
			{
				var mapped = res.Map<Location, LocationDto>();
				_cache.Set(cacheKey, mapped, _longCacheExpiration);

				return mapped;
			}
		}
		catch (Exception e)
		{
			throw new AirQualityException($"Error: {nameof(GetLocations)}, {nameof(countryCode)}: {countryCode}, {nameof(city)}: {city}", e);
		}

		return Response.Empty<LocationDto>();
	}

	public async Task<Response<MeasurementDto>> GetMeasurements(int locationId, string[]? parameters = null)
	{
		var cacheKey = string.Format(MeasurementsCacheKey, locationId);

		if (_cache.TryGetValue<Response<MeasurementDto>>(cacheKey, out var cached))
		{
			if (cached != null && cached.Total > 0)
				return cached;
		}

		try
		{
			_logger.LogInformation($"{nameof(GetMeasurements)} method, getting data from OpenAq API");

			var url = $"{MeasurementsApiPath}?limit=100&page=1&offset=0&sort=desc&location_id={locationId}";
			var res = await OpenAqClient.Instance.GetFromJsonAsync<ApiResponse<Measurement>>(url);

			_logger.LogInformation($"{nameof(GetMeasurements)} method, data received from OpenAq API");

			if (res != null && res.Meta.Found > 0)
			{
				var mapped = res.Map<Measurement, MeasurementDto>();
				_cache.Set(cacheKey, mapped, _shortCacheExpiration);

				return mapped;
			}
		}
		catch (Exception e)
		{
			throw new AirQualityException($"Error: {nameof(GetMeasurements)}, {nameof(locationId)}: {locationId}", e);
		}

		return Response.Empty<MeasurementDto>();
	}
}
