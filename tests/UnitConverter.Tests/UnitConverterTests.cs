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
            Quantity sourceQuantity = new Celsius();
            Quantity destinationQuantity = new Kelvin();
            UnitsConverter unitConverter = new UnitsConverter(sourceQuantity, destinationQuantity);

            //Act
            double result = unitConverter.Convert(celsiusValue);

            //Assert
            result.Should().Be(kelvinValue);
        }
    }
}
