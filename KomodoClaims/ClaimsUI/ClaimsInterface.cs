using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;
using System.Globalization;

namespace ClaimsUI
{
    public class ClaimsInterface
    {

        private readonly ClaimsRepository _claims = new ClaimsRepository();

        
        public void Run()
        {
            ClaimsMenu();
        }
        
        private void ClaimsMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Claims Department Management System");
                Console.WriteLine("MENU");

                Console.WriteLine(
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n"
                );
                Console.Write("Select your option: ");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        // See all claims method
                        SeeAllClaims();
                        break;
                    case "2":
                        // Take care of next claim method
                        break;
                    case "3":
                        // Enter a new claim method
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.Write("Enter a valid selection: ");
                        selection = Console.ReadLine();
                        break;
                }
            }
        }

        public void HeaderBar()
        {
            Console.WriteLine("ClaimID  Type   Description              Amount      DateOfAccident  DateOfClaim  Valid");
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }
        public void DisplayClaim(Claim item)
        {
            // flexibility for formatting through variables
            int idPad = 7;
            int typePad = 5;
            int descriptionPad = 23;
            int amountPad = 9;
            int dateOfAccPad = 14;
            int dateofClaimPad = 11;
            
            string spacer = "  ";
            string idDisplay = item.ClaimID.ToString().PadRight(idPad) + spacer;
            string typeDisplay = item.ClaimType.ToString().PadRight(typePad) + spacer;
            string descriptionDisplay = item.ClaimDescription.PadRight(descriptionPad) + spacer;
            string amountDisplay = ("$" + item.TotalDamage.ToString().PadRight(amountPad)) + spacer;
            string dateOfAccDisplay = item.AccidentDate.ToShortDateString().PadRight(dateOfAccPad) + spacer;
            string dateofClaimDisplay = item.ClaimDate.ToShortDateString().PadRight(dateofClaimPad) + spacer;
            string claimValidDisplay = item.ClaimValid.ToString();
            Console.WriteLine(idDisplay + typeDisplay + descriptionDisplay + amountDisplay + dateOfAccDisplay + dateofClaimDisplay + claimValidDisplay);
            
        }
        // See all method
        public void SeeAllClaims()
        {
            Console.Clear();
            HeaderBar();
            Queue<Claim> listOfClaims = _claims.GetClaimList();
            foreach (Claim item in listOfClaims)
            {
                DisplayClaim(item);
            }
            Console.Write("Press any key to continue:");
            Console.ReadKey();
        }
        // Take care of next claim
        // Enter new claim
        public void EnterNewClaim()
        {
            Console.Clear();
            
            Claim newClaim = new Claim();

            int recommendedID = 1; // get some logic in here and recommend the minimum number
            Console.Write($"Enter the claim ID (recommended value {recommendedID}): ");
            string idToValidate = Console.ReadLine();  // validation here later
            newClaim.ClaimID = int.Parse(idToValidate);

            Console.Write("\nEnter the claim type (Car, Home, Theft): ");
            string typeOfClaim = Console.ReadLine().ToLower();
            switch (typeOfClaim)
            {
                case "car":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "home":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please only  enter \"Car\", \"Home\", or \"Theft\": ");
                    typeOfClaim = Console.ReadLine();
                    break;
            }
            
            Console.WriteLine("\nEnter a description of the claim (max 23 characters): ");
            int maxDescriptionSize = 23;
            string demarc = "V";
            Console.WriteLine(demarc.PadLeft(maxDescriptionSize - 1) + " - do not enter text past this point");
            
            newClaim.ClaimDescription = Console.ReadLine();

            Console.Write("\nEnter the claim amount: $ ");
            newClaim.TotalDamage = decimal.Parse(Console.ReadLine());
            
            Console.Write("\nEnter the date of the incident (format MM/DD/YY): ");
            string dateAccident = Console.ReadLine();
            newClaim.AccidentDate = DateTime.ParseExact(dateAccident, "MM/dd/yy", CultureInfo.InvariantCulture);

            Console.Write("\nEnter the date of the claim (format MM/DD/YY): ");
            string dateClaim = Console.ReadLine();
            newClaim.ClaimDate = DateTime.ParseExact(dateClaim, "MM/dd/yy", CultureInfo.InvariantCulture);

            TimeSpan maxTimeBetweenAccidentAndClaim = new TimeSpan(30, 0, 0, 0);
            TimeSpan actualTimeBetweenAccidentAndClaim = newClaim.ClaimDate.Subtract(newClaim.AccidentDate);

            if (actualTimeBetweenAccidentAndClaim <= maxTimeBetweenAccidentAndClaim)
            {
                newClaim.ClaimValid = true;
            }
            else
            {
                newClaim.ClaimValid = false;
            }
            
            _claims.AddNewClaim(newClaim);
        }

        // Need to Enqueue and Dequeue information
    }
}