using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using Garage.Helpers;
using Helpers;
using Microsoft.Extensions.Configuration;

namespace Garage
{
    internal class Manager
    {        
        private static IHelper helper = new Helper();
        private GarageHandler garageHandler;

        private IUI ui;
        private readonly IConfiguration config;
        public Manager(IUI ui, IConfiguration configuration) 
        {
            this.ui = ui;
            this.config = configuration;
        }
        internal void Run()
        {
            helper.Print("Välkommen till Garage 1.0");
            helper.Print("");

            var size = config.GetSection("Garage:Size").Value;
            if(!string.IsNullOrEmpty(size))
            {
                garageHandler = new GarageHandler(int.Parse(size));  // Create GarageHandler using the size

                helper.Print($"New garage has been created with capacity of {size} vehicles.");
                helper.Print("");
            }

            do
            {                
                ui.ShowMainMeny();  // Displaying main meny

                string input = helper.GetInput().ToUpper();   // Getting user input

                switch (input)  // Calling approperiet method depending on user input
                {
                    case MenyHelpers.CreateGarage:
                        CreateGarage();   // Creating new Garage
                        break;
                    case MenyHelpers.GetParkedVehicles:
                        GetParkedVehicles();  // Getting parked vehicles
                        break;
                    case MenyHelpers.GetVehicleTypes:
                        GetVehicleTypes();  // Getting vehicles by its type and display its count
                        break;
                    case MenyHelpers.AddVehicle:
                        AddVehicle();   // Adding a vehicle
                        break;
                    case MenyHelpers.RemoveVehicle:
                        RemoveVehicle();    // Removing a vehicle                   
                        break;
                    case MenyHelpers.FindByRegistrationNumber:
                        FindByRegistrationNumber();   // Find a vehicle by registration number
                        break;
                    case MenyHelpers.SearchVehicles:
                        SearchVehicles();    // Searching the garage
                        break;
                    case MenyHelpers.PopulateGarage:
                        PopulateGarage();   // Populate the garage
                        break;
                    case MenyHelpers.CreateBackup:   // Create backup
                        CreateBackup();      
                        break;
                    case MenyHelpers.LoadBackup:   // Load backup
                        LoadBackup();
                        break;
                    case MenyHelpers.ExitApplication:
                        Environment.Exit(0);
                        break;
                    default:
                        helper.Print("It is incorrect input.");
                        break;
                }
            } while (true);
        }

        private void CreateGarage()  // Creating new Garage
        {
            int capacity = ui.GetCapacity();  // Calling GetCapacity method, that ask user to input the capacity and return its value.
            garageHandler = new GarageHandler(capacity);  // Create GarageHandler using the capacity

            helper.Print($"New garage has been created with capacity of {capacity} vehicles.");
            helper.Print("");
        }

        private void GetParkedVehicles()   // Getting parked vehicles
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                var list = garageHandler.GetAllParkedVehicles();  // Calling GetAllParkedVehicles() method

                if (list.Count > 0)
                    list.ForEach(x => helper.Print($"- {x.GetInfo()}"));  // print all vehicles by using ForEach-loop.
                else
                    helper.Print("No vehicles found");
            }
                
            else
                helper.Print("You have to create garage first.");

