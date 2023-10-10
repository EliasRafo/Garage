using Garage.Helpers;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage
{
    public static class VehicleGenerator
    {
        private static IHelper helper = new Helper();

        public static bool GenerateVehicle(string vehicle, GarageHandler garageHandler)  // GenerateVehicle method
        {
            string registrationNumber = UserInput.AskForString("Enter the registration number", helper, UserInput.CheckRegistrationNumber);   // Asking user to enter the registration number and check if it is in correct form

            if (!garageHandler.SearchByRegNo(registrationNumber))  // Checking if vehicle is in garage or not
            {
                string color = UserInput.AskForString("Enter the color", helper);  // Ask user to enter vehicle color

                if (vehicle == "Car")  // Checking if vehicle is Car
                {
                    int wheelsNumber = UserInput.AskForInt("Enter the wheels number", helper, UserInput.CheckCarWheelsNumber);  // Asking user to enter vehicle wheels number and validate it

                    string fuelType = UserInput.AskForString("Enter the Fuel type", helper);   // Asking user to enter fuel type

                    garageHandler.ParkVehicle(new Car(registrationNumber, color, wheelsNumber, fuelType));   // Park vehicle in the garage
                    return true;
                }
                else if (vehicle == "Bus")  // Checking if vehicle is Bus
                {
                    int wheelsNumber = UserInput.AskForInt("Enter the wheels number", helper, UserInput.CheckBusWheelsNumber);  // Asking user to enter vehicle wheels number and validate it

                    int seatsNumber = UserInput.AskForInt("Enter the seats number", helper);   // Asking user to enter seats number

                    garageHandler.ParkVehicle(new Bus(registrationNumber, color, wheelsNumber, seatsNumber));   // Park vehicle in the garage
                    return true;
                }
                else if (vehicle == "Boat")  // Checking if vehicle is Boat
                {
                    int wheelsNumber = UserInput.AskForInt("Enter the wheels number", helper, UserInput.CheckBoatWheelsNumber);  // Asking user to enter vehicle wheels number and validate it

                    int length = UserInput.AskForInt("Enter the length", helper);  // Asking user to enter length

                    garageHandler.ParkVehicle(new Boat(registrationNumber, color, wheelsNumber, length));  // Park vehicle in the garage
                    return true;
                }
                else if (vehicle == "Airplane")  // Checking if vehicle is Airplane
                {
                    int wheelsNumber = UserInput.AskForInt("Enter the wheels number", helper, UserInput.CheckAirplaneWheelsNumber);  // Asking user to enter vehicle wheels number and validate it

                    int enginesNumber = UserInput.AskForInt("Enter the engines number", helper);  // Asking user to enter engines number

                    garageHandler.ParkVehicle(new Airplane(registrationNumber, color, wheelsNumber, enginesNumber));  // Park vehicle in the garage
                    return true;
                }
                else
                {
                    int wheelsNumber = UserInput.AskForInt("Enter the wheels number", helper, UserInput.CheckMotorcycleWheelsNumber);  // Asking user to enter vehicle wheels number and validate it

                    int cylinderVolume = UserInput.AskForInt("Enter the cylinder volume", helper);  // Asking user to enter cylinder volume

                    garageHandler.ParkVehicle(new Motorcycle(registrationNumber, color, wheelsNumber, cylinderVolume));  // Park vehicle in the garage
                    return true;
                }
            }
            else
            {
                helper.Print("Vehicle is already exist.");
                return false;
            }
        }

    }
}

