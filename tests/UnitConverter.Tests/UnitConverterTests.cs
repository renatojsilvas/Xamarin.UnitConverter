using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests
{
    public class UnitConverterTests
    {
        [Theory]
        [InlineData(0.0, 273.15)]
        [InlineData(100.0, 373.15)]
        public void Convert_Temperature_Celsius_To_Kelvin(double celsiusValue, double kelvinValue)
        {
            //Arrange
            Unit sourceUnit = new Celsius();
            Unit destinationUnit = new Kelvin();
            UnitsConverter unitConverter = new UnitsConverter(sourceUnit, destinationUnit);

            //Act
            double result = unitConverter.Convert(celsiusValue);

            //Assert
            result.Should().Be(kelvinValue);
        }
    }
}
