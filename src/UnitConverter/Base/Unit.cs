namespace UnitConverter
{
    public abstract class Unit
    {
        public double Point1 { get; protected set; }
        public double Point2 { get; protected set; }
        public string FullName { get; protected set; }
        public string Symbol { get; protected set; }
        public string Quantity { get; protected set; }
    }
}
