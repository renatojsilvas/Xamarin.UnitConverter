using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    internal class Rankine : Unit
    {
        internal Rankine()
        {
            Point1 = 419.67;
            Point2 = 671.67;
            FullName = "Rankine";
            Symbol = "Ra";
            Quantity = "Temperature";
        }
    }
}
