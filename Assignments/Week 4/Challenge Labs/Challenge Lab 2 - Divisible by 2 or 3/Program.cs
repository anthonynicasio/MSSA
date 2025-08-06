namespace Challenge_Lab_2
{
    internal class Program
    {
        static bool IsDivisibleBy2Or3(int number) =>
        number % 2 == 0 || number % 3 == 0;
        static void Main(string[] args)
        {
            int[] input = { 3, 4 };

            if (IsDivisibleBy2Or3(input[0]) && IsDivisibleBy2Or3(input[1]))
                Console.WriteLine(input[0] * input[1]);
            else
                Console.WriteLine(input[0] + input[1]);
        }
    }
}
