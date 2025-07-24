using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            // Get roll number with validation
            Console.Write("Input the Roll Number of the student: ");
            student.StudentRollNumber = GetValidRollNumber();

            // Get student name with validation
            Console.Write("Input the Name of the Student: ");
            student.StudentName = GetValidName();

            // Get marks with validation
            Console.WriteLine("Input the marks of Physics, Chemistry, and Computer Application:");
            string[] subjects = { "Physics", "Chemistry", "Computer Application" };

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter marks for {subjects[i]} (0-100): ");
                student.StudentMarks[i] = GetValidMarks(subjects[i]);
            }

            student.CalculateResults();
            Console.WriteLine("\nStudent Results:");
            student.DisplayResults();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static int GetValidRollNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Roll number cannot be empty. Please enter a valid roll number: ");
                    continue;
                }

                if (int.TryParse(input, out int rollNumber) && rollNumber > 0)
                {
                    return rollNumber;
                }

                Console.Write("Please enter a valid positive roll number: ");
            }
        }

        static string GetValidName()
        {
            while (true)
            {
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name.Trim();
                }

                Console.Write("Name cannot be empty. Please enter a valid name: ");
            }
        }

        static int GetValidMarks(string subject)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write($"Marks for {subject} cannot be empty. Please enter marks (0-100): ");
                    continue;
                }

                if (int.TryParse(input, out int marks) && marks >= 0 && marks <= 100)
                {
                    return marks;
                }

                Console.Write($"Please enter valid marks for {subject} (0-100): ");
            }
        }
    }
}