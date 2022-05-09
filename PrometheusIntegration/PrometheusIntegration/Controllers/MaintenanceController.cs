using System;
using Microsoft.AspNetCore.Mvc;

namespace PrometheusIntegration.Controllers
{
	public class MaintenanceController: ControllerBase
	{
		[HttpGet]
		[Route("maintenance/ping")]
		public IActionResult Ping()
		{
			return Ok("pong");
		}

		[HttpGet]
		[Route("maintenance/testerror")]
		public IActionResult testerror()
		{
			throw new NullReferenceException("TEST");
		}
    }
}
