using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ProgramUI_Claim
    {
        //Runs console
        private readonly ClaimRepo _claimRepository = new ClaimRepo();
        public void Run()
        {
            SeeData();
            RunMenu();
        }

        public void RunMenu()
        {
            //Menu Options

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                        "Komodo Claims Directory\n" +
                        "To-Do Items\n" +
                        "\n" +
                        "1. Create New Claim\n" +
                        "2. Claim Directory\n" +
                        "3. Show Next claim\n" +
                        "4. Exit"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Create new claim
                        CreateClaim();
                        break;

                    case "2":
                        //Claim Directory
                        GetClaim();
                        break;

                    case "3":
                        //Next claim
                        NextClaim();
                        break;

                    case "4":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid choice\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }

        }

        //Create claim
        private void CreateClaim()
        {
            Console.Clear();
            Claim info = new Claim();

            //ClaimID
            Console.WriteLine("Enter Claim ID");
            info.ClaimId = int.Parse(Console.ReadLine());
            //ClaimType
            Console.WriteLine("Enter Type of Claim");
            info.ClaimType = Console.ReadLine();
            //Description
            Console.WriteLine("Enter Description");
            info.Description = Console.ReadLine();
            //Amount
            Console.WriteLine("Enter Claim Amount");
            info.ClaimAmount = decimal.Parse(Console.ReadLine());

            //IncidentDate
            Console.WriteLine("Enter Date of Incident (ex. 2021/01/15):");
            info.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            //ClaimDate
            Console.WriteLine("Enter Date of Claim (ex. 2021/01/15:");
            info.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            //isValid
            Console.WriteLine("Is Claim Valid?");
            info.IsValid = bool.Parse(Console.ReadLine());


            _claimRepository.CreateClaim(info);
            Console.ReadKey();
        }

        //Claim Directory
        private void GetClaim()
        {
            Console.Clear();

            List<Claim> listOfClaim = _claimRepository.GetClaim();
            

            Console.WriteLine(" {0,-6}  {1, -10}  {2, -10}  {3,7}  {4,20}  {5,15}  {6,20}", "ID", "Type", "Description", "Amount", "DateOfAccident  ", "DateOfClaim", "IsValid");
            Console.WriteLine("");

            foreach (Claim info in listOfClaim)
            {
                DisplayInfo(info);

            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //Show Next claim
        private void NextClaim()
        {
            Console.Clear();
            List<Claim> claimList = _claimRepository.GetClaim();
            int index = 1;
            Console.WriteLine(" {0,4}  {1, -10}  {2, -10}  {3,7}  {4,20}  {5,15}  {6,20}", "ID", "Type", "Description", "Amount", "DateOfAccident  ", "DateOfClaim", "IsValid");
            foreach (Claim info in claimList)
            {
                Console.WriteLine($"{ index}. {info.ClaimId}  {info.ClaimType} {info.Description} {info.ClaimAmount} {info.DateOfClaim} {info.DateOfIncident} {info.IsValid}");
                index++;
            }
            Console.WriteLine("");
            Console.WriteLine("Enter claim selection");
            int targetClaimId = int.Parse(Console.ReadLine());
            int targetIndex = targetClaimId - 1;
            if (targetIndex >= 0 && targetIndex < claimList.Count)
            {
                Claim targetClaim = claimList[targetIndex];
                if (_claimRepository.DeleteClaim(targetClaim))
                {
                    bool keepRunning = true;
                    while (keepRunning)
                    {

                        Console.WriteLine("");
                        Console.WriteLine("Do you want to deal with this claim now (y/n)?");

                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            Console.Clear();
                            Console.WriteLine($"{targetClaim.ClaimId} was succesfully deleted");

                        }
                        else if (answer == "n")
                        {
                            keepRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("Press any key to continue..");
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
                Console.WriteLine("Please try again");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Display Info
        private void DisplayInfo(Claim info)
        {
            //Console.WriteLine("{0,-6} {1, -0}  {2, -20} {3,6} {4,6} {5,6} {6,6}", "Claim ID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            Console.WriteLine(" {0, -6}  {1, -10}  {2, -10}  {3,6}  {4,20}  {5,10}  {6,10}", info.ClaimId, info.ClaimType, info.Description, info.ClaimAmount, info.DateOfClaim, info.DateOfIncident, info.IsValid);
            Console.WriteLine("");
        }

        private void SeeData()
        {
            Claim one = new Claim(1, "Home", "Water Damage", 5000, new DateTime(2021, 09, 23), new DateTime(2021, 09, 15), true);
            Claim two = new Claim(2, "Home", "Smoke Damage", 2000, new DateTime(2021, 10, 01), new DateTime(2021, 10, 03), true);

            _claimRepository.CreateClaim(one);
            _claimRepository.CreateClaim(two);

        }
    }
}



