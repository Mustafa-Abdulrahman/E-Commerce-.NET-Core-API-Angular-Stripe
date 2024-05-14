using Amazon.Core.Entities;
using Amazon.Core.Entities.oders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.DataContext
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

			
		}

		public virtual DbSet<Category> Category { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<Adress> Adresses { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderItem> OrderItems { get; set; }
		public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
