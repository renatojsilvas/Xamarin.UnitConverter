using Math.Functions;
using Math.Geometry;

namespace UnitConverter
{
    public class UnitsConverter
    {
        private readonly Quantity sourceQuantity;
        private readonly Quantity destinationQuantity;

        public UnitsConverter(Quantity sourceQuantity, Quantity destinationQuantity)
        {
            this.sourceQuantity = sourceQuantity;
            this.destinationQuantity = destinationQuantity;
        }

        public double Convert(double value)
        {
            Point point1 = new Point(sourceQuantity.Point1, destinationQuantity.Point1);
            Point point2 = new Point(sourceQuantity.Point2, destinationQuantity.Point2);
            LinearFunction linearFunction = new LinearFunction(point1, point2);
            return linearFunction.Evaluate(value);
        }
    }
}
