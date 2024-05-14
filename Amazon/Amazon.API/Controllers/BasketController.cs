using Amazon.API.Dto;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IUnitOfWork _unitofwork;
		private readonly IMapper mapper;

		public BasketController(IUnitOfWork unitofwork,IMapper mapper)
        {
			_unitofwork = unitofwork;
			this.mapper = mapper;
		}
		[HttpGet("get-basket/:id")]
		public async Task<IActionResult> GetBasketById(string id)
		{
			var _basket =await _unitofwork.BasketRepository.GetBasketAsync(id);
			return Ok(_basket?? new CustomerBasket());

		}
		[HttpPost("update-basket")]
		public async Task<IActionResult> UpdateBasket(CustomerBasketDto basket)
		{
			var result = mapper.Map<CustomerBasketDto, CustomerBasket>(basket);	

			var _basket = await _unitofwork.BasketRepository.UpdateBasketAsync(result);
			return Ok(_basket );

		}
		[HttpDelete("delete-basket/:id")]
		public async Task<IActionResult> DeleteBasket(string id)
		{
			return Ok(await _unitofwork.BasketRepository.DeleteBasketAsync(id));

		}
	}
}
