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
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext context;

		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}

	
	}
}
