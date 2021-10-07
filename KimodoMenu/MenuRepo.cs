using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuRepo
    {
        public readonly List<Menu> menuDirectory = new List<Menu>();

        //Create
        public bool AddContentToDirectory(Menu item)
        {
            int beginCount = menuDirectory.Count;
            menuDirectory.Add(item);

            bool wasAdded = (menuDirectory.Count > beginCount);
            return wasAdded;
        }

        //Read
        public List<Menu> GetMenuItems()
        {
            return menuDirectory;
        }

        //Get by meal number
        public Menu GetMenuNumber(int KomodoMenuNumber)
        {
            foreach (Menu item in menuDirectory)
            {
                if (item.MealNumber == KomodoMenuNumber)
                {
                    return item;
                }
            }
            return null;
        }

        //Update
        public bool UpdateMenu(Menu existingItem, Menu newItem )
        {
            if (existingItem != newItem)
            {
                existingItem.MealNumber = newItem.MealNumber;
                existingItem.MealName = newItem.MealName;
                existingItem.MealDescription = newItem.MealDescription;
                existingItem.Ingredients = newItem.Ingredients;
                existingItem.MenuPrice = newItem.MenuPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteItem(Menu existingItem)
        {
            bool delete = menuDirectory.Remove(existingItem);
            return delete;
        }
    }
}
