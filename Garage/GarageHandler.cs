using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageHandler : IGarageHandler
    {
        private Garage<Vehicle> garage;

        GarageSaver saver = new GarageSaver();
        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public Vehicle? SearchOnRegNo(string regNo)  // Returns vehicle depending on registration number
        {
            return garage.FirstOrDefault(v => v.RegistrationNumber.ToUpper() == regNo.ToUpper());
        }

        public bool SearchByRegNo(string regNo)  // To check if vehicle is existing in garage
        {
            var v = SearchOnRegNo(regNo);
            if (v != null) return true;
            return false;
        }

        public bool CheckOut(string regNo)  // Check Out the vehicle from garage
        {
            var v = SearchOnRegNo(regNo);

            if (v != null)
            {
                garage.RemoveVehicle(v);  // Remove vehicle from garage

                return true;
            }

            return false;
        }

        public void ParkVehicle(Vehicle vehicle)   // Park vehicle in garage
        {
            if (vehicle != null)
            {
                var v = SearchOnRegNo(vehicle.RegistrationNumber);

                if (v == null)
                {
                    garage.AddVehicle(vehicle);   // Add vehicle to garage
                }
            }
        }

        public List<Vehicle> GetAllParkedVehicles()  // Getting all parked vehicles
        {
            return garage.ToList();
        }

        public List<VehicleTypesDto> GetVehicleTypes()  // Calculating count of vehicles depending on its type
        {
            return garage.GroupBy(x => x.GetType().Name).Select(grp => new VehicleTypesDto(grp.Key, grp.Count())).ToList();
        }

        public List<Vehicle>? FindVehicles(string type, string color, int wheelsNumber)  // Finding vehicles depending on its type, color and wheels number
        {
            var res = garage.AsEnumerable();

            switch (type)
            {
                case "Airplane":
                    res = res.Where(val => val.GetType() == typeof(Airplane));  // Getting all vehicle of type Airplane
                    break;
                case "Boat":
                    res = res.Where(val => val.GetType() == typeof(Boat));   // Getting all vehicle of type Boat
                    break;
                case "Bus":
                    res = res.Where(val => val.GetType() == typeof(Bus));  // Getting all vehicle of type Bus
                    break;
                case "Car":
                    res = res.Where(val => val.GetType() == typeof(Car));  // Getting all vehicle of type Car
                    break;
                case "Motorcycle":
                    res = res.Where(val => val.GetType() == typeof(Motorcycle));   // Getting all vehicle of type Motorcycle
                    break;
            }

            if (color != "none")
                res = res.Where(val => val.Color.ToUpper() == color.ToUpper());
            if (wheelsNumber >= 0)
                res = res.Where(val => val.WheelsNumber == wheelsNumber);

            return res.ToList();
        }

        public bool IsFull => garage.IsFull;
        
        public bool LoadGarage()  // Loading garage
        {
            var g = saver.Load();
            if (g is not null)
            {
                foreach (var val in g)
                {
                    ParkVehicle(val);
                }
                return true;
            }

            return false;
        }

        public bool SaveGarage()  // Saving garage in a file
        {
            return saver.Save(garage);
        }
    }
}
