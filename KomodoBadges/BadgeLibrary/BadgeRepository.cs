using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeLibrary
{

    public class BadgeRepository
    {
        private readonly Dictionary<int, List<Doors>> _badges = new Dictionary<int, List<Doors>>();


        // Adds new Badge to system, returns true if successful
        public bool AddNewBadge(Badges newBadge)
        {
            int startingCount = _badges.Count;
            _badges.Add(newBadge.BadgeID, newBadge.AccessPermission);

            return _badges.Count > startingCount;
        }

        
        // return complete dictionary containing key value pairs for entire repository
        public Dictionary<int, List<Doors>> ReturnAllBadges()
        {
            return _badges;
        }


        // Adds the door, utilized in adding new badge and update badge sections
        public bool AddTheDoor(Badges itemBadge, int doorEnumNumber)
        {
            int startingCount = itemBadge.AccessPermission.Count();
            itemBadge.AccessPermission.Add((Doors)doorEnumNumber);

            return startingCount < itemBadge.AccessPermission.Count();
        }

        //used in update method
        public bool RemoveSingleDoor(Badges itemBadge, int doorEnumNumber)
        {
            int startingCount = itemBadge.AccessPermission.Count();
            itemBadge.AccessPermission.Remove((Doors)doorEnumNumber);

            return startingCount > itemBadge.AccessPermission.Count();
        }

        // used in update method, removes all doors and returns if completed
        public bool RemoveAllDoors(Badges itemBadge)
        {
            itemBadge.AccessPermission.Clear();
            return itemBadge.AccessPermission.Count() == 0;
        }


        // used in badge update section to retrieve a single badge for modification
        public Badges RetrieveSingleBadge(int badgeID)
        {
            Badges returnBadge = new Badges();
            KeyValuePair<int, List<Doors>> showAccess = SelectOneBadge(badgeID);
            if (showAccess.Key > 0)
            {
                returnBadge.BadgeID = badgeID;
                returnBadge.AccessPermission = showAccess.Value;
                return returnBadge;
            }
            else
            {
                List<Doors> nothingHere = new List<Doors>();
                returnBadge.BadgeID = badgeID;
                returnBadge.AccessPermission = nothingHere;
                return returnBadge;
            }
            // to show doors a badge can access
        }

        // not used, scheduled for removal from code

        public KeyValuePair<int, List<Doors>> SelectOneBadge(int badgeID)
        {
            foreach (KeyValuePair<int, List<Doors>> target in _badges)
            {
                if (badgeID == target.Key)
                {
                    return target;
                }
            }
            // return null;
            List<Doors> nothingHere = new List<Doors>();
            KeyValuePair<int, List<Doors>> nothingFound = new KeyValuePair<int, List<Doors>>(badgeID, nothingHere);
            return nothingFound;
        }
    }
}