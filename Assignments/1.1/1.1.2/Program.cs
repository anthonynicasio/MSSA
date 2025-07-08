namespace _1._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any two numbers and I'll add them for you!");
            Console.WriteLine("What's your first number?");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What's your second number?");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double sum = num1 + num2;
            Console.WriteLine("Sum: " + sum);
        }
    }
}
