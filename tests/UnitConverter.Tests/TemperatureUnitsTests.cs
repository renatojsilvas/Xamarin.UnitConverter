using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests
{
    public class TemperatureUnitsTests
    {
        [Fact]
        public void Check_If_Celsius_Is_Corrected_Created()
        {
            //Arrange
            Celsius sut = new Celsius();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("Celsius");
            sut.Symbol.Should().Be("°C");
            sut.Quantity.Should().Be("Temperature");
            sut.Point1.Should().Be(0.0);
            sut.Point2.Should().Be(100.0);
        }

        [Fact]
        public void Check_If_Kelvin_Is_Corrected_Created()
        {
            //Arrange
            Kelvin sut = new Kelvin();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("Kelvin");
            sut.Symbol.Should().Be("K");
            sut.Quantity.Should().Be("Temperature");
            sut.Point1.Should().Be(273.15);
            sut.Point2.Should().Be(373.15);
        }

        [Fact]
        public void Check_If_Fahrenheit_Is_Corrected_Created()
        {
            //Arrange
            Fahrenheit sut = new Fahrenheit();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("Fahrenheit");
            sut.Symbol.Should().Be("°F");
            sut.Quantity.Should().Be("Temperature");
            sut.Point1.Should().Be(32);
            sut.Point2.Should().Be(212);
        }

        [Fact]
        public void Check_If_Rankine_Is_Corrected_Created()
        {
            //Arrange
            Rankine sut = new Rankine();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("Rankine");
            sut.Symbol.Should().Be("Ra");
            sut.Quantity.Should().Be("Temperature");
            sut.Point1.Should().Be(419.67);
            sut.Point2.Should().Be(671.67);
        }
    }
}
