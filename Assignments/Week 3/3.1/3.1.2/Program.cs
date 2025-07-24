namespace _3._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a year");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 1)
            {
                Console.WriteLine("Inalid input. Please enter a valid year.");
                return;
            }
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            {
                Console.WriteLine("The year is a leap year.");
                return;
            }
            else
            {
                Console.WriteLine("The year is not a leap year.");
            }
        }
    }
}
