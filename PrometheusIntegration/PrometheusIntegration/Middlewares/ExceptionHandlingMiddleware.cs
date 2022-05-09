using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PrometheusIntegration.Middlewares
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionHandlingMiddleware> logger;

		public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			this.next = next;
			this.logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, ex.Message);
				HandleInternalException(httpContext);
			}
		}



		private void HandleInternalException(HttpContext context)
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		}
	}
}
