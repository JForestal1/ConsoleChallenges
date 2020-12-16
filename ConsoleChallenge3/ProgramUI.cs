using ConsoleChallenge3_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge3
{
    class ProgramUI
    {
        // Instantiate the badge Repo
        public BadgeRepo Badges = new BadgeRepo();

        public void Run()
        {
            Menu();
        }

        // Menu

        public void Menu()
        {
            bool active = true;
            Badges.SeedUtility();
            while (active)
            {
                Console.WriteLine("Select an Option:\n" +
                "1. Add a Badge\n" +
                "2. Edit a Badge\n" +
                "3. List All Badges\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddBadge();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            UpdateBadge();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            GetAllBadges();
                            break;
                        }
                    case "s":
                        {
                            Console.Clear();
                            //queueOfClaims.SeedQueue();
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

        public void AddBadge()
        {
            // creating working list of doors
            List<string> _doorsToAdd = new List<string>();
            // invoke the helper to get a valid int
            int newBadgeNumber = InputIntHelper("\n What is the number on the badge:", "\nEnter an Integer badge Number.");
            // test badgeID for uniqueness
            if (Badges.BadgeNumberIsUnique(newBadgeNumber))
            {
                // Get doors into a list of strings
                bool active = true;
                string addMore;
                while (active)
                {
                    Console.WriteLine("\nList a door that it needs access to:");
                    _doorsToAdd.Add(Console.ReadLine());
                    Console.WriteLine("\nAny other doors (y/n)?");
                    addMore = Console.ReadLine();
                    if (addMore.ToLower() != "y")
                    {
                        active = false;
                    }
                }
                // call repo, will return true is successful
                if (Badges.AddBadge(newBadgeNumber, _doorsToAdd))
                {
                    Console.WriteLine("Door added.");
                }
                else
                {
                    Console.WriteLine("Door not added.");
                }
            }
            else
            {
                Console.WriteLine("New badge number must be unique.");
            }
        }

        private void GetAllBadges()
        {
            var badgesToDisplay = new Dictionary<int, List<string>>();
            // call the Get All Badges method
            badgesToDisplay = Badges.GetAllBadges();
            // display header
            string headings = string.Format("{0,-10}", "Badge #");
            headings += string.Format("{0,-10}", "Door Access");
            Console.WriteLine(headings);
            // display each badge
            foreach (KeyValuePair<int, List<string>> badge in badgesToDisplay)
            {
                string badgeDisplay = string.Format("{0,-10}", badge.Key, "\t");
                for (int index = 0; index < badge.Value.Count; index++)
                {
                    badgeDisplay += badge.Value[index];
                    // ony seperate with comma if not the last door
                    if (index < badge.Value.Count - 1)
                    {
                        badgeDisplay += ", ";
                    }
                }
                Console.WriteLine(badgeDisplay);
            }
        }

        private void UpdateBadge()
        {
            var _workingListOfDoors = new List<string>();

            int badgeNumToUpdate = InputIntHelper("\nWhat is the badge number to Update?", "\nEnter an Integer badge Number.");
            var badgeToUpdate = Badges.GetSingleBadge(badgeNumToUpdate);
            string infoLine;
            if (badgeToUpdate == null)
            {
                Console.WriteLine("That badge is not active");
            }
            else
            {
                _workingListOfDoors = badgeToUpdate.Doors;
                infoLine = updateInfoLineHelper(badgeToUpdate);
                Console.WriteLine(infoLine);
                // sub menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\t 1. Remove a door");
                Console.WriteLine("\t 2. Add a door");
                Console.WriteLine("\t 1. Remove all doors");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("\nWhich door would you like to remove?");
                            var doorToRemove = Console.ReadLine();
                            //remove teh door from the working list.will return false if the door doesn't exist
                            if (!_workingListOfDoors.Remove(doorToRemove))
                            {
                                Console.WriteLine("\nThat badge does not have access to that door");
                            }
                            //call the update method to update the dictionary
                            Badges.UpdateDoors(badgeNumToUpdate, _workingListOfDoors);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("\n Which door would you like to add?");
                            var doorToRemove = Console.ReadLine();
                            _workingListOfDoors.Add(doorToRemove);
                            //call the update method to update the dictionary
                            Badges.UpdateDoors(badgeNumToUpdate, _workingListOfDoors);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("\n Are you sure you want to remove all door access (y/n)");
                            string confirm = Console.ReadLine();
                            if (confirm.ToLower() == "y")
                            {
                                //    call the update method to delete all doors
                                Badges.DeleteAllDoors(badgeNumToUpdate);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid selection");
                            break;
                        }
                }
                Console.WriteLine(updateInfoLineHelper(Badges.GetSingleBadge(badgeNumToUpdate)));
            }
        }
        public string updateInfoLineHelper(Badge badgeToUpdate)
        {
            string infoLine = "\n";
            if (badgeToUpdate.Doors.Count == 0)
            {
                infoLine += badgeToUpdate.BadgeID + " currently has no access to doors.";
            }
            else
            {
                infoLine += "\n" + badgeToUpdate.BadgeID + " has access to doors ";
                for (int index = 0; index < badgeToUpdate.Doors.Count; index++)
                {
                    infoLine += badgeToUpdate.Doors[index];
                    // ony seperate with comma if not the last door
                    if (index < badgeToUpdate.Doors.Count - 1)
                    {
                        infoLine += ", ";
                    }
                }
            }

            return infoLine;
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

    }
}



//        public void AddClaim()
//        {
//            var newClaim = new Claim();
//            // get claim ID
//            Console.WriteLine("Enter Claim ID:");
//            newClaim.ClaimID = Int32.Parse(Console.ReadLine());
//            // Get claim type
//            Console.WriteLine("Enter the type of claim (1. Car, 2. Home, 3. Theft)");
//            string claimTypeString = Console.ReadLine();
//            bool active = true;
//            while (active)
//            {
//                switch (claimTypeString.ToLower())
//                {
//                    case "1":
//                        {
//                            newClaim.Type = Claim.ClaimType.Car;
//                            active = false;
//                            break;
//                        }
//                    case "2":
//                        {
//                            newClaim.Type = Claim.ClaimType.Home;
//                            active = false;
//                            break;
//                        }
//                    case "3":
//                        {
//                            newClaim.Type = Claim.ClaimType.Theft;
//                            active = false;
//                            break;
//                        }
//                    default:
//                        {
//                            Console.WriteLine("Enter the valid type of claim (1.Car, 2.Home, 3.Theft)");
//                            break;
//                        }
//                }
//            }
//            // Get claim Description
//            Console.WriteLine("Enter claim description:");
//            newClaim.Description = Console.ReadLine();
//            //get ammount - write helper
//            newClaim.ClaimAmount = InputDoubleHelper("Enter the claim amount:", "Enter claim ammount in the format #.## without $ sign.");
//            // get Date of Incident
//            newClaim.DateOfIncident = InputDateHelper("Enter the incident date (MM/DD/YYYY):", "Enter incident date in the format MM/DD/YYYY.");
//            // get Date of Claim
//            newClaim.DateOfClaim = InputDateHelper("Enter the claim date (MM/DD/YYYY):", "Enter claim date in the format MM/DD/YYYY.");
//            // get IsValid - this will be confirmed or overwritten in the add method based on business rules
//            newClaim.IsValid = true;
//            // Add to the queue
//            queueOfClaims.AddToQueue(newClaim);
//        }

//        public void DisplayHeadingsHelper()
//        {
//            string headings = string.Format("{0,-10}", "ClaimID");
//            headings += string.Format("{0,-10}", "Type");
//            headings += string.Format("{0,-25}", "Description");
//            headings += string.Format("{0,-10}", "Amount");
//            headings += string.Format("{0,-20}", "Date of Incident");
//            headings += string.Format("{0,-15}", "Date of Claim");
//            headings += string.Format("{0,-15}", "Is Claim Valid");
//            Console.WriteLine(headings);
//        }

//        public void DisplaySingleClaimHelper(Claim claimToView)
//        {
//            string claimDisplay = string.Format("{0,-10}", claimToView.ClaimID.ToString());
//            claimDisplay += string.Format("{0,-10}", claimToView.Type.ToString());
//            claimDisplay += string.Format("{0,-25}", claimToView.Description);
//            claimDisplay += string.Format("{0,-10}", "$" + claimToView.ClaimAmount.ToString());
//            claimDisplay += string.Format("{0,-20}", claimToView.DateOfIncident.ToShortDateString());
//            claimDisplay += string.Format("{0,-15}", claimToView.DateOfClaim.ToShortDateString());
//            claimDisplay += string.Format("{0,-15}", claimToView.IsValid.ToString());
//            Console.WriteLine(claimDisplay);
//        }
//