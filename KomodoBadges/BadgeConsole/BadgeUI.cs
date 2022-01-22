using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeConsole
{
    public class BadgeUI
    {
        private readonly BadgeRepository _accessList = new BadgeRepository();

        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Insurance Physical Security Interface");
                Console.WriteLine("MENU\n");
                Console.WriteLine("1. Add a badge");
                Console.WriteLine("2. Edit a Badge");
                Console.WriteLine("3. List all badges");
                Console.WriteLine("4. Exit");
                Console.Write("Please make a selection: ");
                string mainMenuSelection = Console.ReadLine();
                switch (mainMenuSelection)
                {
                    case "1":
                        // Add badge menu goes here
                        AddBadge();
                        break;
                    case "2":
                        // Edit badge menu goes here
                        EditBadge();
                        break;
                    case "3":
                        // List all badges method goes here
                        DisplayAllBadges();
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey();
                        break;
                    case "4":
                        //Terminate program
                        isRunning = false;
                        break;
                    default:
                        Console.Write("Please select a valid option from the menu: ");
                        mainMenuSelection = Console.ReadLine();
                        break;
                }

            }
        }
        public void AddBadge()
        {
            Badges newBadge = new Badges();
            // List<Doors> newDoors = new List<Doors>();
            Console.Clear();
            Console.Write("What is the number on the badge:  ");
            int idValidated;
            bool idInput = int.TryParse(Console.ReadLine(), out idValidated);
            bool allDone = false;
            // logic here to see if ID already exists
            if (idInput)
            {
                // following logic if the badge number is not already in list
                if (!_accessList.ReturnAllBadges().Keys.Contains(idValidated))
                {
                    newBadge.BadgeID = idValidated;
                    _accessList.AddNewBadge(newBadge);
                    while (allDone == false)
                    {
                        // Get the door number
                        Console.WriteLine($"Enter a door badge {idValidated} needs to access: ");
                        int doorEnumNumber = DoorSelectMenu();
                        bool doorAdded = _accessList.AddTheDoor(newBadge, doorEnumNumber);
                        // if doorAdded is true Console.Writeline success
                        // See if we add another badge
                        Console.Write($"Add another door for badge {idValidated}? (Y/N):  ");
                        string keepGoing = Console.ReadLine().ToLower();
                        switch (keepGoing)
                        {
                            case "y":
                                Console.Clear();
                                break;
                            case "n":
                                allDone = true;
                                break;
                        }
                    }
                }
                // what to do if ID number already exists
                else
                {
                    Console.WriteLine("Badge ID already exists, please use the edit badge menu.");
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey();
                }
            }

        }

        private static int DoorSelectMenu()
        {
            Console.WriteLine("1.  A1\n" +
                              "2.  A2\n" +
                              "3.  A3\n" +
                              "4.  B1\n" +
                              "5.  B2\n" +
                              "6.  B3\n" +
                              "7.  Server Room");
            int doorEnumNumber = int.Parse(Console.ReadLine());
            return doorEnumNumber;
        }

        public void EditBadge()
        {
            // Badges updateBadge = ';
            Console.Clear();
            DisplayAllBadges();
            Console.Write("Enter the number of the badge to update:  ");
            int updateBadgeID = int.Parse(Console.ReadLine());  // implement validation later
            Badges updateBadge = _accessList.RetrieveSingleBadge(updateBadgeID);
            List<Doors> updateDoorAccessList = updateBadge.AccessPermission;
            Console.WriteLine(" Would you like to (A)dd a door, (R)emove a door, or (D)elete all doors?: ");
            string selection = Console.ReadLine().ToLower();
            switch (selection)
            {
                case "a":
                    Console.WriteLine($"Please select a door to add to Badge {updateBadgeID}");
                    int doorEnumNumberA = DoorSelectMenu();
                    bool doorAdded = _accessList.AddTheDoor(updateBadge, doorEnumNumberA);
                    break;
                case "r":
                    Console.WriteLine($"Please select a door to remove from Badge {updateBadgeID}");
                    int doorEnumNumberR = DoorSelectMenu();
                    bool doorRemoved = _accessList.RemoveSingleDoor(updateBadge, doorEnumNumberR);
                    // remove a door in here
                    break;
                case "d":
                    // delete all doors here
                    Console.WriteLine($"Are you sure you want to remove all door access for Badge {updateBadgeID}");
                    string removeAllConfirm = Console.ReadLine().ToString().ToLower();
                    if (removeAllConfirm == "y")
                    {
                        bool doorAllGone = _accessList.RemoveAllDoors(updateBadge);
                        if (doorAllGone)
                        {
                            Console.WriteLine("All doors successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("Operation unsuccessful");
                        }
                        Console.Write("Hit any key to continue.");
                        Console.ReadKey();
                    }
                    else if (removeAllConfirm == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection: ");
                        removeAllConfirm = Console.ReadLine().ToString().ToLower();
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection: ");
                    selection = Console.ReadKey().ToString().ToLower();
                    break;
            }
        }
        
        public void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<Doors>> fullBadgeList = _accessList.ReturnAllBadges();
            foreach (KeyValuePair<int, List<Doors>> item in fullBadgeList)
            {
                string result = string.Join(", ", item.Value).ToString(); // converts list to string
                Console.Write($"Badge ID: {item.Key}".PadRight(20));
                Console.Write($"Accessable Doors:  {result}\n");
            }
        }
    }
}