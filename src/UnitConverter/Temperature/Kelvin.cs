namespace UnitConverter
{
    internal class Kelvin : Unit
    {
        internal Kelvin()
        {
            Point1 = 273.15;
            Point2 = 373.15;
            FullName = "Kelvin";
            Symbol = "K";
            Quantity = "Temperature";
        }
    }
}
