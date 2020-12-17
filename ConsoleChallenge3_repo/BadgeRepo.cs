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
            AddBadge(12345, new List<string>() { "A1", "D3", "F4", "X4" });
            AddBadge(22233, new List<string>() { "B1" });
            AddBadge(3113, new List<string>() { "A1", "B1", "X1", "T6" });
        }
    }
}

