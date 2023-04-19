﻿using Microsoft.AspNetCore.Mvc;
using OpenAq.Test.Web.Models;
using System.Diagnostics;

namespace OpenAq.Test.Web.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error(string? msg = "")
	{
		return View(new ErrorViewModel
		{
			RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
			Message = msg
		});
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public new IActionResult NotFound()
	{
		return View();
	}
}
