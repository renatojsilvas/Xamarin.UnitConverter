namespace UnitConverter
{
    public abstract class Unit
    {
        internal double Point1 { get; set; }
        internal double Point2 { get; set; }
        public string FullName { get; set; }
        public string Symbol { get; set; }
        public string Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return FullName == ((Unit)obj).FullName;
        }
    }
}
