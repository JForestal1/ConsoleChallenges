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
            bool badgeFound = false;
            foreach (KeyValuePair<int, List<string>> badge in Badges)
            {
                if (badgeIDToGet == badge.Key)
                {
                    returnBadge.BadgeID = badge.Key;
                    returnBadge.Doors = badge.Value;
                    badgeFound = true;
                }
            }
            if (badgeFound)
            {
                return returnBadge;
            }
            else
            {
                return null;
            }
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            if (Badges.Count > 0)
            {
                return Badges;
            }
            else
                return null;
        }
        public bool DeleteAllDoors(int badgeToShutoff)
        {
            bool success = false;
            // get a single door, test to see if one was returned
            if (GetSingleBadge(badgeToShutoff) != null)
            {
                // if returned, set doors to null
                GetSingleBadge(badgeToShutoff).Doors.Clear();
                success = true;
            }
            return success;
        }

        public bool UpdateDoors(int badgeToUpdate, List<string> newDoors)
        {
            bool success = false;
            // get a single door, test to see if one was returned
            if (GetSingleBadge(badgeToUpdate) != null)
            {
                // if returned, set doors to new door list
                GetSingleBadge(badgeToUpdate).Doors = newDoors;
                success = true;
            }
            return success;
        }
        public void SeedUtility()
        {
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testDoors.Add("X4");
            AddBadge(1, testDoors);
            List<string> testDoors2 = new List<string>();
            testDoors2.Add("B1");
            AddBadge(2, testDoors2);
            List<string> testDoors3 = new List<string>();
            testDoors3.Add("B1");
            testDoors3.Add("X1");
            testDoors3.Add("T6");
            AddBadge(3, testDoors3);
        }
    }
}

