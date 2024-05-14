using Amazon.API.Dtos;
using Amazon.Core.Entities;
using Amazon.Core.Entities.oders;
using AutoMapper;

namespace Amazon.API.Mapping_Profile
{
	public class MappingUser : Profile
	{
		public MappingUser()
		{
			CreateMap<Adress, AdressDto>().ReverseMap();
			CreateMap<ShipAddress, AdressDto>().ReverseMap();

		}
	}
}
