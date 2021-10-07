using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private readonly MenuRepo _repository = new MenuRepo();
        public void Run()
        {
            SeeData();
            Program();
        }


        //Start application
        private void Program()
        {
            //Create selections
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                    "Welcome to Komodo Cafe\n" +
                    "\n" +
                    "Please enter a selection\n" +
                    "1. Menu List\n" +
                    "2. Add Item\n" +
                    "3. Update Menu\n" +
                    "4. Delete Item\n" +
                    "5. Exit\n"
                    );
                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        //Menu List 
                        MenuList();
                        break;

                    case "2":
                        //Add Item
                        AddItem();
                        break;

                    case "3":
                        //Update Menu
                        break;

                    case "4":
                        //Delete Item
                        DeleteMenuItem();
                        break;

                    case "5":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid selection\n" +
                            "\n" +
                            "Press any key to continue" );
                        Console.ReadKey();
                        break;

                }
            }
        }
        //Add Item
        public void AddItem()
        {
            Console.Clear();
            Menu item = new Menu();

            Console.WriteLine("Enter Meal Number");
            item.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Meal");
            item.MealName = Console.ReadLine();

            Console.WriteLine("Enter Description");
            item.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter Ingredients");
            item.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter Price");
            item.MenuPrice = decimal.Parse(Console.ReadLine());

            _repository.AddContentToDirectory(item);

         

        }

        //Menu List
        private void MenuList()
        {
            Console.Clear();
            List<Menu> listOfItems = _repository.GetMenuItems();
            
            foreach (Menu item in listOfItems)
            {
                MenuContent(item);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //Update Menu

        //Delete Item
        public void DeleteMenuItem()
        {
            Console.Clear();

            List<Menu> listOfItems = _repository.GetMenuItems();

            int index = 1;

            foreach(Menu item in listOfItems)
            {
                Console.WriteLine($"{index}.{item.MealName}");
                index++;
            }
            Console.WriteLine("Which item would you like to remove?" );
            int selectMealNumber = int.Parse(Console.ReadLine());
            int selectIndex = selectMealNumber - 1;

            if (selectIndex >=0 && selectIndex < listOfItems.Count)
            {
                Menu selectItem = listOfItems[selectIndex];

                if(_repository.DeleteItem(selectItem))
                {
                    Console.WriteLine($"{selectItem.MealName} was successfully deleted");
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        //Exit


        private void SeeData()
        {
            Menu burger = new Menu(1, "Burger", "Plain Burger", "Ground Beef", 1.50m);
            Menu fries = new Menu(2, "Fries", "French Fries", "Potatos", 1.00m);
            Menu nuggets = new Menu(3, "Chicken Nuggets", "Nuggets", "Chicken", 1.25m);
            Menu rings = new Menu(4, "Onion Rings", "Fried onions", "Onions", 1.00m);

            _repository.AddContentToDirectory(burger);
            _repository.AddContentToDirectory(fries);
            _repository.AddContentToDirectory(nuggets);
            _repository.AddContentToDirectory(rings);
        }

        public void MenuContent(Menu item)
        {
            Console.WriteLine
                (
                    $"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Description: {item.MealDescription}\n" +
                    $"Meal Ingredients: {item.Ingredients}\n" +
                    $"Meal Price: {item.MenuPrice}\n" 
                );
        }
    }
}
