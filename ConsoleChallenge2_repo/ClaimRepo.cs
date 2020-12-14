using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleChallenge2_Repo.Claim;

namespace ConsoleChallenge2_Repo
{
    // Create an instance of the claim queue
    public class ClaimRepo
    {
        Queue<Claim> ClaimQueue = new Queue<Claim>();

        // Add a claim to the queue with a complete claim
        public bool AddToQueue(Claim claimToAdd)
        {
            if (ClaimIdIsUnique(claimToAdd.ClaimID))
            {
                ClaimQueue.Enqueue(claimToAdd);
                return true;
            }
            return false;

        }

        // Add a claim to the queue with the elements of a claim
        public bool AddToQueue(int ID, ClaimType type, string description, double amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            if (ClaimIdIsUnique(ID))
            {
                Claim claimToAdd = new Claim();
                claimToAdd.ClaimID = ID;
                claimToAdd.Type = type;
                claimToAdd.Description = description;
                claimToAdd.ClaimAmount = amount;
                claimToAdd.DateOfIncident = dateOfIncident;
                claimToAdd.DateOfClaim = dateOfClaim;
                claimToAdd.IsValid = isValid;
                ClaimQueue.Enqueue(claimToAdd);
                return true;
            }
            return false;

        }
        public bool ClaimIdIsUnique(int ID)
        {
            bool idIsUnique = true;
            foreach (Claim claimToTest in ClaimQueue)
            {
                if (ID == claimToTest.ClaimID)
                {
                    idIsUnique = false;
                }
            }
            return idIsUnique;
        }
    }
}


//    // Get menu item
//    public MenuItems GetMenuItemByName(string nameToGet)
//    {
//        foreach (var itemToSearchFor in _listOfMenuItems)
//        {
//            if (itemToSearchFor.MenuName.ToLower() == nameToGet.ToLower())
//                return itemToSearchFor;
//        }

//        return null;
//    }
//    // add menu item
//    public bool AddMenuItem(MenuItems newItem)
//    {
//        int itemCountBeforeAdd = _listOfMenuItems.Count;
//        _listOfMenuItems.Add(newItem);
//        if (_listOfMenuItems.Count != itemCountBeforeAdd + 1)
//            return false;
//        else
//            return true;
//    }
//    // delete menu item
//    public bool RemoveMenuItem(string itemNameToDelelete)
//    {
//        {
//            MenuItems itemToDelete = GetMenuItemByName(itemNameToDelelete);
//            if (itemToDelete != null)
//            {
//                _listOfMenuItems.Remove(itemToDelete);
//                return true;
//            }
//            else
//                return false;
//        }
//    }
//    public bool UpdateMenuItem(string itemNameToUpdate, MenuItems itemToUpdate)
//    {
//        bool recordFound = false;

//        foreach (MenuItems allItems in _listOfMenuItems)
//        {
//            if (allItems.MenuName.ToLower() == itemNameToUpdate.ToLower())
//            {
//                recordFound = true;
//                allItems.MenuItem = itemToUpdate.MenuItem;
//                allItems.Description = itemToUpdate.Description;
//                allItems.MenuName = itemToUpdate.MenuName;
//                allItems.Price = itemToUpdate.Price;
//            }
//        }
//        return recordFound;
//    }
//    // Update menu item ingredients
//    public bool UpdateMenuItemIngredients(string itemNameToUpdate, string ingredientToEdit, Ingredients updatedIngredient)
//    {
//        bool recordFound = false;

//        foreach (MenuItems allItems in _listOfMenuItems)
//        {
//            if (allItems.MenuName.ToLower() == itemNameToUpdate.ToLower())
//            {
//                foreach (Ingredients allIngredients in allItems._ListOfIngredients)
//                {
//                    if (allIngredients.Item == ingredientToEdit)
//                    {
//                        recordFound = true;
//                        allIngredients.Item = updatedIngredient.Item;
//                        allIngredients.Quantity = updatedIngredient.Quantity;
//                        allIngredients.Units = updatedIngredient.Units;
//                    }
//                }
//            }
//        }
//        return recordFound;
//    }
//    // show all menu items
//    public List<MenuItems> GetEntireMenu()
//    {
//        return _listOfMenuItems;
//    }
//}

