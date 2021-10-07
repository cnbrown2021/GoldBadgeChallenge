using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    //Plain Old C# Object -- POCO
    public class Menu
    {
        public Menu() { }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public decimal MenuPrice { get; set; }

        public Menu (int mealNumber, string mealName, string mealDescription, string ingredients, decimal menuPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            MenuPrice = menuPrice;
        }

    }
}
