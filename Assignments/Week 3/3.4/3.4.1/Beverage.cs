using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4._1
{
    public enum Container
    {
        Mug, Cup, Glass
    }
    public abstract class Beverage
    {
        public int BevID { get; set; }
        public string BevName { get; set; }
        public DateTime ExpDate { get; set; }
        public Container BevContainer { get; set; }
        public string BevMfr { get; set; }
        public double SizeInOz { get; set; }
        public string Flavor { get; set; }
        public double BevTemp { get; set; }

    }

    public class Coffee : Beverage
    {
        public string CofRoast { get; set; }
        public bool isDecaf { get; set; }
        public string TypeOfDrink { get; set; }


        public static List<Coffee> GetCoffees()
        {
            return new List<Coffee>
                {
                    new Coffee { BevID = 1, BevName = "Breakfast Blend", BevMfr = "Kirkland", BevTemp = 130, ExpDate = DateTime.Now.AddMonths(6),
                        Flavor = "Light", SizeInOz = 12, CofRoast = "Light", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 2, BevName = "French Roast", BevMfr = "Starbucks", BevTemp = 140, ExpDate = DateTime.Now.AddMonths(5),
                        Flavor = "Smoky", SizeInOz = 16, CofRoast = "Dark", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 3, BevName = "Colombian Decaf", BevMfr = "Folgers", BevTemp = 125, ExpDate = DateTime.Now.AddMonths(4),
                        Flavor = "Nutty", SizeInOz = 10, CofRoast = "Medium", isDecaf = true, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 4, BevName = "Iced Caramel", BevMfr = "Dunkin'", BevTemp = 40, ExpDate = DateTime.Now.AddMonths(2),
                        Flavor = "Caramel", SizeInOz = 16, CofRoast = "Medium", isDecaf = false, TypeOfDrink = "Iced" },
                    new Coffee { BevID = 5, BevName = "Cold Brew", BevMfr = "Stumptown", BevTemp = 38, ExpDate = DateTime.Now.AddMonths(3),
                        Flavor = "Bold", SizeInOz = 12, CofRoast = "Dark", isDecaf = false, TypeOfDrink = "Cold" },
                    new Coffee { BevID = 6, BevName = "Espresso", BevMfr = "Lavazza", BevTemp = 160, ExpDate = DateTime.Now.AddMonths(8),
                        Flavor = "Intense", SizeInOz = 2, CofRoast = "Dark", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 7, BevName = "Vanilla Latte", BevMfr = "Nespresso", BevTemp = 135, ExpDate = DateTime.Now.AddMonths(7),
                        Flavor = "Vanilla", SizeInOz = 14, CofRoast = "Medium", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 8, BevName = "Mocha", BevMfr = "Peet's", BevTemp = 140, ExpDate = DateTime.Now.AddMonths(3),
                        Flavor = "Chocolate", SizeInOz = 16, CofRoast = "Medium", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 9, BevName = "Americano", BevMfr = "Illy", BevTemp = 145, ExpDate = DateTime.Now.AddMonths(4),
                        Flavor = "Rich", SizeInOz = 12, CofRoast = "Medium", isDecaf = false, TypeOfDrink = "Hot" },
                    new Coffee { BevID = 10, BevName = "Hazelnut Brew", BevMfr = "Green Mountain", BevTemp = 130, ExpDate = DateTime.Now.AddMonths(6),
                        Flavor = "Hazelnut", SizeInOz = 12, CofRoast = "Light", isDecaf = true, TypeOfDrink = "Hot" }
                };
        }
    }
}
