using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgeLibrary
{
        public enum Doors
        {
            // Non-restricted doors
            A1 = 1,
            A2,
            A3,
            B1,
            B2,
            // Restricted access doors
            B3,
            ServerRoom
        }
    public class Badges
    {
        
        public void Badge() {}

        public void Badge(int badgeID, List<Doors> accessPermission, string nameBadge)
        {
            BadgeID = badgeID;
            AccessPermission = accessPermission;
            NameBadge = nameBadge;
        }

        public int BadgeID { get; set; }
        public List<Doors> AccessPermission { get; set; }
        public string NameBadge { get; set; }

    }
}