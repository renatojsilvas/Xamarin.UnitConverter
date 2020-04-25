namespace UnitConverter
{
    internal abstract class Unit
    {
        internal double Point1 { get; set; }
        internal double Point2 { get; set; }
        internal string FullName { get; set; }
        internal string Symbol { get; set; }
        internal string Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return FullName == ((Unit)obj).FullName;
        }
    }
}
