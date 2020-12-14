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
                            //View All Claims
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            //Process next claim 
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            //Enter a new claim
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
    }
}
