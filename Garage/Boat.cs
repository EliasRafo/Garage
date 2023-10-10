using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Boat class that inherits from Vehicle
    public class Boat : Vehicle
    {
        private int length;

        public Boat(string registrationNumber, string color, int wheelsNumber, int length) : base(registrationNumber, color, wheelsNumber)
        {
            Length = length;
        }

        public int Length
        {
            get => length;
            set
            {
                length = value;
            }
        }

        public override string GetInfo() => $"Type: Boat, {base.GetInfo()}, Length: {Length}";
    }
}
