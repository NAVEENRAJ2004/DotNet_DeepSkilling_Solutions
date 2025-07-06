using System;
using System.Threading.Tasks;
using RetailInventory.database;
using RetailInventory.models;

namespace RetailInventory
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            var electronics = new category { Name = "Electronics" };
            var groceries = new category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("Initial data inserted successfully.");
        }
    }
}
