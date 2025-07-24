namespace _3._1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a string: ");
            string userString = Console.ReadLine();
            int whiteSpaceCounter = 0;

            foreach (char letter in userString)
            {
                if (Char.IsWhiteSpace(letter))
                {
                    whiteSpaceCounter++;
                }
            }
            Console.WriteLine($"{userString} contains {whiteSpaceCounter} spaces");
        }
    }
}
