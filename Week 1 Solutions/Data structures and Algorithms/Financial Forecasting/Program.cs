using System;
using Financial_Forecasting.Models;
using Financial_Forecasting.Services;

namespace Financial_Forecasting
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Enter the Initial Amount you going to invest : ");
            double initialAmt = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the growth rate (Indian market's average growth rate is 8%) : ");
            double growthRate = Convert.ToDouble(Console.ReadLine()) / 100;
            Console.Write("Enter Number of Years : ");
            int years = Convert.ToInt32(Console.ReadLine());

            var input = new FinanceInput
            {
                InitialAmount = initialAmt,
                GrowthPercent = growthRate,
                Years = years
            };

            var service = new FinanceService();

            double ans = service.GetGrowthValue(input);

            Console.WriteLine($"\nYour Fund Growth for {years} Year at the Growth of {growthRate * 100} Percentage");
            Console.WriteLine();
            Console.WriteLine($"Initial Amount : {input.InitialAmount}Rs");
            Console.WriteLine($"Growth Rate    : {input.GrowthPercent * 100}%");
            Console.WriteLine($"Years          : {input.Years}");
            Console.WriteLine($"Fund growth    : {ans:F2}Rs");
            Console.WriteLine();
            Console.WriteLine("Time Complexity : O(n)");

        }
    }
} 