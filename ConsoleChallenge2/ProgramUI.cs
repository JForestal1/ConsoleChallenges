using ConsoleChallenge2_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge2
{
    class ProgramUI
    {
        // Instantiate the claim repo
        public ClaimRepo queueOfClaims = new ClaimRepo();

        public void Run()
        {
            Menu();
        }

        // Menu

        public void Menu()
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("Select an Option:\n" +
                "1. See All Claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            ViewAllClaims();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            GetNextClaim();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            AddClaim();
                            break;
                        }
                    case "s":
                        {
                            Console.Clear();
                            queueOfClaims.SeedQueue();
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

        public void ViewAllClaims()
        {
            DisplayHeadingsHelper();
            foreach (Claim claimToView in queueOfClaims.GetEntireQueue())
            {
                DisplaySingleClaimHelper(claimToView);
            }
        }

        public void GetNextClaim()
        {
            if (queueOfClaims.GetCurrentClaim() != null)
            {
                Claim currentClaim = new Claim();
                currentClaim = queueOfClaims.GetCurrentClaim();
                DisplayHeadingsHelper();
                DisplaySingleClaimHelper(currentClaim);
                Console.WriteLine("\nDo you want to deal with this claim now (y/n)");
                string response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    if (queueOfClaims.ProcessClaim())
                    {
                        Console.WriteLine("Item has been processed");
                    }
                    else
                    {
                        Console.WriteLine("Item has not been processed");
                    }
                }
            }
            else
            {
                Console.WriteLine("The claim queue is empty");
            }

        }

        public void AddClaim()
        {
            var newClaim = new Claim();
            // get claim ID
            Console.WriteLine("Enter Claim ID:");
            newClaim.ClaimID = Int32.Parse(Console.ReadLine());
            // Get claim type
            Console.WriteLine("Enter the type of claim (1. Car, 2. Home, 3. Theft)");
            string claimTypeString = Console.ReadLine();
            bool active = true;
            while (active)
            {
                switch (claimTypeString.ToLower())
                {
                    case "1":
                        {
                            newClaim.Type = Claim.ClaimType.Car;
                            active = false;
                            break;
                        }
                    case "2":
                        {
                            newClaim.Type = Claim.ClaimType.Home;
                            active = false;
                            break;
                        }
                    case "3":
                        {
                            newClaim.Type = Claim.ClaimType.Theft;
                            active = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter the valid type of claim (1.Car, 2.Home, 3.Theft)");
                            break;
                        }
                }
            }
            // Get claim Description
            Console.WriteLine("Enter claim description:");
            newClaim.Description = Console.ReadLine();
            //get ammount - write helper
            newClaim.ClaimAmount = InputDoubleHelper("Enter the claim amount:", "Enter claim ammount in the format #.## without $ sign.");
            // get Date of Incident
            newClaim.DateOfIncident = InputDateHelper("Enter the incident date (MM/DD/YYYY):", "Enter incident date in the format MM/DD/YYYY.");
            // get Date of Claim
            newClaim.DateOfClaim = InputDateHelper("Enter the claim date (MM/DD/YYYY):", "Enter claim date in the format MM/DD/YYYY.");
            // get IsValid - this will be confirmed or overwritten in the add method based on business rules
            newClaim.IsValid = true;
            // Add to the queue
            queueOfClaims.AddToQueue(newClaim);
        }

        public void DisplayHeadingsHelper()
        {
            string headings = string.Format("{0,-10}", "ClaimID");
            headings += string.Format("{0,-10}", "Type");
            headings += string.Format("{0,-25}", "Description");
            headings += string.Format("{0,-10}", "Amount");
            headings += string.Format("{0,-20}", "Date of Incident");
            headings += string.Format("{0,-15}", "Date of Claim");
            headings += string.Format("{0,-15}", "Is Claim Valid");
            Console.WriteLine(headings);
        }

        public void DisplaySingleClaimHelper(Claim claimToView)
        {
            string claimDisplay = string.Format("{0,-10}", claimToView.ClaimID.ToString());
            claimDisplay += string.Format("{0,-10}", claimToView.Type.ToString());
            claimDisplay += string.Format("{0,-25}", claimToView.Description);
            claimDisplay += string.Format("{0,-10}", "$" + claimToView.ClaimAmount.ToString());
            claimDisplay += string.Format("{0,-20}", claimToView.DateOfIncident.ToShortDateString());
            claimDisplay += string.Format("{0,-15}", claimToView.DateOfClaim.ToShortDateString());
            claimDisplay += string.Format("{0,-15}", claimToView.IsValid.ToString());
            Console.WriteLine(claimDisplay);
        }
        private double InputDoubleHelper(string prompt, string errorPrompt)
        {
            bool goodDouble = false;
            double inputDouble = 0;
            while (!goodDouble)
            {
                Console.WriteLine(prompt);
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
        public DateTime InputDateHelper(string prompt, string errorPrompt)
        {
            bool goodDate = false;
            DateTime inputDate = DateTime.Today;
            while (!goodDate)
            {
                Console.WriteLine(prompt);
                string DateAsString = Console.ReadLine();
                DateTime parsedDate;
                if (DateTime.TryParse(DateAsString, out parsedDate))
                {
                    inputDate = parsedDate;
                    goodDate = true;
                }
                else
                {
                    Console.WriteLine(errorPrompt);
                }
            }
            return inputDate;
        }
    }
}
