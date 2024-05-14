using Amazon.Core.Entities;
using Amazon.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.Repository
{
    public class TokenService : ITokenService
	{
		private readonly IConfiguration _config;
		private readonly SymmetricSecurityKey _key;
		public TokenService(IConfiguration config)
        {
			_config = config;
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
		}
        public string CreateToken(AppUser appuser)
		{
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Email,appuser.Email),
				new Claim(JwtRegisteredClaimNames.GivenName,appuser.DisplayName),

			};
			var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(10),
				Issuer = _config["Token:Issuer"],
				SigningCredentials = creds
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token  = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
