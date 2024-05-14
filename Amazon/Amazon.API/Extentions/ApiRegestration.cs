using Microsoft.AspNetCore.Mvc;
using Amazon.API.Errors;
namespace Amazon.API.Extentions
{
	public static class ApiRegestration
	{
		public static IServiceCollection AddApiRegestration(this IServiceCollection services)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var errorResponse = new ApiValidationErrorRespone
					{
						Errors = context.ModelState.Where(x => x.Value.Errors.Count > 0)
						.SelectMany(x => x.Value.Errors)
						.Select(x => x.ErrorMessage).ToArray()
					};
					return new BadRequestObjectResult(errorResponse);
				};
			});

			// Cors For Client Side
			
			
			return services;
		}
	}
}
