namespace _1._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers and I'll tell you if they're equal or not!");
            Console.Write("Enter your first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 != num2) {
                Console.WriteLine($"{num1} and {num2} are not equal");
            } else {
                Console.WriteLine($"{num1} and {num2} are equal!");
            }
        }
    }
}
