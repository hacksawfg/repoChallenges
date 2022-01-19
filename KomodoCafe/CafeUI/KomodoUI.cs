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

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        // delete item method
                        break;
                    case "3":
                        // display all method
                        DisplayAllMenuItems();
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();

            MenuItem item = new MenuItem();

            Console.Write("Enter the meal name: " );
            item.MealName = Console.ReadLine();

            Console.Write("\nEnter the meal description: ");
            item.MealDescription = Console.ReadLine();

            Console.WriteLine("\nEnter the list of ingredients, separated by commas (i.e. hamburger, bread, etc.)");
            string ingredients = Console.ReadLine().Replace(" ", "");
            string[] recipe = ingredients.Split(',');
            foreach (string ingredient in recipe)
            {
                item.MealIngredients.Add(ingredient);
            }

            Console.Write($"\nSet the price for {item.MealName}: $");
            item.MealPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Is the meal vegetarian (Y/N)?: ");
            string vegetarian = Console.ReadLine().ToLower();

            switch (vegetarian)
            {
                case "y":
                    item.IsVegetarian = true;
                    break;
                case "n":
                    item.IsVegetarian = false;
                    break;
            }   
        }

        private void DisplayMenuItem(MenuItem item)
        {
            Console.WriteLine(
                            $"Menu Number #{item.MealNumber}. {item.MealName}\n" +
                            $"{item.MealDescription}\n" +
                            $"Ingredients: {item.MealIngredients}\n" +
                            $"Price: ${item.MealPrice}\n" +
                            $"Vegetarian: {item.IsVegetarian}" 
                            );
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List <MenuItem> workingMenu = _menu.GetCafeMenu(); 
            
            foreach (MenuItem item in workingMenu)
            {
                DisplayMenuItem(item);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}