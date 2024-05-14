using Amazon.API.Dtos;
using Amazon.API.Errors;
using Amazon.API.Extentions;
using Amazon.Core.Entities;
using Amazon.Core.Services;
using Amazon.Infrasructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;

namespace Amazon.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenService _tokenservice;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenservice)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenservice = tokenservice;
		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var user = await _userManager.FindByEmailAsync(dto.Email);
			if (user == null)
				return Unauthorized(new BaseCommonResponse(401));
			var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
			if (result is null || result.Succeeded == false)
				return Unauthorized(new BaseCommonResponse(401));
			return Ok(new UserDto
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = _tokenservice.CreateToken(user)

			});
			;
		}
		[HttpPost("Register")]
		public async Task<IActionResult> Register(RegisterDto dto)
		{
			if (CheckEmailExist(dto.Email).Result.Value)
			{
				return new BadRequestObjectResult(new ApiValidationErrorRespone { Errors = new[]{ "This Email Already Exist" } });
			}
			var user = new AppUser
			{
				DisplayName = dto.DisplayName,
				UserName = dto.Email,
				Email = dto.Email,
			};
			var result = await _userManager.CreateAsync(user, dto.Password);
			if (result.Succeeded == false)
				return BadRequest(new BaseCommonResponse(400));
			return Ok(new UserDto
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = _tokenservice.CreateToken(user)
			});
		}

		[Authorize]
		[HttpGet("myPlace")]
		public ActionResult<string> myPlace()
		{

			return "sad";
		}

		[Authorize]
		[HttpGet("get-current-user")]
		public async Task<IActionResult> GetCurrentUser()
		{
			//var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			//var user = await _userManager.FindByEmailAsync(email);
			var user = await _userManager.FindEmailByClaimPrincipal(HttpContext.User);

			return Ok(new UserDto
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = _tokenservice.CreateToken(user)
			});


		}
		[HttpGet("check-email-exist")]
		public async Task<ActionResult<bool>> CheckEmailExist([FromQuery] string email)
		{
			var result = await _userManager.FindByEmailAsync(email);
			if(result is not null)
			{
				return true;
			}
			return false;
		}
		[Authorize]
		[HttpGet("get-user-address")]
		public async Task<IActionResult> GetUserAddress()
		{
			//var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			//var user = await _userManager.Users.Include(x=>x.Adress).FirstOrDefaultAsync(x=>x.Email == email);
			var user = await _userManager.FindUserByClaimPrincipalWithAddress(HttpContext.User);

			if (user.Adress is not null) {
				var _result = new AdressDto
				{
					FirstName = user.Adress.FirstName,
					LastName = user.Adress.LasttName,
					Street = user.Adress.Street,
					City = user.Adress.City,
					State = user.Adress.Satate,
					ZipCode = user.Adress.ZibCode,
				};
			return Ok(_result);
			}
			return NoContent();
		}

		 [Authorize]
        [HttpPut("update-user-address")]
        public async Task<IActionResult> UpdateUserAddress(AdressDto dto)
        {
            var user = await _userManager.FindUserByClaimPrincipalWithAddress(HttpContext.User);

				user.Adress.FirstName = dto.FirstName;
				user.Adress.LasttName = dto.LastName;
				user.Adress.Street = dto.Street;
				user.Adress.City = dto.City;
				user.Adress.Satate = dto.State;
				user.Adress.ZibCode = dto.ZipCode;
				
			var result =await _userManager.UpdateAsync(user);
            if (result.Succeeded)
			{
				var _result = new AdressDto
				{
					FirstName = user.Adress.FirstName,
					LastName = user.Adress.LasttName,
					Street = user.Adress.Street,
					City = user.Adress.City,
					State = user.Adress.Satate,
					ZipCode = user.Adress.ZibCode,
				};
				return Ok(_result);
			}

            return BadRequest($"problem while updating this user {HttpContext.User}");
        }
	}
}
