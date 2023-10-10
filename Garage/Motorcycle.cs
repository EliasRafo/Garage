using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Motorcycle class that inherits from Vehicle
    public class Motorcycle : Vehicle
    {
        private int cylinderVolume;

        public Motorcycle(string registrationNumber, string color, int wheelsNumber, int cylinderVolume) : base(registrationNumber, color, wheelsNumber)
        {
            CylinderVolume = cylinderVolume;
        }

        public int CylinderVolume
        {
            get => cylinderVolume;
            set
            {
                cylinderVolume = value;
            }
        }

        public override string GetInfo() => $"Type: Motorcycle, {base.GetInfo()}, CylinderVolume: {CylinderVolume}";
    }
}
