using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBQ.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Your choice of 100% Angus beef or chicken sliders with homemade barbeque sauce on a Hawaiian sweetbread bun.<br/>Choose from Sweet and Tangy, Hot and Spicy, or Honey BBQ sauces with your choice of toppings.", "https://lisadotnetmastery.blob.core.windows.net/bbq/ImagesForBBQ/sliders.jpg", "BBQ Sliders", 13.99 },
                    { 2, "Appetizer", "What BBQ is complete without a side of Southern Sweet Potato Fries? <br/>Hand breaded and fried to perfection. Choose from Tangy Ranch, Dill BBQ sauce, or Honey Mustard to dip them in. Your mouth will thank you!", "https://lisadotnetmastery.blob.core.windows.net/bbq/ImagesForBBQ/sweetpotatofries.jpg", "Sweet Potato Fries", 9.9900000000000002 },
                    { 3, "Dessert", "A flaky crust just like Mama used to make. Enjoy a slice this handed down family recipe, <br/>from our family to ours.", "https://lisadotnetmastery.blob.core.windows.net/bbq/ImagesForBBQ/applepie.jpg", "Apple Pie", 10.99 },
                    { 4, "Entree", "Cooked to perfection this beef brisket has been smoking for hours waiting to be enjoyed! <br/>Smoked over hickory and maple chips for a flavor that cannot be beat!", "https://lisadotnetmastery.blob.core.windows.net/bbq/ImagesForBBQ/beefbrisket.jpg", "Beef Brisket", 15.99 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
