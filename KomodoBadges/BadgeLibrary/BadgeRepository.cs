using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeLibrary
{

    public class BadgeRepository
    {
        private readonly Dictionary<int, List<Badges>> _badges = new Dictionary<int, List<Badges>>();
        

        public bool AddNewBadge(Badges newBadge)
        {
            int startingCount = _badges.Count;
            _badges.Add();

            return _badges.Count > startingCount;
        }

        public List<Badges> ListAllBadges()
        {
            return _badges;
        }

        public List<Badges> RetreiveSingleBadgeAccess(int badgeID)
        {
            Badges showAccess = SelectOneBadge(badgeID);
            return showAccess.AccessPermission;
        }

        public Badges SelectOneBadge(int badgeID)
        {
            foreach (Badges target in _badges)
            {
                if (badgeID = target.BadgeID)
                {
                    return target;
                }
            }
            return null;
        }

        public void EditBadge(int badgeID)
        {
            Badges badgeToEdit = SelectOneBadge(badgeID);

        }

    }
}