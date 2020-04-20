using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Rankine : Unit
    {
        public Rankine()
        {
            Point1 = 419.67;
            Point2 = 671.67;
            FullName = "Rankine";
            Symbol = "Ra";
            Quantity = "Temperature";
        }
    }
}
