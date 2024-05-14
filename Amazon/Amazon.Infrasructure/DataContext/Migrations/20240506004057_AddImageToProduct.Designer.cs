﻿// <auto-generated />
using Amazon.Infrasructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Amazon.Infrasructure.DataContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240506004057_AddImageToProduct")]
    partial class AddImageToProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Amazon.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Mobiles Smart Phones",
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 2,
                            Description = "TV Ancient & Smart",
                            Name = "Televions"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Portable Computers",
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Audio Devices for Personal Use",
                            Name = "Headphones"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Portable Touchscreen Devices",
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Input Devices for Computers",
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Wearable Tech for Notifications",
                            Name = "Smartwatch"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Output Devices for Documents",
                            Name = "Printer"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Captures Images and Videos",
                            Name = "Camera"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Unmanned Aerial Vehicles",
                            Name = "Drone"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Entertainment Systems for Games",
                            Name = "Gaming Console"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Monitors Physical Activity",
                            Name = "Fitness Tracker"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Additional Storage for Computers",
                            Name = "External Hard Drive"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Central Control for Home Automation",
                            Name = "Smart Home Hub"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Digitizes Documents and Images",
                            Name = "Scanner"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Digitizes Documents and Images",
                            Name = "Scanner"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Wireless or Wired Audio Devices",
                            Name = "Earbuds"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Creates Three-Dimensional Objects",
                            Name = "3D Printer"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Displays Output from Computers",
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Immersive Entertainment Devices",
                            Name = "Virtual Reality Headset"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Network Devices for Internet Connectivity",
                            Name = "Router"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Drawing Devices for Digital Art",
                            Name = "Graphics Tablet"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Displays Images and Videos on Large Surfaces",
                            Name = "Projector"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Displays Images and Videos on Large Surfaces",
                            Name = "Projector"
                        });
                });

            modelBuilder.Entity("Amazon.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(16,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Mobile Phone Sumsung, With 6inch Screen",
                            Name = "Sumsung Glaxy Young",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Apple Flagship Phone with 6.7-inch Super Retina XDR Display",
                            Name = "iPhone 13 Pro Max",
                            Price = 1099m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Google's Premium Android Phone with 6.7-inch LTPO OLED Display",
                            Name = "Google Pixel 6 Pro",
                            Price = 899m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "High-End Android Phone by OnePlus with 6.7-inch Fluid AMOLED Display",
                            Name = "OnePlus 10 Pro",
                            Price = 899m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Xiaomi's Feature-Packed Phone with 6.8-inch AMOLED Display and Snapdragon 8 Gen 1 CPU",
                            Name = "Xiaomi Mi 12 Ultra",
                            Price = 999m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Sony's Premium Phone with 6.5-inch 4K HDR OLED Display and Snapdragon 888 CPU",
                            Name = "Sony Xperia 1 III",
                            Price = 1299m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "LG's Premium OLED TV with 65-inch 4K Display and Dolby Vision IQ",
                            Name = "LG OLED C1",
                            Price = 2499m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Samsung's QLED TV with 85-inch 4K Display and Quantum HDR 32X",
                            Name = "Samsung QLED QN90A",
                            Price = 3499m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Sony's Master Series OLED TV with 77-inch 4K Display and Cognitive Processor XR",
                            Name = "Sony BRAVIA XR A90J",
                            Price = 4999m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "TCL's Affordable QLED TV with 55-inch 4K Display and Dolby Vision HDR",
                            Name = "TCL 6-Series R635",
                            Price = 799m
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Description = "Hisense's ULED TV with 75-inch 4K Display and Quantum Dot Technology",
                            Name = "Hisense ULED U8G",
                            Price = 1499m
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Dell's Ultra-Thin Laptop with 15.6-inch 4K InfinityEdge Display and Intel Core i7 Processor",
                            Name = "Dell XPS 15",
                            Price = 1699m
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Description = "Lenovo's Business Ultrabook with 14-inch 4K Display, Intel Core i7 CPU, and Windows 11 Pro",
                            Name = "Lenovo ThinkPad X1 Carbon Gen 9",
                            Price = 1999m
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "HP's Convertible Laptop with 13.3-inch OLED Touchscreen, Intel Core i7 CPU, and Windows 11 Home",
                            Name = "HP Spectre x360",
                            Price = 1399m
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 3,
                            Description = "ASUS's Gaming Laptop with 14-inch QHD Display, AMD Ryzen 9 CPU, and NVIDIA GeForce RTX 3060 GPU",
                            Name = "ASUS ROG Zephyrus G14",
                            Price = 1499m
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            Description = "Microsoft's Versatile Laptop with 14.4-inch PixelSense Flow Touchscreen, Intel Core i7 CPU, and Windows 11 Pro",
                            Name = "Microsoft Surface Laptop Studio",
                            Price = 1599m
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "Apple's Pro Tablet with Liquid Retina XDR Display, M1 Chip, and iPadOS",
                            Name = "Apple iPad Pro 12.9-inch",
                            Price = 1099m
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Description = "Samsung's Premium Android Tablet with 12.4-inch Super AMOLED Display, Snapdragon 865+ CPU, and S Pen Included",
                            Name = "Samsung Galaxy Tab S7+",
                            Price = 849m
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Microsoft's Versatile Tablet with 13-inch PixelSense Display, Intel Core i7 CPU, and Windows 11",
                            Name = "Microsoft Surface Pro 8",
                            Price = 1299m
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            Description = "Amazon's Affordable Tablet with 10.1-inch Full HD Display, Quad-Core Processor, and Alexa Hands-Free",
                            Name = "Amazon Fire HD 10",
                            Price = 149m
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            Description = "Lenovo's Premium Android Tablet with 11.5-inch OLED Display, Snapdragon 730G CPU, and Dolby Atmos Sound",
                            Name = "Lenovo Tab P11 Pro",
                            Price = 499m
                        });
                });

            modelBuilder.Entity("Amazon.Core.Entities.Product", b =>
                {
                    b.HasOne("Amazon.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Amazon.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
