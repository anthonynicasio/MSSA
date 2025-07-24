namespace _1._3._1
{
    internal class Program
    {
        static void AreaOfTriangle()
        {
            Console.WriteLine("Area of a Triangle:");
            Console.WriteLine("What is the base of the triangle?");
            double triangleBase = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is the height of the triangle?");
            double triangleHeight = Convert.ToDouble(Console.ReadLine());
            double triangleArea = 0.5 * (triangleBase * triangleHeight);
            Console.WriteLine($"The area of your triangle is {triangleArea}.\n");
        }

        static void AreaOfSquare()
        {
            Console.WriteLine("Area of a Square");
            Console.WriteLine("What is the length of any side of your square?");
            double sideA = Convert.ToDouble(Console.ReadLine());
            double squareArea = sideA * sideA;
            Console.WriteLine($"The area of your square is {squareArea}.\n");
        }

        static void AreaOfRectangle()
        {
            Console.WriteLine("Area of a Rectangle");
            Console.WriteLine("What is the length of your rectangle?");
            double rectLength = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is the height of your rectangle?");
            double rectHeight = Convert.ToDouble(Console.ReadLine());
            double rectArea = rectLength * rectHeight;
            Console.WriteLine($"The area of your rectangle is {rectArea}.\n");

        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome! What type of calculation do you need? \n" +
                    "1. Area of a Triangle\n" +
                    "2. Area of a Square\n" +
                    "3. Area of a Rectangle\n" +
                    "0. Exit");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                    case 1:
                        AreaOfTriangle();
                        break;
                    case 2:
                        AreaOfSquare();
                        break;
                    case 3:
                        AreaOfRectangle();
                        break;
                }
            }
        }
    }
}
