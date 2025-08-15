namespace _5._1._2
{
    internal class Program
    {
        public static int returnSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += (num % 10);
                num /= 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            int sum = returnSum(num);
            Console.WriteLine($"The sum of the digits of the number {num} is {sum}");
        }
    }
}
