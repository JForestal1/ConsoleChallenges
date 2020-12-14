using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    class ProgramUI
    {
        public MenuItemsRepo _menu = new MenuItemsRepo();

        public void Run()
        {
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool active = true;

            while (active)
            {
                Console.WriteLine("Select an Option:\n" +
                "1. Add a new menu item\n" +
                "2. Delete a menu item\n" +
                "3. View a single menu item\n" +
                "4. View entire menu\n" +
                "5. Update a Menu Item\n" +
                "6. Add ingredients to an existing menu item\n" +
                "X - Exit");

                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddMenuItem();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            DeleteMenuItem();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            ViewMenuItem();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            ViewAllMenuItems();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            UpdateItem();
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            AddIngredientsToItem();
                            break;
                        }
                    case "s1":
                        {
                            SeedMenu1();
                            break;
                        }
                    case "s2":
                        {
                            SeedMenu2();
                            break;
                        }
                    case "x":
                        {
                            Console.WriteLine("Thanks for coming by");
                            Console.Beep(1000, 500);
                            active = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid choice!");
                            break;
                        }
                }
                if (active)
                {
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Seed A Menu Item
        private void SeedMenu1()
        {
            //create working instancies for all needed stuff
            var SeedItem1 = new MenuItems();
            List<Ingredients> _ingredientsToAdd = new List<Ingredients>();
            Ingredients ingredientToSeed = new Ingredients();

            // Set seed Menu item values
            SeedItem1.MenuItem = 1;
            SeedItem1.MenuName = "Donut";
            SeedItem1.Price = 1.25;
            SeedItem1.Description = "Baked Wonderland with a hole in the middle";

            // Set ingredients list for this seed item
            ingredientToSeed.Item = "Flour";
            ingredientToSeed.Quantity = 2;
            ingredientToSeed.Units = Ingredients.UnitTypes.cups;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed);

            // Add temporary list of ingredients to temporary menu item
            SeedItem1._ListOfIngredients = _ingredientsToAdd;

            // add this menu item to the menuItem list
            _menu.AddMenuItem(SeedItem1);
        }

        private void SeedMenu2()
        {
            //create working instancies for all needed stuff
            var SeedItem1 = new MenuItems();
            List<Ingredients> _ingredientsToAdd = new List<Ingredients>();
            Ingredients ingredientToSeed = new Ingredients();
            Ingredients ingredientToSeed2 = new Ingredients();

            // Set seed Menu item values
            SeedItem1.MenuItem = 2;
            SeedItem1.MenuName = "Waffle";
            SeedItem1.Price = 2.25;
            SeedItem1.Description = "Like a pancake but with tiny cups built in for syrup";

            // Set ingredients list for this seed item
            ingredientToSeed.Item = "batter";
            ingredientToSeed.Quantity = 3;
            ingredientToSeed.Units = Ingredients.UnitTypes.cups;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed);

            ingredientToSeed2.Item = "milk";
            ingredientToSeed2.Quantity = 1;
            ingredientToSeed2.Units = Ingredients.UnitTypes.tbsp;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed2);

            // Add temporary list of ingredients to temporary menu item
            SeedItem1._ListOfIngredients = _ingredientsToAdd;

            // add this menu item to the menuItem list
            _menu.AddMenuItem(SeedItem1);
        }

        // Get A Menu Item
        private void GetSingleMenuItem()
        {
            var menuItemToView = new MenuItems();
            Console.WriteLine("\nEnter a menu item to Review:");
            string nameOfMenuItemToView = Console.ReadLine();
            DisplayMenuItem(_menu.GetMenuItemByName(nameOfMenuItemToView));

        }
        private void ViewAllMenuItems()
        {
            List<MenuItems> _ViewMenu = new List<MenuItems>();
            if (_menu.GetEntireMenu() != null)
            {
                _ViewMenu = _menu.GetEntireMenu();
                foreach (MenuItems allMenuItems in _ViewMenu)
                {
                    Console.WriteLine("----------------------------------------------------");
                    DisplayMenuItem(allMenuItems);
                }
            }
            else
                Console.WriteLine("No Menu items exist yet");
        }

        private void AddMenuItem()
        {
            // initatize stuff
            var newMenuItem = new MenuItems();
            bool active = true;
            string continueString;

            // start the input loop
            while (active)
            {
                newMenuItem = CollectMenuItemInput();
                Console.WriteLine("\nDo you wish to add ingredients to this item? (y/n)");
                continueString = Console.ReadLine();
                if (continueString.ToLower() == "y")
                {
                    // call the iingredients input helper. "" is to not prompt for a 'new' ingredient
                    newMenuItem._ListOfIngredients = CollectIngredientInput("");
                }
                if (_menu.AddMenuItem(newMenuItem))
                {
                    Console.WriteLine("Item Added\n");
                }
                else
                {
                    Console.WriteLine("Item not added");
                }
                Console.WriteLine("\nDo you wish to add another item? (y/n)");
                continueString = Console.ReadLine();
                if (continueString.ToLower() != "y")
                {
                    active = false;
                }
            }
        }
        private void AddIngredientsToItem()
        {
            // initatize stuff
            var menuItemToAddTo = new MenuItems();
            string menuItemToAddIngretientsTo;
            Console.WriteLine("\nWhich menu item would you like to add ingredients?");
            menuItemToAddIngretientsTo = Console.ReadLine();
            menuItemToAddTo = _menu.GetMenuItemByName(menuItemToAddIngretientsTo);
            menuItemToAddTo._ListOfIngredients.AddRange(CollectIngredientInput(""));
        }
        private void DisplayMenuItem(MenuItems itemToDisplay)
        {
            Console.WriteLine("Item Number: " + itemToDisplay.MenuItem);
            Console.WriteLine("Item Name: " + itemToDisplay.MenuName);
            Console.WriteLine("Item Description: " + itemToDisplay.Description);
            Console.WriteLine("Item price: " + itemToDisplay.Price);
            if (itemToDisplay._ListOfIngredients != null)
                foreach (Ingredients ingredientToDisplay in itemToDisplay._ListOfIngredients)
                {
                    Console.WriteLine("Ingredient: " + ingredientToDisplay.Item);
                    Console.WriteLine("Ingredient quantity: " + ingredientToDisplay.Quantity);
                    Console.WriteLine("Ingredient Unit of Measurement: " + ingredientToDisplay.Units);
                }
            else
            {
                Console.WriteLine("Item contains no ingredients yet");
            }
        }
        // delete menu item
        private void DeleteMenuItem()
        {
            Console.WriteLine("Enter the name of the Ingredient to delete:");
            string itemToDelete = Console.ReadLine();
            if (_menu.RemoveMenuItem(itemToDelete))
            {
                Console.WriteLine("Item Deleted");
            }
            else
            {
                Console.WriteLine("Item not deleted");
            }
        }
        // view single item
        private void ViewMenuItem()
        {
            var itemToView = new MenuItems();
            Console.WriteLine("\nEnter the name of the menu item to View:");
            string itemToDelete = Console.ReadLine();
            itemToView = _menu.GetMenuItemByName(itemToDelete);
            if (itemToView != null)
            {
                DisplayMenuItem(itemToView);
            }
            else
            {
                Console.WriteLine("Menu Item not found");
            }
        }
        private void UpdateItem()
        {
            // instatiate needed stuff
            var itemToEdit = new MenuItems();
            var ingredientToEdit = new Ingredients();

            Console.WriteLine("\nEnter the name of the menu item to update:");
            string itemNameToEdit = Console.ReadLine();
            // Get the menu item to update
            if (_menu.GetMenuItemByName(itemNameToEdit) != null)
            {
                // set initial values so a skipped assignment results in no change
                itemToEdit.MenuItem = _menu.GetMenuItemByName(itemNameToEdit).MenuItem;
                itemToEdit.MenuName = _menu.GetMenuItemByName(itemNameToEdit).MenuName;
                itemToEdit.Description = _menu.GetMenuItemByName(itemNameToEdit).Description;
                itemToEdit.Price = _menu.GetMenuItemByName(itemNameToEdit).Price;
                itemToEdit._ListOfIngredients = _menu.GetMenuItemByName(itemNameToEdit)._ListOfIngredients;
                // the the current version of the item
                Console.WriteLine("\nCurrent menu item information:");
                DisplayMenuItem(itemToEdit);
                // start getting new values. enter to leave unchanged
                Console.WriteLine("\nEnter new item number (enter to leave unchanged):");
                string newDataString = Console.ReadLine();
                if (newDataString != "")
                {
                    itemToEdit.MenuItem = Int32.Parse(newDataString);
                }
                Console.WriteLine("\nEnter new item name (enter to leave unchanged):");
                newDataString = Console.ReadLine();
                if (newDataString != "")
                {
                    itemToEdit.MenuName = newDataString;
                }
                Console.WriteLine("\nEnter new item description (enter to leave unchanged):");
                newDataString = Console.ReadLine();
                if (newDataString != "")
                {
                    itemToEdit.Description = newDataString;
                }
                Console.WriteLine("\nEnter new item price (enter to leave unchanged):");
                newDataString = Console.ReadLine();
                if (newDataString != "")
                {
                    itemToEdit.Price = Double.Parse(newDataString);
                }
                // cal the CRUD method for update. returns true if change made
                if (_menu.UpdateMenuItem(itemNameToEdit, itemToEdit))
                {
                    Console.WriteLine("Menu item updated");
                }
                else
                {
                    Console.WriteLine("Menu item not updated");
                }
                // cannot update an empty list of ingredients
                // ----- should create a method to add ingredients to an already existing menu
                if (itemToEdit._ListOfIngredients != null)
                {
                    Console.WriteLine("Do you wish to edit the ingredients as well (y/n)?");
                    string editIngredientsString = Console.ReadLine();
                    if (editIngredientsString.ToLower() == "y")
                    {
                        bool active = true;
                        string toContinueToEdit = "f";
                        string ingredientToUpdate;
                        while (active)
                        {
                            Console.WriteLine("\n Which ingredient would you like to edit");
                            ingredientToUpdate = Console.ReadLine();
                            // call CRUD to update ingredients, passing the results of the get ingredients helper
                            _menu.UpdateMenuItemIngredients(itemNameToEdit, ingredientToUpdate, GetSingleIngredient("new "));
                            Console.WriteLine("\n Would you like to edit more ingredients (y/n)");
                            toContinueToEdit = Console.ReadLine();
                            if (toContinueToEdit.ToLower() != "y")
                            {
                                active = false;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Menu Item not found");
            }
        }
        // helper UI for collecting Menu Item Input
        private MenuItems CollectMenuItemInput()
        {
            var newMenuItem = new MenuItems();
            // call helper to get item number - it has some error handling
            newMenuItem.MenuItem = InputIntegerHelper("Enter the Menu Item Number:");
            Console.WriteLine("Enter Item Name");
            newMenuItem.MenuName = Console.ReadLine();
            Console.WriteLine("Enter Item Description:");
            newMenuItem.Description = Console.ReadLine();
            // Call helper to get cost - it has some error handling  
            newMenuItem.Price = InputCostInputHelper("Enter the Item Cost:");
            return newMenuItem;
        }
        // helper UI for collecting Ingredient Item Input
        private List<Ingredients> CollectIngredientInput(string isNew)
        {
            var newIngredient = new Ingredients();
            var _newListOfIngredients = new List<Ingredients>();
            string addMoreIngredientsString = "";
            bool addMore = true;
            while (addMore)
            {
                newIngredient = GetSingleIngredient("");
                _newListOfIngredients.Add(newIngredient);
                Console.WriteLine("\nDo you wish to add another ingredient to this menu item? (y/n)");
                addMoreIngredientsString = Console.ReadLine();
                if (addMoreIngredientsString.ToLower() == "n")
                {
                    addMore = false;
                }
            }
            return _newListOfIngredients;
        }
        // helper to get a single ingredient
        private Ingredients GetSingleIngredient(string isNew)
        {
            var newIngredient = new Ingredients();
            Console.WriteLine("\nEnter the " + isNew + "ingredient name:");
            newIngredient.Item = Console.ReadLine();
            Console.WriteLine("\nEnter " + isNew + "units of measurement:\n" +
                    "1) tbsp\n" +
                    "2) tsp\n" +
                    "3) cups\n" +
                    "4) quarts\n" +
                    "5) gallons");
            string unitOfMeasurementString = Console.ReadLine();
            switch (unitOfMeasurementString.ToLower())
            {
                case "1":
                    {
                        newIngredient.Units = Ingredients.UnitTypes.tbsp;
                        break;
                    }
                case "2":
                    {
                        newIngredient.Units = Ingredients.UnitTypes.tsp;
                        break;
                    }
                case "3":
                    {
                        newIngredient.Units = Ingredients.UnitTypes.cups;
                        break;
                    }
                case "4":
                    {
                        newIngredient.Units = Ingredients.UnitTypes.quarts;
                        break;
                    }
                case "5":
                    {
                        newIngredient.Units = Ingredients.UnitTypes.gallons;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input. Defaulting to cups");
                        newIngredient.Units = Ingredients.UnitTypes.cups;
                        break;
                    }
            }
            newIngredient.Quantity = InputIntegerHelper("\nEnter the" + isNew + " quantity of this ingredient:");
            return newIngredient;
        }
        private int InputIntegerHelper(string prompt)
        {
            bool goodIntItem = false;
            int returnInt = 0;
            while (!goodIntItem)
            {
                Console.WriteLine(prompt);
                if (Int32.TryParse(Console.ReadLine(), out int itemInt))
                {
                    returnInt = itemInt;
                    goodIntItem = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Enter a numeric Item Number.");
                }
            }
            return returnInt;
        }

        private double InputCostInputHelper(string prompt)
        {
            bool goodCost = false;
            double inputCost = 0;
            while (!goodCost)
            {
                Console.WriteLine(prompt);
                string costAsString = Console.ReadLine();
                double costDouble;
                if (double.TryParse(costAsString, out costDouble))
                {
                    inputCost = costDouble;
                    goodCost = true;
                }
                else
                {
                    Console.WriteLine("Invalid cost input. Use the format #.##");
                }
            }
            return inputCost;
        }
    }
}