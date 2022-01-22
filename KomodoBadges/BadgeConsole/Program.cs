using System;

namespace BadgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeUI ui = new BadgeUI();
            ui.Run();
        }
    }
}

/* To do list
[X] Setup method to add new badge
[] Setup method to update doors on badge
[] Setup method to delete doors from existing badge
[X] Show a list with badge numbers and door access
[X] Class with properties BadgeID, DoorName list, and Name for the badge

*/