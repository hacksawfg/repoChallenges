using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeConsole
{
    public class BadgeUI
    {
        private readonly BadgeLibrary _accessList = new BadgeLibrary();

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
                        break;
                    case "3":
                        // List all badges method goes here
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
            Console.Clear();
            Console.Write("What is the number on the badge");
            int idValidated;
            bool idInput = int.TryParse(Console.ReadLine(), out idValidated);
            bool allDone = false;
            // logic here to see if ID already exists

            if (idInput)
            {
                // following logic if the badge number is not already in list
                if (_accessList.SelectOneBadge(idValidated) == null)
                {
                    while (allDone == false)
                    {
                        // Get the door number
                        GetTheDoor(newBadge, idValidated);

                        // See if we add another badge
                        Console.Write("Add another door (Y/N):  ");
                        string keepGoing = Console.ReadLine().ToLower();
                        switch (keepGoing)
                        {
                            case "y":
                                GetTheDoor(newBadge, idValidated);
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

        private static void GetTheDoor(Badges newBadge, int idValidated)
        {
            Console.WriteLine($"Enter a door badge {idValidated} needs to access: ");
            string newAccessDoor = Console.ReadLine();
            // logic to see if door is in enum
            if (Enum.TryParse<Doors>(newAccessDoor, out Doors result))
            {
                newBadge.AccessPermission.Add(result);
            }
            else
            {
                Console.Write("Invalid Selection, please try again: ");
                newAccessDoor = Console.ReadLine();
            }
        }

        public void EditBadge()
        {

        }

        public void ListBadges()
        {

        }
    }
}