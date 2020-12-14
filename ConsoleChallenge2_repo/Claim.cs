using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge2_Repo
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft,
        }

        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public String Description { get; set; }
        public Double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int ID, ClaimType type, string description, double amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = ID;
            Type = type;
            Description = description;
            ClaimAmount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}