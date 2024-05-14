using Amazon.API.Dtos.ProductDto;
using Amazon.API.Errors;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductsController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		[HttpGet("getAllProductWithData")]
		public async Task<ActionResult> GetAllProductsWithData(string search,string sort,int page)
		{
			var AllProducts = await _unitOfWork.ProductRepository.GetAllWithDataAsync(x=>x.Category);
			if (AllProducts is null)
				return NotFound(new BaseCommonResponse(404));

			var result = AllProducts.Select(x => new ProductGetWithDataDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Price = x.Price,
				CategoryName = x.Category.Name,
				Image=x.Image,
			}
			);
			switch(sort)
			{
				case "PriceAsync":
					result=result.OrderBy(x => x.Price);
					break;

				case "PriceDesc":
					result = result.OrderByDescending(x => x.Price);
					break;
				default:
					result = result.OrderBy(x => x.Name);
					break;
			}
			if(page > 0 && page.GetType() == typeof(int))

				result = result.Skip((page * 15) - 15).Take(15);
			if(search is not null)
				result = result.Where(x => x.Name.ToLower().StartsWith(search.ToLower()));
			return Ok(result);
		}

		#region get All With No Data
		[HttpGet("getAllProductWithNoData")]
		public async Task<ActionResult> GetAllProductsWithNoData(int? categoryId,string search, string sort,int page)
		{
			var AllProducts =await _unitOfWork.ProductRepository.GetAllAsync(categoryId);
			if (AllProducts is null)
				return NotFound(new BaseCommonResponse(404));
			var result = AllProducts.Select(x => new ProductGetDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Price = x.Price,
				Image = x.Image,

			}
			);
			switch (sort)
			{
				case "PriceAsync":
					result = result.OrderBy(x => x.Price);
					break;

				case "PriceDesc":
					result = result.OrderByDescending(x => x.Price);
					break;
				default:
					result = result.OrderBy(x => x.Name);
					break;
			}
			if(page > 0 && page.GetType() == typeof(int))
			result = result.Skip((page * 15) - 15).Take(15);
			if (search is not null)
				result = result.Where(x => x.Name.ToLower().StartsWith(search.ToLower()));
			return Ok(result);
		}
		#endregion

		#region Get By Id With Data
		[HttpGet("getProductByIdWithData/:id")]
		public async Task<ActionResult> GetProductDetailsWithData(int id)
		{
			var product =await _unitOfWork.ProductRepository.GetByIdWithDataAsync(id,x=>x.Category);
			if (product is null)
				return NotFound($"The Product With Id {id} Not Found");

			var retult = new ProductGetWithDataDto()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				CategoryName = product.Category.Name,
				Image = product.Image,
			};
			return Ok(retult);	
		}
		#endregion

		#region Get By Id With No Data
		[HttpGet("getProductByIdWithNoData/:id")]
		public async Task<ActionResult> GetProductDetailsNoData(int id)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
			if (product is null)
				return NotFound($"The Product With Id {id} Not Found");

			var retult = new ProductGetDto()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Image = product.Image,
			};
			return Ok(retult);
		}
		#endregion
		#region Add Product
		[HttpPost("AddProduct")]
		public async Task<ActionResult> ProductAdd(ProductAddDto _pro)
		{
			try
			{
				if(ModelState.IsValid)
				{
					Product newPro = new()
					{
						Name = _pro.Name,
						Description = _pro.Description,
						Price = _pro.Price,
						CategoryId = _pro.CategoryId,
						Image = _pro.Image,
					};
					await _unitOfWork.ProductRepository.AddAsync(newPro);
					return Ok(_pro);
				}
				return BadRequest(new BaseCommonResponse(400));
			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion

		#region update Product
		[HttpPut("updateProduct/:id")]
		public async Task<ActionResult> ProductUpdate(int id, ProductAddDto _pro)
		{
			try
			{
				var product =await _unitOfWork.ProductRepository.GetByIdAsync(id);
				if (product is null)
					return NotFound($"Product With Id {id} Not Found");

				if(ModelState.IsValid)
				{
					product.Name= _pro.Name;
					product.Description= _pro.Description;
					product.Price= _pro.Price;
					product.CategoryId= _pro.CategoryId;
					product.Image= _pro.Image;


					await _unitOfWork.ProductRepository.UpdateAsync(id,product);
					return Ok(_pro);
				}
				return BadRequest(new BaseCommonResponse(400));
			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion
		#region delete product
		[HttpDelete("deleteProduct/:id")]
		public async Task<ActionResult> ProductDelete(int id)
		{
			Product product =await _unitOfWork.ProductRepository.GetByIdAsync(id);
			if (product is null)
				return NotFound($"Product With Id {id} Not Found");
			await	_unitOfWork.ProductRepository.DeleteAsync(id);
			return Ok($"Product With Name {product.Name} Deleted Successfuly");
		}
		#endregion
	}
}
