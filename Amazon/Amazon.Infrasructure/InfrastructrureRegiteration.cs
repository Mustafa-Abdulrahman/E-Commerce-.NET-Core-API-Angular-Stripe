using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Amazon.Core.Services;
using Amazon.Infrasructure.DataContext;
using Amazon.Infrasructure.DataContext.Config;
using Amazon.Infrasructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure
{
    public static class InfrastructrureRegiteration
	{

		// it has service in program file in api
		public static IServiceCollection InfrastructureConfigration(this IServiceCollection services, IConfiguration configration)
		{
			//Configure Token Services 
			services.AddScoped<ITokenService, TokenService>();
			//Configure Payment Gateway 
			services.AddScoped<IPaymentServices, PaymentServices>();
			// genneric
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			//connection string
			services.AddDbContext<ApplicationDbContext>(option =>
			{
				option.UseSqlServer(configration.GetConnectionString("cs"));
			});
			
			// Configure Identity
			services.AddIdentity<AppUser, IdentityRole>()
			   .AddEntityFrameworkStores<ApplicationDbContext>()
			   .AddDefaultTokenProviders();
			services.AddMemoryCache();
			services.AddAuthentication(option =>
			{
				option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

			})
				.AddJwtBearer(opt =>
				{
					opt.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configration["Token:Key"])),
						ValidIssuer = configration["Token:Issuer"],
						ValidateIssuer = true,
						ValidateAudience = false
					};
				});
			return services;

		}
		public static async void InfrastructureConfigMiddleware(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				await IdentitySeed.SeedUserAsync(userManager);
			}
		}

		//public static async void InfrastructureConfigMiddleware(this IServiceCollection services)
		//{
		//	var serviceProvider = services.BuildServiceProvider();
		//	using (var scope = serviceProvider.CreateScope())
		//	{
		//		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
		//		await IdentitySeed.SeedUserAsync(userManager);
		//	}
		//}
	}
}
