﻿using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Services
{
	public interface IPaymentServices
	{
		Task<CustomerBasket> CreateOrUpdatePayment(string basketId);
	}
}
