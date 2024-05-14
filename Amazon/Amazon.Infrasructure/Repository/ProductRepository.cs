using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Amazon.Infrasructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IReadOnlyList<Product>> GetAllAsync(int? categoryId)
		{
			var query =  await _context.Product.AsNoTracking().ToListAsync();

			if(categoryId.HasValue)
			{
				if (categoryId.Value > 0)
				{
					query = query.Where(x => x.CategoryId == categoryId).ToList();
				}
			}

			return query;
		}
	}
}
