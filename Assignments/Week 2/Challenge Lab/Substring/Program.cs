namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input String");
            string s = Console.ReadLine();

            while (s.Contains("AB") || s.Contains("CD"))
            {
                s = s.Replace("AB", "").Replace("CD", "");
                Console.WriteLine(s);
            }

            Console.WriteLine(s.Length);

        }
    }
}
