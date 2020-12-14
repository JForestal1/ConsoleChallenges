using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    public class MenuItemsRepo
    {
        // Instantiate the list of menu items
        List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        // Get menu item
        public MenuItems GetMenuItemByName(string nameToGet)
        {
            foreach (var itemToSearchFor in _listOfMenuItems)
            {
                if (itemToSearchFor.MenuName.ToLower() == nameToGet.ToLower())
                    return itemToSearchFor;
            }

            return null;
        }
        // add menu item
        public bool AddMenuItem(MenuItems newItem)
        {
            int itemCountBeforeAdd = _listOfMenuItems.Count;
            _listOfMenuItems.Add(newItem);
            if (_listOfMenuItems.Count != itemCountBeforeAdd + 1)
                return false;
            else
                return true;
        }
        // delete menu item
        public bool RemoveMenuItem(string itemNameToDelelete)
        {
            {
                MenuItems itemToDelete = GetMenuItemByName(itemNameToDelelete);
                if (itemToDelete != null)
                {
                    _listOfMenuItems.Remove(itemToDelete);
                    return true;
                }
                else
                    return false;
            }
        }
        public bool UpdateMenuItem(string itemNameToUpdate, MenuItems itemToUpdate)
        {
            bool recordFound = false;

            foreach (MenuItems allItems in _listOfMenuItems)
            {
                if (allItems.MenuName.ToLower() == itemNameToUpdate.ToLower())
                {
                    recordFound = true;
                    allItems.MenuItem = itemToUpdate.MenuItem;
                    allItems.Description = itemToUpdate.Description;
                    allItems.MenuName = itemToUpdate.MenuName;
                    allItems.Price = itemToUpdate.Price;
                }
            }
            return recordFound;
        }
        // Update menu item ingredients
        public bool UpdateMenuItemIngredients(string itemNameToUpdate, string ingredientToEdit, Ingredients updatedIngredient)
        {
            bool recordFound = false;

            foreach (MenuItems allItems in _listOfMenuItems)
            {
                if (allItems.MenuName.ToLower() == itemNameToUpdate.ToLower())
                {
                    foreach (Ingredients allIngredients in allItems._ListOfIngredients)
                    {
                        if (allIngredients.Item == ingredientToEdit)
                        {
                            recordFound = true;
                            allIngredients.Item = updatedIngredient.Item;
                            allIngredients.Quantity = updatedIngredient.Quantity;
                            allIngredients.Units = updatedIngredient.Units;
                        }
                    }
                }
            }
            return recordFound;
        }
        // show all menu items
        public List<MenuItems> GetEntireMenu()
        {
            return _listOfMenuItems;
        }
    }
}
