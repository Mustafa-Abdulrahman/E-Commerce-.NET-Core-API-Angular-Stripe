using Amazon.API.Dto;
using Amazon.Core.Entities;
using AutoMapper;

namespace Amazon.API.Mapping_Profile
{
	public class MappingBasket:Profile
	{
		public MappingBasket() { 
		CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
			CreateMap<BasketItem,BasketItemDto>().ReverseMap();
		}
	}
}
