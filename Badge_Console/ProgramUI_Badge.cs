using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    class ProgramUI_Badge
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Access();
        }

        public void Access()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Add
                        AddBadge();
                        break;

                    case "2":
                        //Edit
                        UpdateDoor();
                        break;

                    case "3":
                        //List
                        ShowAccess();
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter valid selection\n\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;

                }
            }
        }

        //Add
        public void AddBadge()
        {
            Console.Clear();
            Badge access = new Badge();
            bool keepRunning = true;

            Console.WriteLine("Enter Badge Number");
            access.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door for access.");
            access.DoorAccess = Console.ReadLine();

            while (keepRunning)
            {
                Console.WriteLine("Any other doors needed for access? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("List a door for access");
                    access.DoorAccess = Console.ReadLine();

                }
                else if (answer == "n")
                {
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                }
            }
            _badgeRepo.AddBadge(access);
            Console.ReadKey();
        }


        //Edit
        private void UpdateDoor()
        {
            Console.Clear();
            Badge access = new Badge();
            bool keepRunning = true;
            
            Console.WriteLine("Enter badge number to update");
            //access.BadgeId = int.Parse(Console.ReadLine());
            int badgeId = Convert.ToInt32(Console.ReadLine());

            Badge accessContent = _badgeRepo.GetBadge(badgeId);
            if(accessContent == null)
            {
                Console.WriteLine("Not able to find a match");
                Console.WriteLine("Press any key to continue..");
                return;
            }
            

            while (keepRunning)
            {
                ShowAccess();

                Console.WriteLine("");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove Door\n" +
                    "2. Add a Door\n" +
                    "3. Exit\n");

                string userInput = Console.ReadLine();


                switch (userInput)
                {
                    case "1":
                        //Remove Door
                        DeleteDoor();
                        break;

                    case "2":
                        //Add a door
                        AddDoor();
                            break;

                    case "3":
                        keepRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Selection\n" +
                            "Press any key to continue...");
                        keepRunning = false;
                        Console.ReadLine();
                        break;
                }


            }
        }
        //Remove Door
        /*public void RemoveDoor()
        {
            Console.Clear();
            Badge access = new Badge();
            Dictionary<int, Badge> badgeDirectory = new Dictionary<int, Badge>();


            Console.WriteLine("Which door would you like to remove?");
            access.DoorAccess = Console.ReadLine();




        }*/

        //Add door
        public void AddDoor()
        {
            Console.Clear();
            Badge access = new Badge();
            
            Console.WriteLine("Enter Door for access");
            string doorAccess = Console.ReadLine();

            Badge badgeAccess = _badgeRepo.GetBadge(1);
            _badgeRepo.AddBadge(access);
            if (access != null)
            {
                DisplayAccess(access);
            }
            else
            {
                Console.WriteLine("Employee not in system");
            }
            Console.WriteLine("Press any key to continue");

            Badge updatedAccess = new Badge();
            Console.WriteLine($"Original Door Access: {access.DoorAccess}\n" +
                $"Please enter new Door Access:");
            access.DoorAccess = Console.ReadLine();
            //string doorAccess = Console.ReadLine();

            updatedAccess.DoorAccess = Console.ReadLine();

            if (_badgeRepo.UpdateDoor(badgeAccess, updatedAccess))
            {
                Console.WriteLine("Update Complete");
            }
            else
            {
                Console.WriteLine("Update Incomplete");
            }
            Console.ReadLine();

        }

        //List
        private void ShowAccess()
        {
            Console.Clear();
            List<Badge> listAccess = _badgeRepo.ShowAccess();
            foreach (Badge access in listAccess)
            {
                Dictionary<int, Badge> badgeDirectory = new Dictionary<int, Badge>();
                Console.WriteLine($"Badge ID: {access.BadgeId}\n" +
                    $"Door Access: {access.DoorAccess}");
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }



        //Delete
        private void DeleteDoor()
        {
            Console.Clear();

            List<Badge> listAccess = _badgeRepo.ShowAccess();

            int index = 1;
            Console.WriteLine("ID", "Door Access");
            foreach(Badge access in listAccess)
            {
                Console.WriteLine($"{index}.{access.BadgeId} {access.DoorAccess}");
                index++;
            }
            Console.WriteLine("");
            Console.WriteLine("Please select one");
            int doorAccess = int.Parse(Console.ReadLine());
            int doorIndex = doorAccess - 1;

            if(doorIndex >= 0 && doorIndex < listAccess.Count)
            {
                Badge accessContent = listAccess[doorIndex];
                if(_badgeRepo.DeleteDoor(accessContent))
                {
                    bool keepRunning = true;
                    while (keepRunning)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Are you sure you want to delete door access?");
                        

                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            Console.Clear();
                            Console.WriteLine($"{accessContent.DoorAccess} was successfully deleted");
                        }
                        else if (answer == "n")
                        {
                            keepRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("Press any key to Continue");
                            keepRunning = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid selection");
            }
            Console.WriteLine("\n" +
                "Press any key to continue..." );
            Console.ReadKey();
        }

        //Help 

        private void DisplayAccess(Badge access)
        {
            Console.WriteLine($"Badge ID: {access.BadgeId}\n" +
                $"Door Access: {access.DoorAccess}\n\n" );
        }
    }
}





