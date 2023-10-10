using Garage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Garage.Constants;

namespace Helpers
{
    public static class UserInput
    {
        // AskForString static method, used to check if user input is not null or white space.
        public static string AskForString(string prompt, IHelper helper)
        {
            bool success = false;
            string answer;

            do
            {
                helper.Print($"{prompt}: ");
                answer = helper.GetInput();  // Getting user input

                if (string.IsNullOrWhiteSpace(answer))  // check if user input is null or white space.
                {
                    helper.Print($"You must enter a valid {prompt}");  // Asking user to enter a valid input
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        // AskForUInt static method, used to check if user input an int.
        public static int AskForInt(string prompt, IHelper helper)
        {
            do
            {
                string input = AskForString(prompt, helper);  // Calling AskForString method

                if (int.TryParse(input, out int result))  // TryParse user input
                {
                    return result;
                }

            } while (true);
        }


        public static string AskForString(string prompt, IHelper helper, Predicate<string> obj)
        {
            bool success = false;
            string answer;

            do
            {
                helper.Print($"{prompt}: ");
                answer = helper.GetInput();  // Getting user input

                if (string.IsNullOrWhiteSpace(answer))  // check if user input is null or white space.
                {
                    helper.Print($"You must enter a valid {prompt}");  // Asking user to enter a valid input
                }
                else
                {
                    if (obj(answer))
                        success = true;
                }

            } while (!success);

            return answer;
        }

        public static int AskForInt(string prompt, IHelper helper,  Func<int, bool> obj)
        {
            do
            {
                string input = AskForString(prompt, helper);  // Calling AskForString method

                if (int.TryParse(input, out int result))  // TryParse user input
                {
                    if (obj(result))  // Using delegate to check user input depending on specific condition
                        return result;
                }

            } while (true);
        }

        public static bool CheckCapacity(int x)  // CheckCapacity method to check if capacity is bigger than zero.
        {
            if (x > 0)
                return true;
            else
            {
                Console.WriteLine("Capacity should be bigger than zero.");

                return false;
            }
        }

        public static bool CheckRegistrationNumber(string regnr)  // CheckRegistrationNumber method to check registration number.
        {
            if (regnr.Length > VehicleNumbers.MinRegnr && regnr.Length <= VehicleNumbers.MaxRegnr)
            {
                if (Regex.IsMatch(regnr, @"^[a-zA-Z]{3}[0-9]{3}$"))  // Checking if user enter registration number in correct format.
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("The registration number should be in this form ABC123.");

                    return false;
                }
            }
                
            else
            {
                Console.WriteLine("The registration number should be in this form ABC123.");

                return false;
            }
        }


        public static bool CheckCarWheelsNumber(int x)  
        {
            if (x >= VehicleNumbers.MinCar && x <= VehicleNumbers.MaxCar)
                return true;
            else
            {
                Console.WriteLine("Wheels number should be between 3 and 4.");

                return false;
            }
        }

        public static bool CheckBusWheelsNumber(int x)
        {
            if (x >= VehicleNumbers.MinBus && x <= VehicleNumbers.MaxBus)
                return true;
            else
            {
                Console.WriteLine("Wheels number should be between 4 and 10.");

                return false;
            }
        }

        public static bool CheckBoatWheelsNumber(int x)
        {
            if (x == VehicleNumbers.Boat)
                return true;
            else
            {
                Console.WriteLine("Boats have not wheels, enter 0.");

                return false;
            }
        }

        public static bool CheckAirplaneWheelsNumber(int x)
        {
            if (x >= VehicleNumbers.MinAirplane && x <= VehicleNumbers.MaxAirplane)
                return true;
            else
            {
                Console.WriteLine("Wheels number should be between 3 and 10.");

                return false;
            }
        }

        public static bool CheckMotorcycleWheelsNumber(int x)
        {
            if (x >= VehicleNumbers.MinMotorcycle && x <= VehicleNumbers.MaxMotorcycle)
                return true;
            else
            {
                Console.WriteLine("Wheels number should be between 2 and 4.");

                return false;
            }
        }

        public static bool CheckWheelsNumber(int x)
        {
            if (x >= 0)
                return true;
            else
            {
                Console.WriteLine("Wheels number should be greater or equal to zero");

                return false;
            }
        }

    }
}
