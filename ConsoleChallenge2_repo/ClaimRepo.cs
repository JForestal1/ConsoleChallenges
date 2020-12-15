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
        Queue<Claim> claimQueue = new Queue<Claim>();

        // Add a claim to the queue with a complete claim
        public bool AddToQueue(Claim claimToAdd)
        {
            if (ClaimIdIsUnique(claimToAdd.ClaimID))
            {
                double daysBetweenIncidentAndClaim = (claimToAdd.DateOfClaim - claimToAdd.DateOfIncident).TotalDays;
                if (daysBetweenIncidentAndClaim >= 0 && daysBetweenIncidentAndClaim <= 30)
                    claimToAdd.IsValid = true;
                else
                    claimToAdd.IsValid = false;
                claimQueue.Enqueue(claimToAdd);
                return true;
            }
            return false;

        }

        public bool ClaimIdIsUnique(int ID)
        {
            bool idIsUnique = true;
            foreach (Claim claimToTest in claimQueue)
            {
                if (ID == claimToTest.ClaimID)
                {
                    idIsUnique = false;
                }
            }
            return idIsUnique;
        }
        public Queue<Claim> GetEntireQueue()
        {
            return claimQueue;
        }

        public bool ProcessClaim()
        {
            var itemsInQueue = claimQueue.Count;
            claimQueue.Dequeue();
            if (claimQueue.Count == itemsInQueue)
                return false;
            return true;
        }

        public Claim GetCurrentClaim()
        {
            if (claimQueue.Count > 0)
            {
                return claimQueue.Peek();
            }
            else
            {
                return null;
            }
        }

        public void SeedQueue()
        {
            AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));
            AddToQueue(new Claim(2, Claim.ClaimType.Home, "Nasty house fire", 80000, new DateTime(2020, 05, 04), new DateTime(2020, 06, 03), true));
            AddToQueue(new Claim(3, Claim.ClaimType.Theft, "Stolen source code", 20, new DateTime(2020, 11, 14), new DateTime(2020, 12, 13), true));
            AddToQueue(new Claim(4, Claim.ClaimType.Theft, "Stolen cheese - late", 20, new DateTime(2020, 08, 03), new DateTime(2020, 10, 21), true));
        }
    }
}