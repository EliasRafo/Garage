using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Car class that inherits from Vehicle
    public class Car : Vehicle
    {
        private string fuelType;

        public Car(string registrationNumber, string color, int wheelsNumber, string fuelType) : base(registrationNumber, color, wheelsNumber)
        {
            FuelType = fuelType;
        }

        public string FuelType
        {
            get => fuelType;
            set
            {
                fuelType = value;
            }
        }

        public override string GetInfo() => $"Type: Car, {base.GetInfo()}, FuelType: {FuelType}";
        

    }
}
