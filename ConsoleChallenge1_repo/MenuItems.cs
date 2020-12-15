using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    public class MenuItems
    {
        public int MenuItem { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Ingredients> _ListOfIngredients { get; set; }

        public MenuItems() { }

        public MenuItems(int itemNumber, string name, string description, List<Ingredients> _listOfInGredients)
        {
            MenuItem = itemNumber;
            MenuName = name;
            Description = description;
            _ListOfIngredients = _listOfInGredients;
        }
    }
}
