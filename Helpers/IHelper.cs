using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    public interface IHelper
    {
        string GetInput();
        void Print(string message);
    }
}