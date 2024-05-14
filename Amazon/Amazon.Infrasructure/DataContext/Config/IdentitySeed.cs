using Amazon.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.DataContext.Config
{
	public class IdentitySeed
	{
		public static async Task SeedUserAsync(UserManager<AppUser> userManager)
		{
			if (!userManager.Users.Any())
			{
				//create new user
				var user = new AppUser
				{
					DisplayName = "Ali",
					Email = "ali@ali.com",
					UserName = "ali@ali.com",
					Adress = new Adress
					{
						FirstName = "ali",
						LasttName = "mohamed",
						City = "Giza",
						Satate = "haram",
						Street = "test street",
						ZibCode = "123"

					}
				};
				await userManager.CreateAsync(user, "P@$$w0rd");
			}
		}
	}
}
