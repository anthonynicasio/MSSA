namespace Interface
{
    public interface ICalculator
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    }

    public class MyMath : ICalculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("You can't divide by zero.");
            return a / b;
        }
    }



class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new MyMath();

            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose operation: +, -, *, /");
            string operation = Console.ReadLine();

            try
            {
                double result = operation switch
                {
                    "+" => calculator.Add(num1, num2),
                    "-" => calculator.Subtract(num1, num2),
                    "*" => calculator.Multiply(num1, num2),
                    "/" => calculator.Divide(num1, num2),
                    _ => throw new InvalidOperationException("Invalid operator.")
                };

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}