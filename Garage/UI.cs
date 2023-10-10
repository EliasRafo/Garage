using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Helpers;
using Helpers;

namespace Garage
{
    public class UI : IUI
    {
        private static IHelper helper = new Helper();

        void IUI.ShowMainMeny()  // Displaying main meny
        {
            helper.Print("Vänligen navigera genom menyn genom att skriva en siffra som du väljer");
            helper.Print($"{MenyHelpers.CreateGarage}. Create garage");
            helper.Print($"{MenyHelpers.GetParkedVehicles}. Get all parked vehicles");
            helper.Print($"{MenyHelpers.GetVehicleTypes}. Get vehicle types and its count");
            helper.Print($"{MenyHelpers.AddVehicle}. Add vehicle");
            helper.Print($"{MenyHelpers.RemoveVehicle}. Remove vehicle");
            helper.Print($"{MenyHelpers.FindByRegistrationNumber}. Find vehicle by registration number");
            helper.Print($"{MenyHelpers.SearchVehicles}. Search for vehicles");
            helper.Print($"{MenyHelpers.PopulateGarage}. Populate the garage with some vehicles"); 
            helper.Print($"{MenyHelpers.CreateBackup}. Create garage backup");
            helper.Print($"{MenyHelpers.LoadBackup}. Load garage backup");
            helper.Print($"{MenyHelpers.ExitApplication}. Sluta");
        }

        public string ShowAddVehicleMeny()   // Displaying AddVehicle meny
        {
            helper.Print("Vänligen navigera genom menyn genom att skriva en siffra som du väljer");
            helper.Print($"1. Create Car");
            helper.Print($"2. Create Bus");
            helper.Print($"3. Create Boat");
            helper.Print($"4. Create Airplane");
            helper.Print($"5. Create Motorcycle");
            helper.Print($"0. Exit");

            return helper.GetInput().ToUpper();   // Getting user input
        }

        public int GetCapacity()  // Getting garage capacity.
        {
            // Asking user to enter the capacity and check  if it is bigger than zero using delegates.
            return UserInput.AskForInt("Enter the capacity of garage", helper, UserInput.CheckCapacity);
        }

        public string GetRegNo()
        {
            return UserInput.AskForString("Enter the registration number", helper, UserInput.CheckRegistrationNumber);  // Asking user to enter the registration number and check if it is in correct form
        }

        public string GetSearchInput()  // Getting search input from user
        {
            string query = "";

            helper.Print("To search vehicles you have to choose vehicle type");
            helper.Print("1. Car");
            helper.Print("2. Bus");
            helper.Print("3. Boat");
            helper.Print("4. Airplane");
            helper.Print("5. Motorcycle");
            helper.Print("6. All");

            string input = helper.GetInput().ToUpper();  // Getting user input

            switch (input)  
            {
                case "1":
                    query += "Car*";
                    break;
                case "2":
                    query += "Bus*";
                    break;
                case "3":
                    query += "Boat*";
                    break;
                case "4":
                    query += "Airplane*";
                    break;
                case "5":
                    query += "Motorcycle*";
                    break;
                default:
                    query += "All*";
                    break;
            }

            helper.Print("Do you want to search vehicles by color? (y/n)");  // Asking if user want to search vehicles by color
            input = helper.GetInput().ToUpper();

            if (input == "N")
                query += "none*";
            else
            {
                query += $"{UserInput.AskForString("Enter the color: ", helper)}*";
            }

            helper.Print("Do you want to search vehicles by wheels number? (y/n)");  // Asking if user want to search vehicles by wheels number
            input = helper.GetInput().ToUpper();

            if (input == "N")
                query += "-1";
            else
            {                
                query += $"{UserInput.AskForInt("Enter the wheels number: ", helper, UserInput.CheckWheelsNumber)}";
            }

            return query;
        }
    }
}
