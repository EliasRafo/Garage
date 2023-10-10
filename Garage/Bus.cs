using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Bus class that inherits from Vehicle
    public class Bus : Vehicle
    {
        private int seatsNumber;

        public Bus(string registrationNumber, string color, int wheelsNumber, int seatsNumber) : base(registrationNumber, color, wheelsNumber)
        {
            SeatsNumber = seatsNumber;
        }

        public int SeatsNumber
        {
            get => seatsNumber;
            set
            {
                seatsNumber = value;
            }
        }

        public override string GetInfo() => $"Type: Bus, {base.GetInfo()}, SeatsNumber: {SeatsNumber}";

    }
}
