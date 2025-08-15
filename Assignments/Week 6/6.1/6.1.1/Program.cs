namespace _6._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create a new, empty HouseList
            HouseList houseList = new HouseList();

            // 2. Add houses
            houseList.AddHouse(101, "123 Maple Street", "Single Family");
            houseList.AddHouse(102, "456 Oak Avenue", "Townhouse");
            houseList.AddHouse(103, "789 Pine Lane", "Condo");

            // 3. Search
            int searchNumber = 102;
            House foundHouse = houseList.SearchHouse(searchNumber);

            // 4. CHeck if the house was found and display the details
            if (foundHouse != null)
            {
                Console.WriteLine("House found!");
                Console.WriteLine($"House Number: {foundHouse.HouseNumber}");
                Console.WriteLine($"Address: {foundHouse.Address}");
                Console.WriteLine($"House Type: {foundHouse.HouseType}");
            }
            else
            {
                Console.WriteLine($"House with number {searchNumber} not found.");
            }

            Console.WriteLine("------------------------------");

            // 5. Remove a house
            int houseToRemove = 101;
            Console.WriteLine($"Removing house {houseToRemove}...");
            houseList.RemoveHouse(houseToRemove);

            // 6. Searching for removed house
            foundHouse = houseList.SearchHouse(houseToRemove);
            if (foundHouse == null)
            {
                Console.WriteLine($"House {houseToRemove} was successfully removed.");
            }
        }

    }
}
