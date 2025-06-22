using Financial_Forecasting.Models;

namespace Financial_Forecasting.Services
{
    public class FinanceService
    {
        public double GetGrowthValue(FinanceInput input)
        {
            return CalculateGrowthValue(input.InitialAmount, input.GrowthPercent, input.Years);
        }
        private double CalculateGrowthValue(double amount, double percent, double years)
        {
            if(years == 0)
            {
                return amount;
            }
            return CalculateGrowthValue(amount, percent, years - 1) * (1 + percent);
        }
    }
}
