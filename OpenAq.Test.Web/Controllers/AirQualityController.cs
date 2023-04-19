using Microsoft.AspNetCore.Mvc;
using OpenAq.Test.Web.Models;
using OpenAq.Test.Web.Services;
using System.Web;

namespace OpenAq.Test.Web.Controllers;
public class AirQualityController : Controller
{
	private readonly IAqModelBuilderService _measurementsService;

	public AirQualityController(IAqModelBuilderService measurementsService)
	{
		_measurementsService = measurementsService;
	}

	public async Task<IActionResult> Index()
	{
		var model = await _measurementsService.GetCountries();

		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Index(AqCountryViewModel model)
	{
		if (!ModelState.IsValid)
		{
			model = await _measurementsService.GetCountries();
			return View(model);
		}

		return RedirectToAction("City", "AirQuality", new { countryCode = model.SelectedCountryCode });
	}


	public async Task<IActionResult> City(string countryCode)
	{
		if (string.IsNullOrEmpty(countryCode))
		{
			throw new Exception("Country code must be provided");
		}

		var model = await _measurementsService.GetCities(countryCode);

		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> City(AqCityViewModel model)
	{
		if (!ModelState.IsValid)
		{
			model = await _measurementsService.GetCities(model.SelectedCountryCode);
			return View(model);
		}

		return RedirectToAction("Location", "AirQuality", new { countryCode = model.SelectedCountryCode, city = HttpUtility.UrlEncode(model.SelectedCity) });
	}

	public async Task<IActionResult> Location(string countryCode, string city)
	{
		if (string.IsNullOrEmpty(countryCode) || string.IsNullOrEmpty(city))
		{
			throw new Exception("Country code or city name not provided");
		}

		var model = await _measurementsService.GetLocations(countryCode, HttpUtility.UrlDecode(city));

		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Location(AqLocationViewModel model)
	{
		if (!ModelState.IsValid)
		{
			model = await _measurementsService.GetLocations(model.SelectedCountryCode, model.SelectedCityName);
			return View(model);
		}

		return RedirectToAction("Measurement", "AirQuality", new { locationId = model.SelectedLocation });
	}

	public async Task<IActionResult> Measurement(int locationId)
	{
		var model = await _measurementsService.GetMeasurements(locationId);

		return View(model);
	}
}
