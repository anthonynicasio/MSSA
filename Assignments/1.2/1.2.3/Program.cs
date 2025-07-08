namespace _1._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Hi! I'll perform calculations for you." +
                    "\nGive me the first number: ");
                int firstInt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What's the second number?");
                int secInt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What type of calculation do you need?\n" +
                    "1: Multiplication\n" +
                    "2: Division\n" +
                    "3: Addition\n" +
                    "4: Subtraction\n" +
                    "5: Exit.\n" +
                    "6: Continue.");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine($"{firstInt} multiplied by {secInt} is {firstInt * secInt}");
                        break;
                    case 2:
                        Console.WriteLine($"{firstInt} divided by {secInt} is {firstInt / secInt} ");
                        break;
                    case 3:
                        Console.WriteLine($"{firstInt} added to {secInt} is {firstInt + secInt}");
                        break;
                    case 4:
                        Console.WriteLine($"{firstInt} subtracted by {secInt} is {firstInt - secInt}");
                        break;
                    case 5:
                        Console.WriteLine($"Goodbye.");
                        exit = true;
                        break;
                    case 6:
                        Console.WriteLine($"Restart.");
                        break;
                }
            }
            while (!exit);
        }
    }
}
