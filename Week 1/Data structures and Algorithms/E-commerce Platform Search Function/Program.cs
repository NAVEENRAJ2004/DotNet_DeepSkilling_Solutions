using E_commerce_Platform_Search_Function.Models;
using E_commerce_Platform_Search_Function.Services;

namespace E_commerce_Platform_Search_Function
{
    internal class Program
    {
        static void Main()
        {
            var products = new[]
            {
                new Product(14, "Trekking Jacket", "Apparel"),
                new Product(3, "Bluetooth Speaker", "Electronics"),
                new Product(19, "Water Bottle", "Fitness"),
                new Product(1, "Keyboard", "Electronics"),
                new Product(11, "Microwave Oven", "Appliances"),
                new Product(5, "Coffee Maker", "Appliances"),
                new Product(16, "Noise Cancelling Headphones", "Electronics"),
                new Product(7, "Graphic Tablet", "Electronics"),
                new Product(20, "Smartphone Stand", "Accessories"),
                new Product(9, "Yoga Mat", "Fitness"),
                new Product(2, "Office Chair", "Furniture"),
                new Product(17, "Sunglasses", "Fashion"),
                new Product(10, "LED Monitor", "Electronics"),
                new Product(8, "Wrist Watch", "Fashion"),
                new Product(4, "Running Shoes", "Footwear"),
                new Product(15, "Bookshelf", "Furniture"),
                new Product(12, "Gaming Mouse", "Electronics"),
                new Product(6, "Backpack", "Accessories"),
                new Product(13, "Electric Kettle", "Appliances"),
                new Product(18, "Fitness Tracker", "Electronics"),
            };

            Console.WriteLine("Available Products:");
            Console.WriteLine("{0,-4} | {1,-30} | {2}", "ID", "Product Name", "Category");
            Console.WriteLine(new string('-', 70));

            foreach (var product in products) 
            {
                Console.WriteLine("{0,-4} | {1,-30} | {2}", product.Id, product.Name, product.Category);
            }

            Console.Write("\nEnter the product name you want to search: ");
            string? search = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(search))
            {
                //Calling Linear Search
                Console.WriteLine("\nLinear Search:");
                var linearResult = ProductSearch.LinearSearch(products, search);
                Console.WriteLine(linearResult != null ? $"Found: {linearResult}" : "No product found.");

                //Calling Binary Search since we are getting user input as string we are sorting the array based on character
                Console.WriteLine("\nBinary Search:");
                var sortedByName = products.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToArray();
                var binaryResult = ProductSearch.BinarySearch(sortedByName, search);
                Console.WriteLine(binaryResult != null ? $"Found: {binaryResult}" : "No product found.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid product name.");
            }

            Console.WriteLine("\nComplexity Analysis:");
            Console.WriteLine("Linear Search:");
            Console.WriteLine("Time Complexity   => Best: O(1), Average/Worst: O(n)");
            Console.WriteLine("Space Complexity  => O(1)");

            Console.WriteLine("\nBinary Search:");
            Console.WriteLine("Time Complexity   => Best: O(1), Average/Worst: O(log n)");
            Console.WriteLine("Space Complexity  => O(1) iterative (as implemented)");
        }
    }
}
