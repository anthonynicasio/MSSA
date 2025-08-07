namespace Palindrome
{
    internal class Program
    {
        static bool IsPalindrome(string input)
        {
            int l = 0;
            int r = input.Length - 1;
            while (l < r)
            {
                if (char.ToLower(input[l]) == char.ToLower(input[r]))
                {
                    l++;
                    r--;
                } else
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string: ");
            string userInput = Console.ReadLine();
            bool palindrome = IsPalindrome(userInput);
            if (palindrome)
            {
                Console.WriteLine($"{userInput} is a palindrome!");
            } else
            {
                Console.WriteLine($"{userInput} is not a palindrome :(");
            }
        }
    }
}
