using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge5_repo
{
    class CustomerRepo
    {
        SortedList<string, Customer> _listOfCustomers = new SortedList<string, Customer>();

        public bool AddCustomer(string first, string last, Customer.CustomerType type)
        {
            Customer customerToAdd = new Customer();
            customerToAdd.FirstName = first;
            customerToAdd.LastName = last;
            customerToAdd.Type = type;
            switch (type)
            {
                case Customer.CustomerType.Potential:
                    {
                        customerToAdd.EmailGreeting = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    }
                case Customer.CustomerType.Current:
                    {
                        customerToAdd.EmailGreeting = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    }
                case Customer.CustomerType.Past:
                    {
                        customerToAdd.EmailGreeting = "It's been a long time since we've heard from you, we want you back";
                        break;
                    }
            }
            int listCountBefore = _listOfCustomers.Count;
            _listOfCustomers.Add(last + first, customerToAdd);
            if (listCountBefore < _listOfCustomers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
