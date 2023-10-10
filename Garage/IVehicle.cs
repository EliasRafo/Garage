using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        int WheelsNumber { get; set; }
    }
}
