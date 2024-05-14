using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Interfaces
{
	public interface IProductRepository:IGenericRepository<Product>
	{


		Task<IReadOnlyList<Product>> GetAllAsync(int? categoryId);

	}
}
