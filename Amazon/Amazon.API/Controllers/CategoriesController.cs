using Amazon.API.Dtos.CategoryDto;
using Amazon.API.Dtos.ProductDto;
using Amazon.API.Errors;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoriesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		[HttpGet("getAllCategoryWithData")]
		public async Task<ActionResult> GetAllCategoryWithData(string sort, int page)
		{
			var AllCategory = await _unitOfWork.CategoryRepository.GetAllWithDataAsync(x=>x.Products);

			


			if (AllCategory is null)
			{
				return NotFound(new BaseCommonResponse(404));
			}
			var result =AllCategory.Select(x => new CategoryGetAllWithDataDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Products = x.Products.Select(p => new ProductForCategoryGet
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Price = p.Price,
					CategoryId = p.CategoryId,
				}).Where(p => p.CategoryId == x.Id).ToList()


				

			});
			switch (sort)
			{
				case "NameAsync":
					result = result.OrderBy(x => x.Name).ToList();
					break;

				case "NameDesc":
					result = result.OrderByDescending(x => x.Name).ToList();
					break;
				default:
					result = result.OrderBy(x => x.Name).ToList();
					break;
			}
			result = result.Skip((page * 15) - 15).Take(15).ToList();
			return Ok(result);
		}


		[HttpGet("getAllCategoryWithNoData")]
		public async Task<ActionResult> GetAllCategoryWithNoData(string sort)
		{
			var AllCategory = await _unitOfWork.CategoryRepository.GetAllAsync();
			
			if (AllCategory is null)
			{
				return NotFound(new BaseCommonResponse(404));
			}

			//var result = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryGetDto>>(AllCategory);
			var result = AllCategory.Select(x => new CategoryGetDto
			{
				Name = x.Name,
				Description = x.Description,
				Id = x.Id,
			}
			).ToList();
			switch (sort)
			{
				case "NameAsync":
					result = result.OrderBy(x => x.Name).ToList();
					break;

				case "NameDesc":
					result = result.OrderByDescending(x => x.Name).ToList();
					break;
				default:
					result = result.OrderBy(x => x.Name).ToList();
					break;
			}
			return Ok(result);
		}
		[HttpGet("getCategoryDetailsWithData/:id")]
		public async Task<ActionResult> GetCategoryDetailsWithData(int id)
		{
			var Category = await _unitOfWork.CategoryRepository.GetByIdWithDataAsync(id,x=>x.Products);
			if(Category is null)
			{
				return NotFound($"The Category With Id {id} Not Found");
			}
			//CategoryGetAllWithDataDto returnCategory = _mapper.Map<Category, CategoryGetAllWithDataDto>(Category);

			
			CategoryGetAllWithDataDto returnCategory = new CategoryGetAllWithDataDto()
			{
				Id= id,
				Name = Category.Name,
				Description = Category.Description,
				Products = Category.Products.Select(p => new ProductForCategoryGet
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Price = p.Price,
					CategoryId = p.CategoryId,
				}).Where(p => p.CategoryId == Category.Id).ToList()
			};
			return Ok(returnCategory);
		}
		[HttpGet("getCategoryDetailsWithNoData/:id")]
		public async Task<ActionResult> GetCategoryDetailsWithNoData(int id)
		{
			var Category =await _unitOfWork.CategoryRepository.GetByIdAsync(id);
			if (Category is null)
			{
				return NotFound($"The Category With Id {id} Not Found");
			}
			CategoryGetDto returnCategory = _mapper.Map<Category, CategoryGetDto>(Category);

			//CategoryGetDto returnCategory = new CategoryGetDto()
			//{
			//	Id = id,
			//	Name = Category.Name,
			//	Description= Category.Description,
			//};
			return Ok(returnCategory);
		}

		#region addCategory
		[HttpPost("AddCategory")]
		public async Task<ActionResult> addNewCategory(CategoryAddPutDto cateDto)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var newCategiry = new Category()
					{
						Name = cateDto.Name,
						Description = cateDto.Description,
					};
					await _unitOfWork.CategoryRepository.AddAsync(newCategiry);
					return Ok(cateDto);
				}
				return BadRequest(new BaseCommonResponse(400));
			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion
		#region UpdateCtagroy
		[HttpPut("updateCtegory/:id")]
		public async Task<ActionResult> UpdateCategory(int id, CategoryAddPutDto cateDto)
		{
			try {
				var SelectedCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
				if (SelectedCategory is null)
				{
					return NotFound($"The Category With Id {id} Not Found");
				}
				if (ModelState.IsValid)
				{
					SelectedCategory.Name = cateDto.Name;
					SelectedCategory.Description = cateDto.Description;
					await _unitOfWork.CategoryRepository.UpdateAsync(id, SelectedCategory);
					return Ok(cateDto);
				}
				return BadRequest(new BaseCommonResponse(400));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion
		#region deleteCategory
		[HttpDelete("deteleCategory/:id")]
		public async Task<ActionResult> DeleteCategory(int id)
		{
			try
			{
				var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
				if (category is null)
					return NotFound($"The Category With Id {id} Not Found");
				await _unitOfWork.CategoryRepository.DeleteAsync(id);
				return Ok($"Category {category.Name} Deleted Successfuly");
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
		#endregion
	}
}
