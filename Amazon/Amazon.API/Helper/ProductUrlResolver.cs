using Amazon.API.Dtos.ProductDto;
using Amazon.Core.Entities;
using AutoMapper;

namespace Amazon.API.Helper
{
	public class ProductUrlResolver : IValueResolver<Product, ProductGetDto, string>
	{
		private readonly IConfiguration _config;

		public ProductUrlResolver(IConfiguration config)
		{
			_config = config;
		}
		public string Resolve(Product source, ProductGetDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.Image))
			{
				return _config["ApiURl"] + source.Image;
			}
			return null;
		}
	}
}
