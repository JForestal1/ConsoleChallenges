using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    public class Ingredients
    {
        public enum UnitTypes
        {
            tbsp = 1,
            tsp,
            cups,
            quarts,
            gallons
        }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public UnitTypes Units { get; set; }
        public Ingredients() { }
        public Ingredients(string item, int quantity, UnitTypes Unit)
        {
            Item = item;
            Quantity = quantity;
            Units = Unit;
        }
    }
}
