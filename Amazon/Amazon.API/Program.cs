using Amazon.API.Extentions;
using Amazon.API.Middleware;
using Amazon.Core.Interfaces;
using Amazon.Core.Services;
using Amazon.Infrasructure;
using Amazon.Infrasructure.Repository;
using StackExchange.Redis;
using System.Reflection;
namespace Amazon.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddApiRegestration();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// CORS
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
				});
			});
			 

			
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.InfrastructureConfigration(builder.Configuration);

			builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
			{
				var cinfigure = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
				return ConnectionMultiplexer.Connect(cinfigure);
			});
			// CONFIGURE ORDER SERVICE
			builder.Services.AddScoped<IOrderServices, OrderServices>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseMiddleware<ExceptionMiddleware>();
			//Redirect In Any Error With Status Code
			app.UseStatusCodePagesWithReExecute("/errors/{0}");
			app.UseHttpsRedirection();
			app.UseCors("CorsPolicy");
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();
			InfrastructrureRegiteration.InfrastructureConfigMiddleware(app);
			app.Run();
		}
	}
}
