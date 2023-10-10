using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Helpers;

namespace Garage
{
    internal class Helper : IHelper
    {
        // Getting user input
        public string GetInput()
        {
            return Console.ReadLine()!;
        }
        // Print message to user
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
