using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Pressure
{
    internal class Psi : Unit
    {
        internal Psi()
        {
            Point1 = 0.0;
            Point2 = 1.0 / 6.894757e3;
            FullName = "psi";
            Symbol = "psi";
            Quantity = "Pressure";
        }
    }
}
