using BBQ.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BBQ.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "BBQ Sliders",
            Price = 13.99,
            Description =
                "Your choice of 100% Angus beef or chicken sliders with homemade barbeque sauce on a Hawaiian sweetbread bun. Choose from Sweet and Tangy, Hot and Spicy, or Honey BBQ sauces with your choice of toppings.",
            ImageUrl = Environment.GetEnvironmentVariable("IMAGE_URL_PIE"),
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 2,
            Name = "Sweet Potato Fries",
            Price = 9.99,
            Description =
                "What BBQ is complete without a side of Southern Sweet Potato Fries? Hand breaded and fried to perfection. Choose from Tangy Ranch, Dill BBQ sauce, or Honey Mustard to dip them in. Your mouth will thank you!",
            ImageUrl = Environment.GetEnvironmentVariable("IMAGE_URL_FRIES"),
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            Name = "Apple Pie",
            Price = 10.99,
            Description =
                "A buttery, fall apart in your mouth delicious, flaky crust just like Grandma used to make with sweet and tart apple filling. Enjoy a slice of this multi-generationally handed down family recipe, from our family to ours!",
            ImageUrl = Environment.GetEnvironmentVariable("IMAGE_URL_PIE"),
            CategoryName = "Dessert"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 4,
            Name = "Beef Brisket",
            Price = 15.99,
            Description =
                "Cooked to perfection, this beef brisket has been smoking for hours waiting to be enjoyed! <br/>Smoked over a blend of hickory and maple chips for a flavor that cannot be beat!",
            ImageUrl = Environment.GetEnvironmentVariable("IMAGE_URL_BRISKET"),
            CategoryName = "Entree"
        });
    }
}