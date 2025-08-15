namespace _5._2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a string: ");
            string input = Console.ReadLine();

            input = input.ToLower();

            if (IsPalindrome(input, 0, input.Length - 1))
                Console.WriteLine("The string is a Palindrome.");
            else
                Console.WriteLine("The string is not a Palindrome.");
        }

        static bool IsPalindrome(string str, int left, int right)
        {
            if (left >= right)
                return true;

            if (str[left] != str[right])
                return false;

            return IsPalindrome(str, left + 1, right - 1);
        }
    }
}