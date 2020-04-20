using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Fahrenheit : Unit
    {
        public Fahrenheit()
        {
            Point1 = 32.0;
            Point2 = 212.0;
            FullName = "Fahrenheit";
            Symbol = "°F";
            Quantity = "Temperature";
        }
    }
}
