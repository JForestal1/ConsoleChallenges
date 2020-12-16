using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge4_repo
{
    public class OutingRepo
    {
        List<Outing> _listOfOutings = new List<Outing>();

        public void AddOuting(Outing newOuting)
        {
            _listOfOutings.Add(newOuting);
        }

        public List<Outing> GetAllOutings()
        {
            return _listOfOutings;
        }

        // override for costs to allow filtering
        public double GetCostsTotal(Outing.EventType filterType)
        {
            double result = 0;
            foreach (Outing each in _listOfOutings)
            {
                if (each.Type == filterType)
                {
                    result += each.CostTotal;
                }
            }
            return result;
        }
        
        public double GetCostsTotal()
        {
            double result = 0;
            foreach (Outing each in _listOfOutings)
            {
                result += each.CostTotal;
            }
            return result;
        }
    }
}
