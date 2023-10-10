using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Garage
{
    [JsonDerivedType(typeof(Car), "Car")]
    [JsonDerivedType(typeof(Bus), "Bus")]
    [JsonDerivedType(typeof(Boat), "Boat")]
    [JsonDerivedType(typeof(Motorcycle), "Motorcycle")]
    [JsonDerivedType(typeof(Airplane), "Airplane")]
    public class Vehicle : IVehicle
    {
        private string registrationNumber;
            public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                // Implementing validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("RegistrationNumber is mandatory");

                registrationNumber = value;
            }
        }

        private string color;
        public string Color
        {
            get => color;
            set
            {
                // Implementing validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Color is mandatory");

                color = value;
            }
        }

        private int wheelsNumber;
        public int WheelsNumber
        {
            get => wheelsNumber;
            set
            {
                wheelsNumber = value;
            }
        }

        public Vehicle(string registrationNumber, string color, int wheelsNumber)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            WheelsNumber = wheelsNumber;
        }

        public virtual string GetInfo()  
        {            
            return $"RegistrationNumber: {RegistrationNumber}, Color: {Color}, WheelsNumber: {WheelsNumber}";
        }
    }
}
