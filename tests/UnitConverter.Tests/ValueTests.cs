using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Globalization;

namespace UnitConverter.Tests
{
    public class ValueTests
    {
        [Fact]
        public void Create_value_from_unit_symbol()
        {
            //Arrange
            Value sut = new Value(1.25, "°C");

            //Act


            //Assert
            sut.Amount.Should().Be(1.25);
            sut.ToString(2).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("1.2 °C");
        }

        [Fact]
        public void Create_value_from_unit_full_name()
        {
            //Arrange
            Value sut = new Value(1.25, "Celsius");

            //Act


            //Assert
            sut.Amount.Should().Be(1.25);
            sut.ToString(2).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("1.2 °C");
        }

        [Fact]
        public void Create_value_from_string_value()
        {
            //Arrange
            Value sut = new Value("1.25 °C");

            //Act


            //Assert
            sut.Amount.Should().Be(1.25);
            sut.ToString(3).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("1.25 °C");
        }
    }
}
