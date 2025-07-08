namespace _1._1._3A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any two numbers and I'll give you the quotient and the remainder!");
            Console.WriteLine("Number 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int quotient = num1 / num2;
            int remainder = num1 % num2;
            Console.WriteLine($"Quotient: {quotient} Remainder: {remainder}");
        }
    }
}
