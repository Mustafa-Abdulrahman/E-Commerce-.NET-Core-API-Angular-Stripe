using Amazon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrasructure.DataContext.Config
{
	public class CategoryConfigration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Description).HasMaxLength(50);
			builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
			builder.HasData(

				new { Id = 1, Name = "Phone", Description = "Mobiles Smart Phones" },
				new { Id = 2, Name = "Televions", Description = "TV Ancient & Smart" },
				new { Id = 3, Name = "Laptop", Description = "Portable Computers" },
				new { Id = 4, Name = "Headphones", Description = "Audio Devices for Personal Use" },
				new { Id = 5, Name = "Tablet", Description = "Portable Touchscreen Devices" },
				new { Id = 6, Name = "Keyboard", Description = "Input Devices for Computers" },
				new { Id = 7, Name = "Smartwatch", Description = "Wearable Tech for Notifications" },
				new { Id = 8, Name = "Printer", Description = "Output Devices for Documents" },
				new { Id = 9, Name = "Camera", Description = "Captures Images and Videos" },
				new { Id = 10, Name = "Drone", Description = "Unmanned Aerial Vehicles" },
				new { Id = 11, Name = "Gaming Console", Description = "Entertainment Systems for Games" },
				new { Id = 12, Name = "Fitness Tracker", Description = "Monitors Physical Activity" },
				new { Id = 13, Name = "External Hard Drive", Description = "Additional Storage for Computers" },
				new { Id = 15, Name = "Smart Home Hub", Description = "Central Control for Home Automation" },
				new { Id = 16, Name = "Scanner", Description = "Digitizes Documents and Images" },
				new { Id = 17, Name = "Scanner", Description = "Digitizes Documents and Images" },
				new { Id = 18, Name = "Earbuds", Description = "Wireless or Wired Audio Devices" },
				new { Id = 19, Name = "3D Printer", Description = "Creates Three-Dimensional Objects" },
				new { Id = 20, Name = "Monitor", Description = "Displays Output from Computers" },
				new { Id = 21, Name = "Virtual Reality Headset", Description = "Immersive Entertainment Devices" },
				new { Id = 22, Name = "Router", Description = "Network Devices for Internet Connectivity" },
				new { Id = 23, Name = "Graphics Tablet", Description = "Drawing Devices for Digital Art" },
				new { Id = 24, Name = "Projector", Description = "Displays Images and Videos on Large Surfaces" },
				new { Id = 25, Name = "Projector", Description = "Displays Images and Videos on Large Surfaces" }

				); 
		}
	}
}
