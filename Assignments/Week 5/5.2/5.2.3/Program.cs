namespace _5._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers to print: ");
            int n = int.Parse(Console.ReadLine());

            PrintNumToOne(n, 1);

        }

        static void PrintNumToOne(int n, int x)
        {
            if (n < 1)
                return;

            Console.WriteLine(n + " ");
            PrintNumToOne(n - 1, x);
        }
    }
}
