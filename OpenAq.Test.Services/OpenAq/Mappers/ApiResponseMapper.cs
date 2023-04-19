using OpenAq.Test.Integrations.Abstractions.Models.Dto;
using OpenAq.Test.Integrations.Abstractions.Models.Dto.Base;
using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

namespace OpenAq.Test.Integrations.Services.OpenAq.Mappers;

internal static class ApiResponseMapper
{
	public static Response<T2> Map<T1, T2>(this ApiResponse<T1> apiRes)
		where T1 : OpenAqModelBase
		where T2 : class
	{
		if (apiRes == null) return Response.Empty<T2>();

		return new Response<T2>
		{
			Page = apiRes.Meta.Page,
			PageSize = apiRes.Meta.Limit,
			Total = apiRes.Meta.Found,
			Results = apiRes.Results.Select(x => x.Map<T2>()).ToArray()
		};
	}

	public static T? Map<T>(this OpenAqModelBase model) where T : class
	{
		if (model == null) throw new ArgumentNullException(nameof(model));

		return model switch
		{
			Country country => new CountryDto
			{
				Code = country.Code,
				LastUpdated = country.LastUpdated,
				Name = country.Name,
				Parameters = country.Parameters
			} as T,
			City city => new CityDto
			{
				CountryName = city.Country,
				LastUpdated = city.LastUpdated,
				Name = city.Name,
				Parameters = city.Parameters
			} as T,
			Location location => new LocationDto
			{
				Id = location.Id,
				LastUpdated = location.LastUpdated,
				Name = location.Name,
				City = location.City,
				Country = location.Country
			} as T,
			Measurement measurement => new MeasurementDto
			{
				City = measurement.City,
				Country = measurement.Country,
				Location = measurement.Location,
				LocationId = measurement.LocationId,
				MeasurementDate = measurement.MeasurementDate?.Utc,
				Parameter = measurement.Parameter,
				Unit = measurement.Unit,
				Value = measurement.Value
			} as T,
			_ => default,
		};
	}
}
