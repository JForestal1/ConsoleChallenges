using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge6_repo
{
    public class Car
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Doors { get; set; }
        public double Price { get; set; }
    }

    public class Hybred : Car
    {
        public double MilesPerGallon { get; set; }
        public int Horsepower { get; set; }
        public Hybred() 
        {
            Type = "Hybred";
        }

        public Hybred(string name, int doors, double price, double MPG, int horsepower)
        {
            Name = name;
            Type = "Hybred";
            Doors = doors;
            Price = price;
            MilesPerGallon = MPG;
            Horsepower = horsepower;
        }
    }
    public class Gas : Car
    {
        public double MilesPerGallon { get; set; }
        public int FuelCapacity { get; set; }
        public Gas() 
        {
            Type = "Gas";
        }

        public Gas(string name, int doors, double price, double MPG, int capacity)
        {
            Name = name;
            Type = "Gas";
            Doors = doors;
            Price = price;
            MilesPerGallon = MPG;
            FuelCapacity = capacity;
        }
    }
    public class Electric : Car
    {
        public int Range { get; set; }
        public Electric() 
        {
            Type = "Electric";
        }

        public Electric(string name, int doors, double price, int range)
        {
            Name = name;
            Type = "Electric";
            Doors = doors;
            Price = price;
            Range = range;
        }
    }
}
