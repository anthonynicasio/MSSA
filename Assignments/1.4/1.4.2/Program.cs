using System.Security.Cryptography.X509Certificates;

namespace _1._4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student anthony = new Student(12345, "Anthony", "Nicasio", 'A');
            Console.WriteLine($"{anthony.StudentLname}, {anthony.StudentFname} " +
                $"Student ID: {anthony.StudentId} has a grade of {anthony.StudentGrade}");
        }
    }
}
