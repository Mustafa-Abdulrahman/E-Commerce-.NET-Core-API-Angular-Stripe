using Amazon.API.Dto;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using AutoMapper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.Repository
{
	public class BasketRepository : IBasketRepository
	{
		private readonly IDatabase _database;

		public BasketRepository(IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();
		}
		public async Task<bool> DeleteBasketAsync(string id)
		{
			//var check = await _redis.KeyExistsAsync(id);
			//if (check) 
			return await _database.KeyDeleteAsync(id);


		}

		public async Task<CustomerBasket> GetBasketAsync(string id)
		{
			var data = await _database.StringGetAsync(id);

			return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
		}

		public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerbusket)
		{
			var _basket = await _database.StringSetAsync(customerbusket.Id,
				JsonSerializer.Serialize(customerbusket), TimeSpan.FromDays(30)
				);
			if (!_basket) return null;
			return await GetBasketAsync(customerbusket.Id);
		}	
	}
}
