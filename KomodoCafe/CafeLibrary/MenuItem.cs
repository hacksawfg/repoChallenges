using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    // POCO
    public class MenuItem
    {
        public MenuItem() {}

        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice, bool isVegetarian)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
            IsVegetarian = isVegetarian;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public decimal MealPrice { get; set; }
        public bool IsVegetarian { get; set; } // Setting for potential to filter
    }
}