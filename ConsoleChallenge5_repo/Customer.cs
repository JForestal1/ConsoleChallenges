using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge5_repo
{
    public class Customer
    {
        public enum CustomerType
        {
            Potential = 1,
            Current,
            Past
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public string EmailGreeting { get; set; }

        public Customer() { }

        public Customer(string firstname, string lastname, CustomerType type, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            EmailGreeting = email;
        }
    }
}
