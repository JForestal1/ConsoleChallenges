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
            Past,
            Invalid
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public string EmailGreeting { get; set; }

        public Customer() { }

        public Customer(string firstname, string lastname, CustomerType type)
        {
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            switch (type)
            {
                case Customer.CustomerType.Potential:
                    {
                        EmailGreeting = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    }
                case Customer.CustomerType.Current:
                    {
                        EmailGreeting = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    }
                case Customer.CustomerType.Past:
                    {
                        EmailGreeting = "It's been a long time since we've heard from you, we want you back";
                        break;
                    }
            }
        }
    }
}
