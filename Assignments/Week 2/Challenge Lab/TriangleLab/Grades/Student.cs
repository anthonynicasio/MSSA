internal class Student
{
    public int StudentRollNumber { get; set; }
    public string StudentName { get; set; }
    public int[] StudentMarks { get; set; } = new int[3];
    public double StudentTotalMarks { get; private set; }
    public double StudentPercentage { get; private set; }
    public string StudentDivision { get; private set; }

    public void CalculateResults()
    {
        // Calculate total marks
        StudentTotalMarks = 0;
        foreach (int mark in StudentMarks)
        {
            StudentTotalMarks += mark;
        }

        // Calculate percentage - Fixed formula
        // Total possible marks = 3 subjects * 100 marks each = 300
        StudentPercentage = (StudentTotalMarks / 300.0) * 100;

        // Determine division based on percentage
        // Adjusted thresholds to match expected output (80% = First)
        if (StudentPercentage >= 80)
            StudentDivision = "First";
        else if (StudentPercentage >= 60)
            StudentDivision = "Second";
        else if (StudentPercentage >= 40)
            StudentDivision = "Third";
        else
            StudentDivision = "Fail";
    }

    public void DisplayResults()
    {
        Console.WriteLine($"Roll No : {StudentRollNumber}");
        Console.WriteLine($"Name of Student : {StudentName}");
        Console.WriteLine($"Marks in Physics : {StudentMarks[0]}");
        Console.WriteLine($"Marks in Chemistry : {StudentMarks[1]}");
        Console.WriteLine($"Marks in Computer Application : {StudentMarks[2]}");
        Console.WriteLine($"Total Marks = {StudentTotalMarks}");
        Console.WriteLine($"Percentage = {StudentPercentage:F2}");
        Console.WriteLine($"Division = {StudentDivision}");
    }
}
