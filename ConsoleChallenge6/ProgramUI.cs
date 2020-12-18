using ConsoleChallenge6_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge6
{
    class ProgramUI
    {
        // instantiate the list of customers
        public CarRepo carRepo = new CarRepo();

        public void Run()
        {
            Menu();
        }
        public void Menu()
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("Select an Option:\n" +
                "1. Add a car\n" +
                "2. View all cars\n" +
                "3. Modify an existing car\n" +
                "4. Delete a car\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddCar();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            DisplayAllCars();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            UpdateCar();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            DeleteCar();
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
        private void AddCar()
        {
            int listCountCheck = carRepo.GetAllCars().Count;
            Console.WriteLine("Enter the new car name:");
            string name = Console.ReadLine();
            int numDoors = InputIntHelper("\nEnter the number of doors on this car:", "\nEnter the number of doors as a whole number");
            double price = InputDoubleHelper("\nEnter the vehicle price(#####.##)", "\nEnter the vehicle price(#####.##) without $");
            Console.WriteLine("\nEnter the new car type (1. Gas, 2. Hybred, 3. Electric)");
            string type = Console.ReadLine();
            switch (type.ToLower())
            {
                case "1":
                    {
                        double MPG = InputDoubleHelper("\nEnter the Miles Per Gallon (MPG) for car:", "\nEnter the Miles Per Gallon (MPG) as a whole number");
                        int fuelTankSize = InputIntHelper("\nEnter the fuel capacity for car in gallons:", "\nEnter the fuel capacity as a whole number");
                        carRepo.AddCar(new Gas(name, numDoors, price, MPG, fuelTankSize));
                        break;
                    }
                case "2":
                    {
                        double MPG = InputDoubleHelper("\nEnter the Miles Per Gallon (MPG) for car:", "\nEnter the Miles Per Gallon (MPG) as a whole number");
                        int power = InputIntHelper("\nEnter the horsepower for car:", "\nEnter the horsepower as a whole number");
                        carRepo.AddCar(new Hybred(name, numDoors, price, MPG, power));
                        break;
                    }
                case "3":
                    {
                        int range = InputIntHelper("\nEnter the range for car:", "\nEnter the range as a whole number");
                        carRepo.AddCar(new Electric(name, numDoors, price, range));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nVehicles are limited to these three types only");
                        break;
                    }
            }
            // check to see if teh list if larger (add successful)
            if (listCountCheck < carRepo.GetAllCars().Count)
            {
                Console.WriteLine("\nCar added to the list");
            }
            else
            {
                Console.WriteLine("\nCar not added to the list");
            }
        }
        private void DisplayAllCars()
        {
            List<Car> _displayList = new List<Car>();
            _displayList = carRepo.GetAllCars();
            DisplayHeadingsHelper();
            foreach (Car each in _displayList)
            {
                if (each.Type == "Gas")
                    DisplayGasHelper((Gas)each);
                if (each.Type == "Electric")
                    DisplayElectricHelper((Electric)each);
                if (each.Type == "Hybred")
                    DisplayHybredHelper((Hybred)each);
            }
        }
        private void UpdateCar()
        {
            int listCountCheck = carRepo.GetAllCars().Count;
            Console.WriteLine("\nEnter the car to update:");
            string name = Console.ReadLine();
            // see if the car exists
            if (carRepo.GetOneCar(name) != null)
            {
                Console.WriteLine("\nEnter the new car name:");
                string newName = Console.ReadLine();
                int numDoors = InputIntHelper("\nEnter the new number of doors on this car:", "\nEnter the number of doors as a whole number");
                double price = InputDoubleHelper("\nEnter the new vehicle price(#####.##)", "\nEnter the vehicle price(#####.##) without $");
                Console.WriteLine("\nEnter the new car type (1. Gas, 2. Hybred, 3. Electric)");
                string type = Console.ReadLine();
                switch (type.ToLower())
                {
                    case "1":
                        {
                            double MPG = InputDoubleHelper("\nEnter the Miles Per Gallon (MPG) for car:", "\nEnter the Miles Per Gallon (MPG) as a whole number");
                            int fuelTankSize = InputIntHelper("\nEnter the fuel capacity for car in gallons:", "\nEnter the fuel capacity as a whole number");
                            carRepo.UpdateCar(name, new Gas(newName, numDoors, price, MPG, fuelTankSize));
                            break;
                        }
                    case "2":
                        {
                            double MPG = InputDoubleHelper("\nEnter the new Miles Per Gallon (MPG) for car:", "\nEnter the Miles Per Gallon (MPG) as a whole number");
                            int power = InputIntHelper("\nEnter the new horsepower for car:", "\nEnter the horsepower as a whole number");
                            carRepo.UpdateCar(name, new Hybred(newName, numDoors, price, MPG, power));
                            break;
                        }
                    case "3":
                        {
                            int range = InputIntHelper("\nEnter the range for car:", "\nEnter the range as a whole number");
                            carRepo.UpdateCar(name, new Electric(name, numDoors, price, range));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nVehicles are limited to these three types only");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("\nNo car with that name has been entered.");
            }
        }
        private void DeleteCar()
        {
            int listCountCheck = carRepo.GetAllCars().Count;
            Console.WriteLine("\nEnter the name of the car to remove:");
            string name = Console.ReadLine();
            if (carRepo.DeleteCar(name))
            {
                Console.WriteLine("\nCar removed.");
            }
            else
            {
                Console.WriteLine("\nNo car with that name has been entered.");
            }
        }
        public void DisplayHeadingsHelper()
        {
            string headings = string.Format("{0,-10}", "Name");
            headings += string.Format("{0,-10}", "Type");
            headings += string.Format("{0,-12}", "# of Doors");
            headings += string.Format("{0,-10}", "Price");
            headings += string.Format("{0,-10}", "MPG");
            headings += string.Format("{0,-15}", "Horsepower");
            headings += string.Format("{0,-15}", "Fuel Capacity");
            headings += string.Format("{0,-10}", "Range");
            Console.WriteLine(headings);
        }
        public void DisplayElectricHelper(Electric carToDisplay)
        {
            string carDisplay = string.Format("{0,-10}", carToDisplay.Name);
            carDisplay += string.Format("{0,-15}", carToDisplay.Type);
            carDisplay += string.Format("{0,-7}", carToDisplay.Doors);
            carDisplay += string.Format("{0,-10}", "$" + carToDisplay.Price);
            carDisplay += string.Format("{0,43}", carToDisplay.Range);
            Console.WriteLine(carDisplay);
        }
        public void DisplayGasHelper(Gas carToDisplay)
        {
            string carDisplay = string.Format("{0,-10}", carToDisplay.Name);
            carDisplay += string.Format("{0,-15}", carToDisplay.Type);
            carDisplay += string.Format("{0,-7}", carToDisplay.Doors);
            carDisplay += string.Format("{0,-10}", "$" + carToDisplay.Price);
            carDisplay += string.Format("{0,-29}", carToDisplay.MilesPerGallon);
            carDisplay += string.Format("{0,-5}", carToDisplay.FuelCapacity);
            Console.WriteLine(carDisplay);
        }
        public void DisplayHybredHelper(Hybred carToDisplay)
        {
            string carDisplay = string.Format("{0,-10}", carToDisplay.Name);
            carDisplay += string.Format("{0,-15}", carToDisplay.Type);
            carDisplay += string.Format("{0,-7}", carToDisplay.Doors);
            carDisplay += string.Format("{0,-10}", "$" + carToDisplay.Price);
            carDisplay += string.Format("{0,-13}", carToDisplay.MilesPerGallon);
            carDisplay += string.Format("{0,-20}", carToDisplay.Horsepower);
            Console.WriteLine(carDisplay);
        }
        private int InputIntHelper(string prompt, string errorPrompt)
        {
            bool goodInt = false;
            int inputInt = 0;
            while (!goodInt)
            {
                Console.WriteLine(prompt);
                string intAsString = Console.ReadLine();
                int parsedInt;
                if (Int32.TryParse(intAsString, out parsedInt))
                {
                    inputInt = parsedInt;
                    goodInt = true;
                }
                else
                {
                    Console.WriteLine(errorPrompt);
                }
            }
            return inputInt;
        }
        private double InputDoubleHelper(string prompt, string errorPrompt)
        {
            bool goodDouble = false;
            double inputDouble = 0;
            Console.WriteLine(prompt);
            while (!goodDouble)
            {
                string DoubleAsString = Console.ReadLine();
                double parsedDouble;
                if (double.TryParse(DoubleAsString, out parsedDouble))
                {
                    inputDouble = parsedDouble;
                    goodDouble = true;
                }
                else
                {
                    Console.WriteLine(errorPrompt);
                }
            }
            return inputDouble;
        }
    }
}

