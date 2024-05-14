using Amazon.Core.Interfaces;
using Amazon.Infrasructure.DataContext;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public ICategoryRepository CategoryRepository { get; }

		public IProductRepository ProductRepository { get; }
		public IBasketRepository BasketRepository { get; }
		public UnitOfWork(ApplicationDbContext context,IConnectionMultiplexer redis)
        {
			_context = context;
			CategoryRepository = new CategoryRepository(_context);
			ProductRepository = new ProductRepository(_context);
			BasketRepository = new BasketRepository(redis);
		}
    }
}
