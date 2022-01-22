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


        public bool AddNewBadge(Badges newBadge)
        {
            int startingCount = _badges.Count;
            _badges.Add(newBadge.BadgeID, newBadge.AccessPermission);

            return _badges.Count > startingCount;
        }

        public Dictionary<int, List<Doors>> ReturnAllBadges()
        {
            return _badges;
        }


        public bool AddTheDoor(Badges itemBadge, int doorEnumNumber)
        {
            int startingCount = itemBadge.AccessPermission.Count();
            itemBadge.AccessPermission.Add((Doors)doorEnumNumber);

            return startingCount < itemBadge.AccessPermission.Count();
        }

        public bool RemoveSingleDoor(Badges itemBadge, int doorEnumNumber)
        {
            int startingCount = itemBadge.AccessPermission.Count();
            itemBadge.AccessPermission.Remove((Doors)doorEnumNumber);

            return startingCount > itemBadge.AccessPermission.Count();
        }

        public bool RemoveAllDoors(Badges itemBadge)
        {
            itemBadge.AccessPermission.Clear();
            return itemBadge.AccessPermission.Count() == 0;
        }

        // public KeyValuePair<int, List<Doors>> RetreiveSingleBadgeAccessList(int badgeID)
        // {
        //     KeyValuePair<int, List<Doors>> showAccess = SelectOneBadge(badgeID);
        //     if (showAccess.Key > 0)
        //     {
        //         return showAccess;
        //     }
        //     else
        //     {
        //         List<Doors> nothingHere = new List<Doors>();
        //         KeyValuePair<int, List<Doors>> nothingFound = new KeyValuePair<int, List<Doors>>(badgeID, nothingHere);
        //         return nothingFound;
        //     }
        //     // to show doors a badge can access
        // }

        public Badges RetreiveSingleBadge(int badgeID)
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

        public List<Doors> RetrieveDoorListFromBadgeId(int badgeId)
        {
            List<Doors> doorList = SelectOneBadge(badgeId).Value;
            return doorList;
        }

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

        // public KeyValuePair<int, List<Doors>> GetBadgeToUpdate(int badgeID)
        // {
        //     foreach (KeyValuePair<int, List<Doors>> target in _badges)
        //     {
        //         if (badgeID == target.Key)
        //         {
        //             return target;
        //         }
        //     }
        // }

        // public List<Doors> EditBadge(int badgeID)
        // {
        //     List<Doors> listForUpdating = SelectOneBadge(badgeID);
        //     return listForUpdating;

        //     // select and change a badge access from the dictionary

        // }

    }
}