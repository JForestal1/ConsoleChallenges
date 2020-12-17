using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge5_repo
{
    public class CustomerRepo
    {
        SortedList<string, Customer> _listOfCustomers = new SortedList<string, Customer>();

        public bool AddCustomer(string first, string last, Customer.CustomerType type)
        {
            Customer customerToAdd = new Customer();
            customerToAdd.FirstName = first;
            customerToAdd.LastName = last;
            customerToAdd.Type = type;
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
        public SortedList<string, Customer> GetAllCustomers()
        {
            return _listOfCustomers;
        }

        public bool DeleteCustomer(string first, string last)
        {
            string key = last + first;
            string foundkey = "";
            bool success = false;
            // cannot change _listofCusts from within this foreach loop apparently
            foreach (KeyValuePair<string, Customer> each in _listOfCustomers)
            {
                if (each.Key == key)
                {
                    foundkey = key;
                    success = true;
                }
            }
            if (success)
            {
            _listOfCustomers.Remove(foundkey);
            }

            return success;
        }

        public bool UpdateCustomer(string first, string last, Customer updatedCustomer)
        {
            string key = last + first;
            bool found = false;
//            Customer updatedCustomer = new Customer(newfirst, newlast, newtype);
            foreach (KeyValuePair<string, Customer> each in _listOfCustomers)
            {
                if (each.Key == key)
                {
                    found = true;
                }
            }
            if (found)
            {
                _listOfCustomers.Remove(last+first);
                _listOfCustomers.Add(updatedCustomer.LastName+ updatedCustomer.FirstName, updatedCustomer);
            }
            return found;
        }
    }
}
