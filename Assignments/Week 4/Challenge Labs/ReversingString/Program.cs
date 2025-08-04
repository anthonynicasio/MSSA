namespace ReversingString
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public void ReverseString(List<char> str)
        {
            int leftIndex = 0;
            int rightIndex = str.Count - 1;

            while (leftIndex < rightIndex)
            {
                char temp = str[leftIndex];
                str[leftIndex] = str[rightIndex];
                str[rightIndex] = temp;

                leftIndex++;
                rightIndex--;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<char> myString = new List<char> { 'H', 'e', 'l', 'l', 'o' };

            Solution solution = new Solution();
            solution.ReverseString(myString);

            Console.WriteLine(string.Join("", myString)); // Output: "olleH"
        }
    }
}
