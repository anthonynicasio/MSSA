using System;
using System.Collections.Generic;
using System.Xml;

namespace _7._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Assignment 7.2");
                Console.WriteLine("1) Shell Sort");
                Console.WriteLine("2) Reverse Vowels in String");
                Console.WriteLine("3) Valid Anagram");
                Console.WriteLine("X) Exit");
                Console.Write("Choose (1-3 or X): ");
                var choice = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                switch (choice)
                {
                    case "1":
                        RunShellSort();
                        break;
                    case "2":
                        RunReverseVowels();
                        break;
                    case "3":
                        RunValidAnagram();
                        break;
                    case "x":
                        return; // exit
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // -------- Task 1: Shell Sort --------
        static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            // gap sequence
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;
                    // Gapped insertion sort
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
            }
        }

        static void RunShellSort()
        {
            Console.WriteLine("Enter integers (space or comma separated):");
            var line = Console.ReadLine() ?? "";
            var parts = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++) nums[i] = int.Parse(parts[i]);

            ShellSort(nums);

            Console.WriteLine("Sorted:");
            Console.WriteLine(string.Join(" ", nums));
        }

        // -------- Task 2: Reverse Only Vowels  --------
        static string ReverseVowels(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            // First pass: collect indices and vowels
            List<int> idx = new List<int>();
            List<char> vals = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    idx.Add(i);
                    vals.Add(s[i]);
                }
            }

            // Reverse collected vowels 
            vals.Reverse();

            // Second pass: rebuild string replacing only vowels with reversed ones
            char[] arr = s.ToCharArray();
            for (int k = 0; k < idx.Count; k++)
            {
                arr[idx[k]] = vals[k];
            }

            return new string(arr);
        }

        static void RunReverseVowels()
        {
            Console.Write("Input string s: ");
            string s = Console.ReadLine() ?? "";
            string result = ReverseVowels(s);
            Console.WriteLine($"Output: {result}");
        }

        // -------- Task 3: Valid Anagram    --------
        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            char[] a = s.ToCharArray();
            char[] b = t.ToCharArray();
            Array.Sort(a);
            Array.Sort(b);

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        static void RunValidAnagram()
        {
            Console.Write("Input s: ");
            string s = Console.ReadLine() ?? "";
            Console.Write("Input t: ");
            string t = Console.ReadLine() ?? "";

            Console.WriteLine(IsAnagram(s, t) ? "true" : "false");
        }
    }
}
