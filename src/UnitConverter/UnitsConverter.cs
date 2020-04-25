using Math.Functions;
using Math.Geometry;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitConverter.Tests")]
namespace UnitConverter
{
    internal class UnitsConverter
    {
        private readonly Unit sourceUnit;
        private readonly Unit destinationUnit;

        internal UnitsConverter(Unit sourceUnit, Unit destinationUnit)
        {
            this.sourceUnit = sourceUnit;
            this.destinationUnit = destinationUnit;
        }

        internal double Convert(double value)
        {
            Point point1 = new Point(sourceUnit.Point1, destinationUnit.Point1);
            Point point2 = new Point(sourceUnit.Point2, destinationUnit.Point2);
            LinearFunction linearFunction = new LinearFunction(point1, point2);
            return linearFunction.Evaluate(value);
        }
    }
}
