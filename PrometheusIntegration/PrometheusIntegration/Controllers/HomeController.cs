using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrometheusIntegration.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrometheusIntegration.Controllers
{
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
		public IActionResult Error()
		{
			var problem = new ProblemDetails
			{
				Title = "Internal Application Error",
				Status = 500
			};

			return StatusCode(problem.Status ?? 500, problem);
		}
	}
}
