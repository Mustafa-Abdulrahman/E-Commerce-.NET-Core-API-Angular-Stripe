
using Amazon.API.Dtos.CategoryDto;
using Amazon.Core.Entities;
using AutoMapper;

namespace Amazon.API.Dtos.MappingFiles
{
	public class MappingCategory:Profile

	{
        public MappingCategory()
        {
            CreateMap<Category,CategoryAddPutDto>().ReverseMap();
            CreateMap<Category, CategoryGetAllWithDataDto>().ReverseMap();
		}
    }
}