            helper.Print("");
        }

        private void GetVehicleTypes()   // Getting vehicles by its type and display its count
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                var list = garageHandler.GetVehicleTypes();  // Calling GetVehicleTypes() method
                if (list.Count > 0)
                    list.ForEach(x => helper.Print($"- Type: {x.Name}, Total: {x.Total}"));  // Display vehicles type with its count in garage
                else
                    helper.Print("No vehicles found");
            }
            else
                helper.Print("You have to create garage first.");

            helper.Print("");
        }

        private void AddVehicle()  // Adding a vehicle
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                do
                {
                    switch (ui.ShowAddVehicleMeny())  // Displaying AddVehicle meny and get user input
                    {
                        case "1":
                            AddVehicle("Car");   // Calling AddVehicle method and pass vehicle type to it
                            break;
                        case "2":
                            AddVehicle("Bus");
                            break;
                        case "3":
                            AddVehicle("Boat");
                            break;
                        case "4":
                            AddVehicle("Airplane");
                            break;
                        case "5":
                            AddVehicle("Motorcycle");
                            break;
                        case "0":
                            return;
                        default:
                            helper.Print("It is incorrect input.");
                            break;
                    }
                } while (true);
            }
            else
                helper.Print("You have to create garage first.");

            helper.Print("");

        }

        private void AddVehicle(string vehicle)
        {
            if (!garageHandler.IsFull)  // Checking if garage is full
            {
                if(VehicleGenerator.GenerateVehicle(vehicle, garageHandler))   // Calling GenerateVehicle method
                {
                    helper.Print("Vehicle parked successfully.");
                }
                else
                {
                    helper.Print("The Vehicle can not be parked.");
                }
            }
            else
                helper.Print("Garage is full.");
            helper.Print("");
        }

        private void RemoveVehicle()  // Removing a vehicle
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                string registrationNumber = ui.GetRegNo();  // Asking user to enter registration number and checking if it is in correct format.

                if (garageHandler.SearchByRegNo(registrationNumber))  // Checking if vehicle is exist in the garage
                {
                    if(garageHandler.CheckOut(registrationNumber))  // Calling CheckOut method
                        helper.Print("Vehicle is Checked Out from garage successfully.");
                    else
                        helper.Print("Vehicle has not been Checked Out from the garage.");
                }
                else
                    helper.Print($"Vehicle with registration number ({registrationNumber}) not found in the garage");
            }
            else
                helper.Print("You have to create garage first.");
            helper.Print("");
        }

        private void FindByRegistrationNumber()
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                // Asking user to enter the registration number and get vehicle depending on registration number
                var vehicle = garageHandler.SearchOnRegNo(ui.GetRegNo());
                if (vehicle == null)
                {
                    helper.Print("No vehicle found.");
                }
                else
                {
                    helper.Print(vehicle.GetInfo());  // Displaying vehicle information
                }
            }
            else
                helper.Print("You have to create garage first.");

            helper.Print("");
        }

        private void SearchVehicles()
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                string query = ui.GetSearchInput();  // Getting search input from user

                if (!string.IsNullOrEmpty(query))  // Checking if search query is null or empty
                {
                    var x = query.Split('*');

                    List<Vehicle>? list = garageHandler.FindVehicles(x[0], x[1], int.Parse(x[2]));  // Calling FindVehicles method

                    if (list is not null && list.Count > 0)  // Checking the result of search
                    {
                        helper.Print("The result:");
                        list.ForEach(v => helper.Print($"- {v.GetInfo()}"));   // Displaying search result
                    }
                    else
                    {
                        helper.Print("No result found");
                    }
                }
            }
            else
                helper.Print("You have to create garage first.");
            helper.Print("");
        }

        private void PopulateGarage()
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                var Vehicles = new Vehicle[]
                {
                    new Car("ABC123", "Black", 4, "Diesel"),
                    new Motorcycle("FGX448", "Red", 3, 4),
                    new Bus("ACB334","Blue",4 , 20)

                };

                    foreach (Vehicle vehicle in Vehicles)
                    {
                        if (!garageHandler.IsFull)
                        {
                            if (!garageHandler.SearchByRegNo(vehicle.RegistrationNumber))  // Checking if vehicle is in garage or not
                            {
                                garageHandler.ParkVehicle(vehicle);
                            }
                        }
                    }
            }
            else
                helper.Print("You have to create garage first.");
            helper.Print("");
        }

      private void LoadBackup()
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                helper.Print("Loading garage will erase the current one. Do you want to load garage? (y/n)");
                string input = helper.GetInput().ToUpper();

                if (input == "Y")
                    if (garageHandler.LoadGarage())
                        helper.Print("Garage loaded successfully");
                    else
                        helper.Print("Can not load the garage");
            }
            else
                helper.Print("You have to create garage first.");

            helper.Print("");
        }

        private void CreateBackup()
        {
            if (garageHandler is not null)  // Checking if user created a garage
            {
                if (garageHandler.SaveGarage())
                    helper.Print("Backup created successfully");
                else
                    helper.Print("Can not create backup");
            }
            else
                helper.Print("You have to create garage first.");

            helper.Print("");
        }
               
    }
}
