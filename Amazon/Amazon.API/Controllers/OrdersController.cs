﻿
using Amazon.API.Dtos;
using Amazon.API.Errors;
using Amazon.Core.Entities.oders;
using Amazon.Core.Interfaces;
using Amazon.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Amazon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class OrdersController:ControllerBase
	{
		private readonly IUnitOfWork _uOW;
		private readonly IOrderServices _orderServices;
		private readonly IMapper _mapper;

		public OrdersController(IUnitOfWork UOW, IOrderServices orderServices, IMapper mapper)
		{
			_uOW = UOW;
			_orderServices = orderServices;
			_mapper = mapper;
		}

		[HttpPost("create-order")]
		public async Task<ActionResult<Order>> CreateOrder(OrderDto orderdto)
		{
			var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

			var address = _mapper.Map<AdressDto, ShipAddress>(orderdto.ShipToAddress);

			var order = await _orderServices.CreateOrderAsync(email, orderdto.DeliveryMethodId, orderdto.BasketId, address);

			if (order is null) return BadRequest(new BaseCommonResponse(400, "Error While Creating Order"));

			return Ok(order);

		}
		[HttpGet("get-orders-for-user")]
		public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
		{
			var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
			var order = await _orderServices.GetOrdersForUserAsync(email);
			var result = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(order);
			return Ok(result);
		}
		[HttpGet("get-order-by-id/{id}")]
		public async Task<ActionResult<OrderToReturnDto>> GetOrderById(int id)
		{
			var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
			var order = await _orderServices.GetOrderByIdAsync(id, email);
			if (order is null) return NotFound(new BaseCommonResponse(404));
			var result = _mapper.Map<Order, OrderToReturnDto>(order);
			return Ok(result);
		}
		[HttpGet("get-delivery-methods")]
		public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
		{
			return Ok(await _orderServices.GetDeliveryMethodsAsync());
		}
	}
}
