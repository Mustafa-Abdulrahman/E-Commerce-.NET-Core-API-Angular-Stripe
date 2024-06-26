﻿using Amazon.API.Dto;
using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Interfaces
{
	public interface  IBasketRepository
	{
		Task<CustomerBasket> GetBasketAsync (string id);
		Task<CustomerBasket> UpdateBasketAsync (CustomerBasket customerbusket);
		Task<bool> DeleteBasketAsync (string id);

	}
}
