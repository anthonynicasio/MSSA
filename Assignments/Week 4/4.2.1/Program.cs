namespace _4._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> elements = new();

            if (args.Length == 0)
            {
                Console.Write("Input the number of elements to be stored in the array: ");
                int.TryParse(Console.ReadLine(), out int length);
                Console.WriteLine($"Input {length} elements into the array: ");

                int input;
                for (int i = 0; i < length; i++) {
                    Console.Write($"element {i} : ");
                    while (!int.TryParse(Console.ReadLine(), out input)) {
                        {
                            Console.Write("Invalid input. Please try again: ");
                        }
                        if 

        }
    }
}
