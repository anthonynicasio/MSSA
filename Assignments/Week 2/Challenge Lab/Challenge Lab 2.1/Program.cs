namespace Challenge_Lab_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperatureFarenheit = TemperatureValidation.ReadValidTemperature();

            string message = temperatureFarenheit switch
            {
                <= 10 => "Freezing weather",
                >= 11 and <= 20 => "Very Cold weather",
                >= 21 and <= 35 => "Cold weather",
                >= 36 and <= 50 => "Normal in weather",
                >= 51 and <= 65 => "It's hot",
                >= 66 and <= 80 => "It's very hot",
                _ => "It's extremely hot"
            };

            Console.WriteLine(message);
        }
    }
}
