using Amazon.API.Errors;
using System.Net;
using System.Text.Json;

namespace Amazon.API.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionMiddleware> logger;
		private readonly IHostEnvironment hostEnviroment;

		public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment hostEnviroment)
        {
			this.next = next;
			this.logger = logger;
			this.hostEnviroment = hostEnviroment;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await next(context);
				logger.LogInformation("Success");
			}catch (Exception e) {
				logger.LogError(e,$"This Error Come Form Exception Middle Ware {e.Message}!");
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType = "application/json";
				var response =hostEnviroment.IsDevelopment()? 
					new ApiException(e.StackTrace.ToString(),(int)HttpStatusCode.InternalServerError, e.Message)
					: new ApiException(e.StackTrace.ToString(), (int)HttpStatusCode.InternalServerError);

				var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
				var json = JsonSerializer.Serialize(response);
				await context.Response.WriteAsync(json);
			}

		}
    }
}
