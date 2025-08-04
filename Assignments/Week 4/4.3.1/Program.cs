using System;

namespace ElectricityBillCalculator
{
    internal class Program
    {
        public static decimal GetRatePerUnit(int unitsUsed) => unitsUsed switch
        {
            <= 199 => 1.20m,
            <= 399 => 1.50m,
            <= 599 => 1.80m,
            _ => 2.00m
        };

        public static decimal CalculateBaseCharge(int unitsUsed)
        {
            if (unitsUsed < 0)
            {
                throw new ArgumentException("Units used cannot be negative.");
            }
            decimal ratePerUnit = GetRatePerUnit(unitsUsed);
            decimal baseCharge = unitsUsed * ratePerUnit;
            return baseCharge;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Units Consumed: ");
            int unitsUsed = Convert.ToInt32(Console.ReadLine());

            decimal ratePerUnit = GetRatePerUnit(unitsUsed);
            decimal baseAmount = CalculateBaseCharge(unitsUsed);
            decimal surchargeAmount = baseAmount > 400 ? baseAmount * 0.15m : 0.00m;
            decimal totalAmountDue = baseAmount + surchargeAmount;

            Console.WriteLine("\nElectricity Bill Summary");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Customer ID         : {customerId}");
            Console.WriteLine($"Customer Name       : {customerName}");
            Console.WriteLine($"Units Consumed      : {unitsUsed}");
            Console.WriteLine($"Charge @${ratePerUnit:0.00}/unit : {baseAmount:0.00}");
            Console.WriteLine($"Surcharge Amount    : {surchargeAmount:0.00}");
            Console.WriteLine($"Total Amount to Pay : {totalAmountDue:0.00}");
        }
    }
}
