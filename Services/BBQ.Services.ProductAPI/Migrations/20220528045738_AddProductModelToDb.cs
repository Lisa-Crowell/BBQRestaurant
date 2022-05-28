using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBQ.Services.ProductAPI.Migrations
{
    public partial class AddProductModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Your choice of 100% Angus beef or chicken sliders with homemade barbeque sauce on a Hawaiian sweetbread bun.<br/>Choose from Sweet and Tangy, Hot and Spicy, or Honey BBQ sauces with your choice of toppings.", null, "BBQ Sliders", 13.99 },
                    { 2, "Appetizer", "What BBQ is complete without a side of Southern Sweet Potato Fries? <br/>Hand breaded and fried to perfection. Choose from Tangy Ranch, Dill BBQ sauce, or Honey Mustard to dip them in. Your mouth will thank you!", null, "Sweet Potato Fries", 9.9900000000000002 },
                    { 3, "Dessert", "A flaky crust just like Mama used to make. Enjoy a slice this handed down family recipe, <br/>from our family to ours.", null, "Apple Pie", 10.99 },
                    { 4, "Entree", "Cooked to perfection this beef brisket has been smoking for hours waiting to be enjoyed! <br/>Smoked over hickory and maple chips for a flavor that cannot be beat!", null, "Beef Brisket", 15.99 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
