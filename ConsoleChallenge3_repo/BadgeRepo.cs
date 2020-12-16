using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge3_repo
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> Badges = new Dictionary<int, List<string>>();

        public bool AddBadge(int newBadgeNumber, List<string> _doors)
        {
            if (BadgeNumberIsUnique(newBadgeNumber))
            {
                Badges.Add(newBadgeNumber, _doors);
                return true;
            }
            else
                return false;

        }

        public bool BadgeNumberIsUnique(int badgeToTest)
        {
            foreach (KeyValuePair<int, List<string>> badge in Badges)
            {
                if (badgeToTest == badge.Key)
                    return false;
            }
            return true;
        }

        public Badge GetSingleBadge(int badgeIDToGet)
        {
            Badge returnBadge = new Badge();
            foreach (KeyValuePair<int, List<string>> badge in Badges)
            {
                if (badgeIDToGet == badge.Key)
                {
                    returnBadge.BadgeID = badge.Key;
                    returnBadge.Doors = badge.Value;
                }
                return returnBadge;
            }
            return null;
        }
    }
}

