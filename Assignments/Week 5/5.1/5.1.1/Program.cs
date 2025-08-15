using System.Reflection.Metadata.Ecma335;

namespace _5._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string to test: ");
            int num = Convert.ToInt32(Console.ReadLine());
            bool isPalindrome = false;
            List<int> digits = new List<int>();
            int tempNum = num;
            while (tempNum > 0)
            {
                digits.Add(tempNum % 10);
                tempNum /= 10;
            }
            digits.Reverse();

            foreach (int i in digits)
            {
                if (num % 10 == i)
                {
                    num /= 10;
                    isPalindrome = true;
                    continue;
                }
                else
                {
                    num /= 10;
                    isPalindrome = false;
                    break;
                }
            }
            Console.WriteLine(isPalindrome ? "YES" : "NO");
        }
    }
}
