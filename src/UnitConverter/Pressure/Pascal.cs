using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    internal class Pascal : Unit
    {
        internal Pascal()
        {
            Point1 = 0.0;
            Point2 = 1.0;
            FullName = "Pascal";
            Symbol = "Pa";
            Quantity = "Pressure";
        }
    }
}
