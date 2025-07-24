using System.Dynamic;
using System.Net.Http.Headers;

namespace _3._2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = GetValidDouble("Enter the first number: ");
            double num2 = GetValidDouble("Enter the second number: ");
            double num3 = GetValidDouble("Enter the third number: ");
            double num4 = GetValidDouble("Enter the fourth number:  ");
            double[] results = GetSumAverage(num1, num2, num3, num4);
            double sum = results[0];
            double average = results[1];
            Console.WriteLine($"The total is {sum} and the average is {average}");
        }
        static double GetValidDouble(string prompt)
        {
            double number;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number");
            }
        }

        static double[] GetSumAverage(params double[] userNums)
        {
            double sum = 0;
            foreach (double num in userNums)
            {
                sum += num;
            }
            double average = sum / userNums.Length;
            return new double[] { sum, average };
        }
    }
}