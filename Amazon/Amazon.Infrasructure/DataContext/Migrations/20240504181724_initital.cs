using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Amazon.Infrasructure.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Mobiles Smart Phones", "Phone" },
                    { 2, "TV Ancient & Smart", "Televions" },
                    { 3, "Portable Computers", "Laptop" },
                    { 4, "Audio Devices for Personal Use", "Headphones" },
                    { 5, "Portable Touchscreen Devices", "Tablet" },
                    { 6, "Input Devices for Computers", "Keyboard" },
                    { 7, "Wearable Tech for Notifications", "Smartwatch" },
                    { 8, "Output Devices for Documents", "Printer" },
                    { 9, "Captures Images and Videos", "Camera" },
                    { 10, "Unmanned Aerial Vehicles", "Drone" },
                    { 11, "Entertainment Systems for Games", "Gaming Console" },
                    { 12, "Monitors Physical Activity", "Fitness Tracker" },
                    { 13, "Additional Storage for Computers", "External Hard Drive" },
                    { 15, "Central Control for Home Automation", "Smart Home Hub" },
                    { 16, "Digitizes Documents and Images", "Scanner" },
                    { 17, "Digitizes Documents and Images", "Scanner" },
                    { 18, "Wireless or Wired Audio Devices", "Earbuds" },
                    { 19, "Creates Three-Dimensional Objects", "3D Printer" },
                    { 20, "Displays Output from Computers", "Monitor" },
                    { 21, "Immersive Entertainment Devices", "Virtual Reality Headset" },
                    { 22, "Network Devices for Internet Connectivity", "Router" },
                    { 23, "Drawing Devices for Digital Art", "Graphics Tablet" },
                    { 24, "Displays Images and Videos on Large Surfaces", "Projector" },
                    { 25, "Displays Images and Videos on Large Surfaces", "Projector" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Mobile Phone Sumsung, With 6inch Screen", "Sumsung Glaxy Young", 10000m },
                    { 2, 1, "Apple Flagship Phone with 6.7-inch Super Retina XDR Display", "iPhone 13 Pro Max", 1099m },
                    { 3, 1, "Google's Premium Android Phone with 6.7-inch LTPO OLED Display", "Google Pixel 6 Pro", 899m },
                    { 4, 1, "High-End Android Phone by OnePlus with 6.7-inch Fluid AMOLED Display", "OnePlus 10 Pro", 899m },
                    { 5, 1, "Xiaomi's Feature-Packed Phone with 6.8-inch AMOLED Display and Snapdragon 8 Gen 1 CPU", "Xiaomi Mi 12 Ultra", 999m },
                    { 6, 1, "Sony's Premium Phone with 6.5-inch 4K HDR OLED Display and Snapdragon 888 CPU", "Sony Xperia 1 III", 1299m },
                    { 7, 2, "LG's Premium OLED TV with 65-inch 4K Display and Dolby Vision IQ", "LG OLED C1", 2499m },
                    { 8, 2, "Samsung's QLED TV with 85-inch 4K Display and Quantum HDR 32X", "Samsung QLED QN90A", 3499m },
                    { 9, 2, "Sony's Master Series OLED TV with 77-inch 4K Display and Cognitive Processor XR", "Sony BRAVIA XR A90J", 4999m },
                    { 10, 2, "TCL's Affordable QLED TV with 55-inch 4K Display and Dolby Vision HDR", "TCL 6-Series R635", 799m },
                    { 11, 2, "Hisense's ULED TV with 75-inch 4K Display and Quantum Dot Technology", "Hisense ULED U8G", 1499m },
                    { 12, 3, "Dell's Ultra-Thin Laptop with 15.6-inch 4K InfinityEdge Display and Intel Core i7 Processor", "Dell XPS 15", 1699m },
                    { 13, 3, "Lenovo's Business Ultrabook with 14-inch 4K Display, Intel Core i7 CPU, and Windows 11 Pro", "Lenovo ThinkPad X1 Carbon Gen 9", 1999m },
                    { 15, 3, "HP's Convertible Laptop with 13.3-inch OLED Touchscreen, Intel Core i7 CPU, and Windows 11 Home", "HP Spectre x360", 1399m },
                    { 16, 3, "ASUS's Gaming Laptop with 14-inch QHD Display, AMD Ryzen 9 CPU, and NVIDIA GeForce RTX 3060 GPU", "ASUS ROG Zephyrus G14", 1499m },
                    { 17, 3, "Microsoft's Versatile Laptop with 14.4-inch PixelSense Flow Touchscreen, Intel Core i7 CPU, and Windows 11 Pro", "Microsoft Surface Laptop Studio", 1599m },
                    { 18, 4, "Apple's Pro Tablet with Liquid Retina XDR Display, M1 Chip, and iPadOS", "Apple iPad Pro 12.9-inch", 1099m },
                    { 19, 4, "Samsung's Premium Android Tablet with 12.4-inch Super AMOLED Display, Snapdragon 865+ CPU, and S Pen Included", "Samsung Galaxy Tab S7+", 849m },
                    { 20, 4, "Microsoft's Versatile Tablet with 13-inch PixelSense Display, Intel Core i7 CPU, and Windows 11", "Microsoft Surface Pro 8", 1299m },
                    { 21, 4, "Amazon's Affordable Tablet with 10.1-inch Full HD Display, Quad-Core Processor, and Alexa Hands-Free", "Amazon Fire HD 10", 149m },
                    { 22, 4, "Lenovo's Premium Android Tablet with 11.5-inch OLED Display, Snapdragon 730G CPU, and Dolby Atmos Sound", "Lenovo Tab P11 Pro", 499m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
