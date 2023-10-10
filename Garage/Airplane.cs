using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Airplane class that inherits from Vehicle
    public class Airplane : Vehicle
    {
        private int enginesNumber;

        public Airplane(string registrationNumber, string color, int wheelsNumber, int enginesNumber) : base(registrationNumber, color, wheelsNumber)
        {
            EnginesNumber = enginesNumber;
        }

        public int EnginesNumber
        {
            get => enginesNumber;
            set
            {
                enginesNumber = value;
            }
        }

        public override string GetInfo() => $"Type: Airplane, {base.GetInfo()}, EnginesNumber: {EnginesNumber}";
    }
}
