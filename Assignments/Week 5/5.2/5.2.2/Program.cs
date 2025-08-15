namespace _5._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers to print: ");
            int n = int.Parse(Console.ReadLine());

            PrintNaturalNumbers(1, n);
            }
        

        static void PrintNaturalNumbers(int curr, int n)
        {
            if (curr > n)
                return;

            Console.WriteLine(curr + " ");
            PrintNaturalNumbers(curr + 1, n);
        }
    }
}
