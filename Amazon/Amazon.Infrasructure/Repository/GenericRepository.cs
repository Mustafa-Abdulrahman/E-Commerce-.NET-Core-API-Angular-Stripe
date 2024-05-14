using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Amazon.Infrasructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
	{
		private readonly ApplicationDbContext _context;

		public GenericRepository(ApplicationDbContext context)
        {
			_context = context;
		}
        public async Task AddAsync(T entity)
		{
			
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{

			var _entity = await _context.Set<T>().FindAsync(id);
			if(_entity is null) {
				return;
			}
			_context.Set<T>().Remove(_entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllWithDataAsync(params Expression<Func<T, object>>[] includes)
		{
			var query =  _context.Set<T>().AsNoTracking().AsQueryable();	
			foreach (var item in includes)
			{
				query=query.Include(item);
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> GetByIdWithDataAsync(int id, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _context.Set<T>().Where(x => x.Id == id);
			foreach (var item in includes)
			{
				query = query.Include(item);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(int id, T entity)
		{
			var _entity =await _context.Set<T>().FindAsync(id);
			if(entity is not null)
			{
				_context.Set<T>().Update(_entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}
