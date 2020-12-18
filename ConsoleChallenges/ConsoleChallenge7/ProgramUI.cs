using ConsoleChallenge7_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge7
{
    class ProgramUI
    {
        public PartyRepo partyList = new PartyRepo();

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
                "1. Add a Party\n" +
                "2. Show Party Totals\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddPartyToList();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            DisplayAllParties();
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

        public void AddPartyToList()
        {
            Console.WriteLine("\nEnter the Title/Name of the party:");
            string partyName = Console.ReadLine();
            DateTime partyDate = InputDateHelper("\nEnter the date of the event:", "Enter date in a MM/DD/YYYY format");
            double bOverhead = InputDoubleHelper("\nEnter the amount of Burger Booth overhead (condiments, napkins, etc.)", "Enter using the XXX.XX format without a $");
            double tOverhead = InputDoubleHelper("\nEnter the amount of Treat Booth overhead (condiments, napkins, etc.)", "Enter using the XXX.XX format without a $");
            double bUnitCost = InputDoubleHelper("\nEnter the burger unit cost:", "Enter using the XXX.XX format without a $");
            double vUnitCost = InputDoubleHelper("\nEnter the veggie burger unit cost:", "Enter using the XXX.XX format without a $");
            double hUnitCost = InputDoubleHelper("\nEnter the hot dog unit cost:", "Enter using the XXX.XX format without a $");
            double pUnitCost = InputDoubleHelper("\nEnter the popcorn unit cost:", "Enter using the XXX.XX format without a $");
            double iUnitCost = InputDoubleHelper("\nEnter the ice cream unit cost:", "Enter using the XXX.XX format without a $");
            int bVol = InputIntHelper("\nEnter the number of burgers sold:", "Enter whole numbers only");
            int vVol = InputIntHelper("\nEnter the number of veggie burgers sold:", "Enter whole numbers only");
            int hVol = InputIntHelper("\nEnter the number of hot dogs sold:", "Enter whole numbers only");
            int pVol = InputIntHelper("\nEnter the number of popcorns sold:", "Enter whole numbers only");
            int iVol = InputIntHelper("\nEnter the number of icecreams sold:", "Enter whole numbers only");
            partyList.AddParty(new Party(partyName, partyDate, bOverhead, tOverhead, bUnitCost, bVol, vUnitCost, vVol, hUnitCost, hVol, pUnitCost, pVol, iUnitCost, iVol));
        }

        public void DisplayAllParties()
        {
            List<Party> _displayPartyList = new List<Party>();
            _displayPartyList = partyList.GetAllParties();
            if (_displayPartyList.Count != 0)
            {
                DisplayHeadingsHelper();
                foreach (Party each in _displayPartyList)
                {
                    DisplayPartyHelper(each);
                }
            }
            else
            {
                Console.WriteLine("No parties have been entered yet.");
            }
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
        public DateTime InputDateHelper(string prompt, string errorPrompt)
        {
            bool goodDate = false;
            DateTime inputDate = DateTime.Today;
            Console.WriteLine(prompt);
            while (!goodDate)
            {
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
        public void DisplayHeadingsHelper()
        {
            string headings = string.Format("{0,-20}", "Party Title");
            headings += string.Format("{0,-15}", "Date");
            headings += string.Format("{0,-15}", "Total Cost");
            headings += string.Format("{0,-20}", "Total Tickets");
            headings += string.Format("{0,-30}", "Total Burger Booth Tickets");
            headings += string.Format("{0,-30}", "Total Treat Booth Tickets");
            headings += string.Format("{0,-30}", "Total Burger Booth Costs");
            headings += string.Format("{0,-30}", "Total Treat Booth Costs");
            Console.WriteLine(headings);
        }
        public void DisplayPartyHelper(Party partyToDisplay)
        {
            string partyDisplay = string.Format("{0,-20}", partyToDisplay.PartyTitle);
            partyDisplay += string.Format("{0,-15}", partyToDisplay.PartyDate.ToShortDateString());
            partyDisplay += string.Format("{0,-15}", partyToDisplay.PartyCost);
            partyDisplay += string.Format("{0,-20}", partyToDisplay.TotalTickets);
            partyDisplay += string.Format("{0,-30}", partyToDisplay.BurgerTickets);
            partyDisplay += string.Format("{0,-30}", partyToDisplay.TreatTickets);
            partyDisplay += string.Format("{0,-30}", partyToDisplay.BBoothTotalCost);
            partyDisplay += string.Format("{0,-30}", partyToDisplay.TBoothTotalCost);
            Console.WriteLine(partyDisplay);
        }
    }
}