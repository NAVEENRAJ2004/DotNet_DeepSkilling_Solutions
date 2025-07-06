using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.database;
using RetailInventory.models;

namespace RetailInventory
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // 1. Retrieve All Products
            var products = await context.Products.ToListAsync();
            Console.WriteLine("All Products:");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - Rs.{p.Price}");

            Console.WriteLine();

            // 2. Find by ID (e.g., ID = 1)
            var product = await context.Products.FindAsync(1);
            Console.WriteLine("Find by ID = 1:");
            Console.WriteLine($"Found: {product?.Name}");

            Console.WriteLine();

            // 3. FirstOrDefault with condition (Price > 50000)
            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine("Expensive Product (Price > Rs.50000):");
            Console.WriteLine($"Expensive: {expensive?.Name}");

            Console.ReadKey();
        }
    }
}