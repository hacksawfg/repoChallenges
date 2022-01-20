using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;


namespace CafeUI
{
    public class KomodoUI
    {
        private readonly MenuRepository _menu = new MenuRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Cafe Menu Creation Console");
                Console.WriteLine("Enter the number of your menu selection");
                Console.WriteLine("1. Create New Menu Item");
                Console.WriteLine("2. Delete an Existing Menu Item");
                Console.WriteLine("3. Display All Items on the Menu");
                Console.WriteLine("4. Exit");

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        // delete item method
                        RemoveMenuItem();
                        break;
                    case "3":
                        // display all method
                        DisplayAllMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection: ");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            // list all content
            List<MenuItem> listOfItems = _menu.GetCafeMenu();
            Console.WriteLine("List of menu items");

            int counter = 1;

            foreach (MenuItem item in listOfItems)
            {
                Console.WriteLine($"{counter}. Menu Item: {item.MealName}");
                counter ++;
            }

            Console.Write("Enter the number of the item to remove: ");
            int removeThis = int.Parse(Console.ReadLine());

            int targetIndex = removeThis - 1;

            if (targetIndex >= 0 && targetIndex < listOfItems.Count)
            {
                MenuItem targetItem = listOfItems[targetIndex];
                if (_menu.DeleteMenuItem(targetItem))
                {
                    Console.WriteLine($"{targetItem.MealName} was removed from the menu");
                }
                else
                {
                    Console.WriteLine("An error occured");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }

        private void AddMenuItem()
        {
            Console.Clear();

            MenuItem item = new MenuItem();

            Console.Write("Enter a unique numerical menu item: ");
            string menuID = Console.ReadLine();
            int checkID;
            bool menuIdIsNum = int.TryParse(menuID, out checkID);

            if (menuIdIsNum)
            {

                // Cycle through items in list to check if ID is unique
                // If unique, assign
                // If not unique, add ("number taken" message and ask again)
                // Need to fix this to make it work in version 2
                //     bool idExists = false;
                //     while (idExists != true)
                //     {
                //         foreach (MenuItem i in _menu.GetCafeMenu())
                //              {
                //                  if (checkID == i.MealNumber)
                //                  {
                //                  Console.Write($"\n{checkID} is taken, please select another number: ");
                //                  idExists = true;
                //                  
                //         }
                //     }

                item.MealNumber = checkID;

            }
            else
            {
                Console.Write("Please enter an integer value: ");
                menuID = Console.ReadLine();
            }

            Console.Write("Enter the meal name: ");
            item.MealName = Console.ReadLine();

            Console.Write("\nEnter the meal description: ");
            item.MealDescription = Console.ReadLine();

            Console.WriteLine("\nEnter the list of ingredients, separated by commas (i.e. hamburger, bread, etc.)");
            string ingredients = Console.ReadLine();
            string[] recipe = ingredients.Split(',');
            foreach (string ingredient in recipe)
            {
                item.MealIngredients.Add(ingredient);
            }

            Console.Write($"\nSet the price for {item.MealName}: $");
            string itemPriceInput = Console.ReadLine();
            decimal validPrice;
            bool checkPrice = decimal.TryParse(itemPriceInput, out validPrice);
            if (checkPrice)
            {
                item.MealPrice = validPrice;
            }
            else
            {
                Console.Write("Please enter a valid price: $");
                itemPriceInput = Console.ReadLine();
            }

            Console.Write("Is the meal vegetarian (Y/N)?: ");
            string vegetarian = Console.ReadLine().ToLower();

            switch (vegetarian)
            {
                case "y":
                    item.IsVegetarian = true;
                    break;
                default:
                    item.IsVegetarian = false;
                    break;
            }

            _menu.AddMenuItem(item);
        }

        private void DisplayMenuItem(MenuItem item)
        {

            string ingredientDisplay = string.Join(", ", item.MealIngredients);
            Console.WriteLine(
                            $"Menu Number #{item.MealNumber}. {item.MealName}\n" +
                            $"{item.MealDescription}\n" +
                            $"Ingredients: {ingredientDisplay}\n" +
                            $"Price: ${item.MealPrice}\n" +
                            $"Vegetarian: {item.IsVegetarian}\n"
                            );
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> workingMenu = _menu.GetCafeMenu();

            foreach (MenuItem item in workingMenu)
            {
                DisplayMenuItem(item);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            string[] cheeseburgerIngred = { "ground beef", "cheddar cheese", "brioche bun", "lettuce", "tomato", "onion" };
            List<string> cbIngred = new List<string>(cheeseburgerIngred);
            MenuItem cheeseburger = new MenuItem(1, "Cheeseburger", "The All-American classic", cbIngred, 4.99m, false);

            string[] denverEggsIngred = { "eggs", "ham", "onion", "green pepper" };
            List<string> denverIngred = new List<string>(denverEggsIngred);
            MenuItem denverOmelette = new MenuItem(2, "Denver Omelette", "Delicious Breakfast", denverIngred, 3.99m, false);

            string[] houseSaladIngred = { "iceberg lettuce", "tomato", "cucumber", "cheddar cheese", "croutons" };
            List<string> houseIngred = new List<string>(houseSaladIngred);
            MenuItem houseSalad = new MenuItem(3, "House Salad", "Healthy Alternative", houseIngred, 2.99m, true);

            _menu.AddMenuItem(cheeseburger);
            _menu.AddMenuItem(denverOmelette);
            _menu.AddMenuItem(houseSalad);

        }
    }
}