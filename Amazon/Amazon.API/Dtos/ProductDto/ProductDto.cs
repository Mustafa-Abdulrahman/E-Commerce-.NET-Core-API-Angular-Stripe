namespace Amazon.API.Dtos.ProductDto
{
	public class BaseClass
	{

		
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Image { get; set; }
		
	}
	public class ProductAddDto: BaseClass
	{
		public int CategoryId { get; set; }
	}
	
	public class ProductGetDto : BaseClass
	{
		public int Id { get; set; }
		


	}
	public class ProductGetWithDataDto : BaseClass
	{

		public int Id { get; set; }
	
		public string CategoryName { get; set; }
	}
	public class ProductForCategoryGet : BaseClass
	{

		public int Id { get; set; }

		public int CategoryId{ get; set; }
	}
}
