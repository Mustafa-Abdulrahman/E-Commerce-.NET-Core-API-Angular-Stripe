﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Entities.oders
{
	public class OrderItem : BaseEntity<int>
	{
		public OrderItem()
		{

		}
		public OrderItem(ProductItemOrderd productItemOrderd, decimal price, int quantity)
		{
			ProductItemOrderd = productItemOrderd;
			Price = price;
			Quantity = quantity;
		}

		public ProductItemOrderd ProductItemOrderd { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
