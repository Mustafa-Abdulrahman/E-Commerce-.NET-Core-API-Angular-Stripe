using Amazon.API.Dtos;
using Amazon.Core.Entities.oders;
using AutoMapper;

namespace Amazon.API.Helper
{
	public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
	{
		private readonly IConfiguration _config;

		public OrderItemUrlResolver(IConfiguration config)
		{
			_config = config;
		}
		public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.ProductItemOrderd.PictureUrl))
			{
				return _config["ApiURl"] + source.ProductItemOrderd.PictureUrl;
			}
			return null;
		}
	}
}
