using ConsoleChallenge4_repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge4
{
    class ProgramUI
    {
        // Instantiate the event Repo
        public OutingRepo AllEvents = new OutingRepo();

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
                "1. Add an event\n" +
                "2. List all events\n" +
                "3. See total cost for all events\n" +
                "4. See total cost for all events by event type\n" +
                "X - Exit");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Clear();
                            AddEvent();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            DisplayAllEvents();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            DisplayTotalOuting();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            DisplayOutingCostsByEventType();
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
        public void AddEvent()
        {
            Outing outingToAdd = new Outing();
            outingToAdd.Type = InputEventTypeHelper("\n Enter the type of event");
            if (outingToAdd.Type != Outing.EventType.Invalid)
            {
                outingToAdd.Attendees = InputIntHelper("\nEnter the number of attendees", "\nEnter the number of attendees as a whole number");
                outingToAdd.CostPP = InputDoubleHelper("\nEnter the cost per person (XXX.XX)", "\nEnter the cost per person (XXX.XX) without a $");
                outingToAdd.CostTotal = InputDoubleHelper("\nEnter the total event cost (XXX.XX)", "\nEnter the total event cost (XXX.XX) without a $");
                outingToAdd.EventDate = InputDateHelper("\nEnter the event date (MM/DD/YYYY):", "\nEnter event date in the format MM/DD/YYYY.");
                AllEvents.AddOuting(outingToAdd);
            }
        }
        public void DisplayAllEvents()
        {
            // Display headings
            DisplayHeadingsHelper();
            if (AllEvents.GetAllOutings().Count != 0)
                foreach (Outing each in AllEvents.GetAllOutings())
                {
                    DisplaySingleOutingHelper(each);
                }
        }
        public void DisplayOutingCostsByEventType()
        {
            double costs = AllEvents.GetCostsTotal(InputEventTypeHelper("Enter the Event type you wish to see totaled"));
            Console.WriteLine("\nTotal costs for all events of this type were: $"+costs);
        }
        public void DisplayTotalOuting()
        {
            double costs = AllEvents.GetCostsTotal();
            Console.WriteLine("\nTotal costs for all events were: $" + costs);
        }
        public void DisplayHeadingsHelper()
        {
            string headings = string.Format("{0,-20}", "Event Type");
            headings += string.Format("{0,-15}", "Attendees");
            headings += string.Format("{0,-15}", "Date");
            headings += string.Format("{0,-20}", "Cost Per Person");
            headings += string.Format("{0,-20}", "Total Cost");
            Console.WriteLine(headings);
        }
        public void DisplaySingleOutingHelper(Outing outtingToDisplay)
        {
            string claimDisplay = string.Format("{0,-20}", outtingToDisplay.Type);
            claimDisplay += string.Format("{0,-15}", outtingToDisplay.Attendees);
            claimDisplay += string.Format("{0,-15}", outtingToDisplay.EventDate.ToShortDateString());
            claimDisplay += string.Format("{0,-20}", "$" + outtingToDisplay.CostPP.ToString());
            claimDisplay += string.Format("{0,-20}", "$" + outtingToDisplay.CostTotal.ToString());
            Console.WriteLine(claimDisplay);
        }
        private Outing.EventType InputEventTypeHelper(string prompt)
        {
            Outing.EventType typeToReturn;
            Console.WriteLine("\n" + prompt +
                "\n\t1. Golf" +
                "\n\t2. Bowling" +
                "\n\t3. Amusement Park" +
                "\n\t4. Concert\n");
            var eventTypeString = Console.ReadLine();
            switch (eventTypeString.ToLower())
            {
                case "1":
                    {
                        typeToReturn = Outing.EventType.Golf;
                        break;
                    }
                case "2":
                    {
                        typeToReturn = Outing.EventType.Bowling;
                        break;
                    }
                case "3":
                    {
                        typeToReturn = Outing.EventType.Amusement_Park;
                        break;
                    }
                case "4":
                    {
                        typeToReturn = Outing.EventType.Concert;
                        break;
                    }
                default:
                    {
                        typeToReturn = Outing.EventType.Invalid;
                        Console.WriteLine("That event type is not valid");
                        break;
                    }
            }
            return typeToReturn;
        }
        private int InputIntHelper(string prompt, string errorPrompt)
        {
            bool goodInt = false;
            int inputInt = 0;
            Console.WriteLine(prompt);
            while (!goodInt)
            {
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
    }
}