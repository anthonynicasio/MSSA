namespace _1._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                {
                    Console.WriteLine("What type of calculation do you need?\n" +
                        "1: Addition\n" +
                        "2: Subtraction\n" +
                        "3: Multiplication\n" +
                        "4: Division\n" +
                        "5: Exit.\n" +
                        "Enter your choice 1-5.");

                    double userChoice = Convert.ToDouble(Console.ReadLine());
                    if (userChoice == 5)
                    {
                        Console.WriteLine("Goodbye!");
                        exit = true;
                    }

                    Console.WriteLine("Enter the first number: ");
                    double firstUserNum = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the second number: ");
                    double secUserNum = Convert.ToDouble(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine($"{firstUserNum} + {secUserNum} = {firstUserNum + secUserNum}");
                            break;
                        case 2:
                            Console.WriteLine($"{firstUserNum} - {secUserNum} = {firstUserNum - secUserNum} ");
                            break;
                        case 3:
                            Console.WriteLine($"{firstUserNum} * {secUserNum} = {firstUserNum * secUserNum}");
                            break;
                        case 4:
                            if (secUserNum == 0)
                            {
                                Console.WriteLine("Oops! You can't divide by zero.\n I'll restart the program so you can try again.");
                            }
                            else
                            {
                                Console.WriteLine($"{firstUserNum} / {secUserNum} = {firstUserNum / secUserNum}");
                            }
                            break;
                        case 5:
                            Console.WriteLine($"Goodbye.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine($"Your entry was invalid. Please select 1-5");
                            break;
                    }
                }
            }
        }
    }
}
