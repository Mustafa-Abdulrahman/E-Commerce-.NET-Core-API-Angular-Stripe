using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity<int>
	{
		 Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllWithDataAsync(params Expression<Func<T, object>>[] includes);
		Task<T> GetByIdWithDataAsync(int id, params Expression<Func<T, object>>[] includes);
		Task  AddAsync(T entity);
		Task  UpdateAsync(int id,T entity);
		Task DeleteAsync(int id);
	}
}
