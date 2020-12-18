using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge7_repo
{
    public class PartyRepo
    {
        List<Party> _listOfParties = new List<Party>();

        public void AddParty(Party newParty)
        {
            _listOfParties.Add(newParty);
        }

        public List<Party> GetAllParties()
        {
            return _listOfParties;
        }

    }
}
