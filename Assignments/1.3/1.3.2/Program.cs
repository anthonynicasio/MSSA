namespace _1._3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arrays");
            string[] dogs = { "German Shepherd", "Husky", "Poodle", "Pitbull" };
            string[] cats = new string[4];
            cats[0] = "orange";
            Console.WriteLine(cats[0]);
            Console.WriteLine(dogs[dogs.Length - 1]);

        }
    }
}
