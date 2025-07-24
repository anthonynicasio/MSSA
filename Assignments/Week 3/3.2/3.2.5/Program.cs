namespace _3._2._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array length:");
            if (!int.TryParse(Console.ReadLine(), out int userArrayLength) || userArrayLength <= 0)
            {
                Console.WriteLine("Invalid input. Enter a positive integer.");
                return;
            }

            int[] userArray = new int[userArrayLength];
            for (int i = 0; i < userArrayLength; i++)
            {
                Console.WriteLine($"Enter the value for index #{i} of the array:");
                while (!int.TryParse(Console.ReadLine(), out userArray[i]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer:");
                }
            }

            Console.WriteLine("What number do you want to find in your array?");
            if (!int.TryParse(Console.ReadLine(), out int userNum))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            int resultIndex = IndexFinder(userArray, userNum);
            if (resultIndex == -1)
            {
                Console.WriteLine("Number not found in the array.");
            }
            else
            {
                Console.WriteLine($"The number is in index #{resultIndex}.");
            }
        }


        static int IndexFinder(int[] ints, int userNum)
        {
            int indexCounter = 0;
            foreach (int value in ints)
            {
                if ( value == userNum)
                {
                    return indexCounter;
                }
                indexCounter++;
            }
            return -1;
        }
    }
}
