namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a character (e.g. '5', 'k') ");
            char userChar = Console.ReadLine()[0];
            Console.WriteLine("Input the width");
            if (!int.TryParse(Console.ReadLine(), out int width) || width <= 0)
            {
                Console.WriteLine("Invalid entry. Enter a positive integer.");
            }
            
            for (int i = width; i > 0; i--)
            {
                string triangleBase = "";
                for (int j = 0; j < i; j++)
                {
                    triangleBase += userChar;
                }
                Console.WriteLine(triangleBase);
            }
        }
    }
}