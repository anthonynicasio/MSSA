namespace _4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IfNumberContains3(7201432));
        }


        public static bool IfNumberContains3(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit == 3)
                {
                    return true;
                }
                number = number / 10;
            }
            return false;
        }
    }
}

