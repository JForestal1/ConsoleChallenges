using ConsoleChallenge5_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge5
{
    class ProgramUI
    {
        // instantiate the list of customers
        public CustomerRepo customerList = new CustomerRepo();

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
                "1. Add a Customer event\n" +
                "2. View all customers\n" +
                "3. Modify an existing customer\n" +
                "4. Delete a customer\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddCustomer();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            DisplayAllCustomers();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            UpdateCustomer();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            DeleteCustomer();
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
        public void AddCustomer()
        {
            Console.WriteLine("Enter the new customers first name:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter the new customers last name:");
            string last = Console.ReadLine();
            Customer.CustomerType newCustType = InputEventTypeHelper("\nEnter the type of customer this is:");
            // test cutomertype and addcustomer. if both true, customer was added
            if (newCustType != Customer.CustomerType.Invalid && customerList.AddCustomer(first, last, newCustType))
            {
                Console.WriteLine("\nCustomer added.");
            }
            else
            {
                Console.WriteLine("\nCustomer not added.");
            }
        }
        public void DisplayAllCustomers()
        {
            {
                // Display headings
                DisplayHeadingsHelper();
                if (customerList.GetAllCustomers().Count != 0)
                    foreach (KeyValuePair<string, Customer> each in customerList.GetAllCustomers())
                    {
                        DisplaySingleOutingHelper(each.Value);
                    }
            }
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Enter the first name of the customer you would like to delete:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter the last name of the customer you would like to delete:");
            string last = Console.ReadLine();
            if (customerList.DeleteCustomer(first, last))
            {
                Console.WriteLine("Customer record deleted.");
            }
            else
            {
                Console.WriteLine("Customer not found. No deletion occured.");
            }
        }
        private void UpdateCustomer()
        {
            Console.WriteLine("Enter the first name of the customer you would like to edit:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter the last name of the customer you would like to edit:");
            string last = Console.ReadLine();
            // reusing KeyIsDelete to ensure customer key exists
            if (!customerList.KeyIsUnique(last + first))
            {
                Console.WriteLine("Enter the new first name of this customer:");
                string newFirst = Console.ReadLine();
                Console.WriteLine("Enter the new last name of this customer:");
                string newLast = Console.ReadLine();
                Customer.CustomerType newCustType = InputEventTypeHelper("\nEnter the type of customer this is:");
                if (newCustType != Customer.CustomerType.Invalid)
                {
                    Customer newCustomer = new Customer(newFirst, newLast, newCustType);
                    if (customerList.UpdateCustomer(first, last, newCustomer))
                    {
                        Console.WriteLine("Customer Updated.");
                    }
                    else
                    {
                        Console.WriteLine("Customer not updated. New customer name must be unique.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }

        }

        private Customer.CustomerType InputEventTypeHelper(string prompt)
        {
            Customer.CustomerType typeToReturn;
            Console.WriteLine("\n" + prompt +
                "\n\t1. Potential" +
                "\n\t2. Current" +
                "\n\t3. Past\n");
            var eventTypeString = Console.ReadLine();
            switch (eventTypeString.ToLower())
            {
                case "1":
                    {
                        typeToReturn = Customer.CustomerType.Potential;
                        break;
                    }
                case "2":
                    {
                        typeToReturn = Customer.CustomerType.Current;
                        break;
                    }
                case "3":
                    {
                        typeToReturn = Customer.CustomerType.Potential;
                        break;
                    }
                case "4":
                default:
                    {
                        typeToReturn = Customer.CustomerType.Invalid;
                        Console.WriteLine("\nThat event type is not valid");
                        break;
                    }
            }
            return typeToReturn;
        }
        public void DisplayHeadingsHelper()
        {
            string headings = string.Format("{0,-20}", "First Name");
            headings += string.Format("{0,-20}", "Last Name");
            headings += string.Format("{0,-15}", "Customer Type");
            headings += string.Format("{0,-20}", "Email Message");
            Console.WriteLine(headings);
        }

        public void DisplaySingleOutingHelper(Customer customerToDisplay)
        {
            string claimDisplay = string.Format("{0,-20}", customerToDisplay.FirstName);
            claimDisplay += string.Format("{0,-20}", customerToDisplay.LastName);
            claimDisplay += string.Format("{0,-15}", customerToDisplay.Type);
            claimDisplay += string.Format("{0,-20}", customerToDisplay.EmailGreeting);
            Console.WriteLine(claimDisplay);
        }
    }
}