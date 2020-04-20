namespace UnitConverter
{
    public class Kelvin : Unit
    {
        public Kelvin()
        {
            Point1 = 273.15;
            Point2 = 373.15;
            FullName = "Kelvin";
            Symbol = "K";
            Quantity = "Temperature";
        }
    }
}
