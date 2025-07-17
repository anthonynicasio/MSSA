using System.ComponentModel;

namespace _2._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("------Custom Math Method------");
            Console.WriteLine("Select the option\n" +
                "   1. Add\n" +
                "   2. Multiply");

            string userInput = Console.ReadLine().ToLower();

            if (userInput == "1" || userInput == "add")
            {
                Console.WriteLine("How many numbers do you want to add?\n 2 or 3?");
                string amountOfNums = Console.ReadLine().ToLower();
                if (amountOfNums == "2" || amountOfNums == "two")
                {
                    Console.WriteLine("Enter the first number");
                    int firstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    int secondNumber = Convert.ToInt32(Console.ReadLine());
                    int sum = CustomMath.Add(firstNumber, secondNumber);
                    Console.WriteLine($"The sum of your two numbers is {sum}");
                }
                else if (amountOfNums == "3" || amountOfNums == "three")
                {
                    Console.WriteLine("Enter the first number");
                    decimal firstNumber = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    decimal secondNumber = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter the third number");
                    decimal thirdNumber= Convert.ToDecimal(Console.ReadLine());
                    decimal sum = CustomMath.Add(firstNumber, secondNumber, thirdNumber);
                    Console.WriteLine($"The sum of your three numbers is {sum}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }


            }
            else if (userInput == "2" || userInput == "multiply")
            {
                Console.WriteLine("How many numbers do you want to multiply?\n 2 or 3?");
                string amountOfNums = Console.ReadLine().ToLower();
                if (amountOfNums == "2" || amountOfNums == "two")
                {
                    Console.WriteLine("Enter the first number");
                    float firstNumber = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    float secondNumber = float.Parse(Console.ReadLine());
                    float product = CustomMath.Multiply(firstNumber, secondNumber);
                    Console.WriteLine($" {firstNumber} x {secondNumber} = {product}");
                }
                else if (amountOfNums == "3" || amountOfNums == "three")
                {
                    Console.WriteLine("Enter the first number");
                    float firstNumber = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    float secondNumber = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the third number");
                    float thirdNumber = float.Parse(Console.ReadLine());
                    float product = CustomMath.Multiply(firstNumber, secondNumber, thirdNumber);
                    Console.WriteLine($"{firstNumber} x {secondNumber} x {thirdNumber} = {product}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
