using System;
using RetailInventory.database;

namespace RetailInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("RetailInventory database context configured.");
        }
    }
}