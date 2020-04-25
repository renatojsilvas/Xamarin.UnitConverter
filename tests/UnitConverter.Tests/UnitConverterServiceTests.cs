using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests
{
    public class UnitConverterServiceTests
    {
        [Fact]
        public async void Convert_units_using_full_name_as_reference()
        {
            //Arrange
            UnitConverterService sut = new UnitConverterService();

            //Act
            ServiceResult result = await sut.ConvertUnit(0, "Celsius", "Fahrenheit");

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be(String.Empty);
            result.Value.ToString(2).Should().Be("32 °F");
        }

        [Fact]
        public async void Convert_units_using_symbol_as_reference()
        {
            //Arrange
            UnitConverterService sut = new UnitConverterService();

            //Act
            ServiceResult result = await sut.ConvertUnit(0, "°C", "°F");

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be(String.Empty);
            result.Value.ToString(2).Should().Be("32 °F");
        }
    }
}
