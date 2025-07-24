namespace _1._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.Write("Give me a natural number and I'll give you the sequence and the sum of the sequence: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.Write($"The first {amount} natural numbers are: ");

            for (int i = 1; i <= amount; i++) {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine($"\nThe sum is {sum}");
        }
    }
}
