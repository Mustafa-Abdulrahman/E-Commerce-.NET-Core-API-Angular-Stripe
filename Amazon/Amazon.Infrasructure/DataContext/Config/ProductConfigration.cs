using Amazon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.DataContext.Config
{
	public class ProductConfigration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Description).HasMaxLength(150);
			builder.Property(x => x.Price).HasColumnType("decimal(16,2)");
			builder.HasData(
				new {Id= 1, Name = "Sumsung Glaxy Young", Description = "Mobile Phone Sumsung, With 6inch Screen", Price = 10000m, CategoryId = 1,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new {Id= 2, Name = "iPhone 13 Pro Max", Description = "Apple Flagship Phone with 6.7-inch Super Retina XDR Display", Price = 1099m, CategoryId = 1, image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new {Id= 3, Name = "Google Pixel 6 Pro", Description = "Google's Premium Android Phone with 6.7-inch LTPO OLED Display", Price = 899m, CategoryId = 1 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 4, Name = "OnePlus 10 Pro", Description = "High-End Android Phone by OnePlus with 6.7-inch Fluid AMOLED Display", Price = 899m, CategoryId = 1 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 5, Name = "Xiaomi Mi 12 Ultra", Description = "Xiaomi's Feature-Packed Phone with 6.8-inch AMOLED Display and Snapdragon 8 Gen 1 CPU", Price = 999m, CategoryId = 1 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 6, Name = "Sony Xperia 1 III", Description = "Sony's Premium Phone with 6.5-inch 4K HDR OLED Display and Snapdragon 888 CPU", Price = 1299m, CategoryId = 1 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 7, Name = "LG OLED C1", Description = "LG's Premium OLED TV with 65-inch 4K Display and Dolby Vision IQ", Price = 2499m, CategoryId = 2 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 8, Name = "Samsung QLED QN90A", Description = "Samsung's QLED TV with 85-inch 4K Display and Quantum HDR 32X", Price = 3499m, CategoryId = 2 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 9, Name = "Sony BRAVIA XR A90J", Description = "Sony's Master Series OLED TV with 77-inch 4K Display and Cognitive Processor XR", Price = 4999m, CategoryId = 2 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 10,Name = "TCL 6-Series R635", Description = "TCL's Affordable QLED TV with 55-inch 4K Display and Dolby Vision HDR", Price = 799m, CategoryId = 2 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 11,Name = "Hisense ULED U8G", Description = "Hisense's ULED TV with 75-inch 4K Display and Quantum Dot Technology", Price = 1499m, CategoryId = 2 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 12,Name = "Dell XPS 15", Description = "Dell's Ultra-Thin Laptop with 15.6-inch 4K InfinityEdge Display and Intel Core i7 Processor", Price = 1699m, CategoryId = 3 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 13,Name = "Lenovo ThinkPad X1 Carbon Gen 9", Description = "Lenovo's Business Ultrabook with 14-inch 4K Display, Intel Core i7 CPU, and Windows 11 Pro", Price = 1999m, CategoryId = 3 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 15,Name = "HP Spectre x360", Description = "HP's Convertible Laptop with 13.3-inch OLED Touchscreen, Intel Core i7 CPU, and Windows 11 Home", Price = 1399m, CategoryId = 3 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 16,Name = "ASUS ROG Zephyrus G14", Description = "ASUS's Gaming Laptop with 14-inch QHD Display, AMD Ryzen 9 CPU, and NVIDIA GeForce RTX 3060 GPU", Price = 1499m, CategoryId = 3 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 17,Name = "Microsoft Surface Laptop Studio", Description = "Microsoft's Versatile Laptop with 14.4-inch PixelSense Flow Touchscreen, Intel Core i7 CPU, and Windows 11 Pro", Price = 1599m, CategoryId = 3 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 18,Name = "Apple iPad Pro 12.9-inch", Description = "Apple's Pro Tablet with Liquid Retina XDR Display, M1 Chip, and iPadOS", Price = 1099m, CategoryId = 4 },
				new {Id= 19,Name = "Samsung Galaxy Tab S7+", Description = "Samsung's Premium Android Tablet with 12.4-inch Super AMOLED Display, Snapdragon 865+ CPU, and S Pen Included", Price = 849m, CategoryId = 4 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 20,Name = "Microsoft Surface Pro 8", Description = "Microsoft's Versatile Tablet with 13-inch PixelSense Display, Intel Core i7 CPU, and Windows 11", Price = 1299m, CategoryId = 4 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 21,Name = "Amazon Fire HD 10", Description = "Amazon's Affordable Tablet with 10.1-inch Full HD Display, Quad-Core Processor, and Alexa Hands-Free", Price = 149m, CategoryId = 4 ,image= "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1"},
				new {Id= 22,Name = "Lenovo Tab P11 Pro", Description = "Lenovo's Premium Android Tablet with 11.5-inch OLED Display, Snapdragon 730G CPU, and Dolby Atmos Sound", Price = 499m, CategoryId = 4, image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" }
				);	 
		}			 
	}				 
}
