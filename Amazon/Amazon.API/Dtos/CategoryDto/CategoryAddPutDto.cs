using Amazon.API.Dtos.ProductDto;

namespace Amazon.API.Dtos.CategoryDto
{
	public class BaseCategory
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
	public class CategoryAddPutDto: BaseCategory
	{

	}
	public class CategoryGetDto : BaseCategory
	{
		public int Id { get; set; }

	}
	public class CategoryGetAllWithDataDto : BaseCategory
	{
		public int Id { get; set; }
		public List<ProductForCategoryGet> Products { get; set; }

	}
}
