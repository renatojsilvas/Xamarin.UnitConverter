using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests
{
    public class LoadUnitsServiceTest
    {
        [Fact]
        public void Load_units_by_quantity()
        {
            //Arrange
            LoadUnitsService sut = new LoadUnitsService();

            //Act
            var result = sut.LoadUnits("Temperature");

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be(string.Empty);
            result.Units.Should().HaveCount(4);
            result.Units.Should().AllBeAssignableTo<Unit>();
            result.Units.Should().Contain(u => u.FullName == "Celsius");
            result.Units.Should().Contain(u => u.FullName == "Fahrenheit");
            result.Units.Should().Contain(u => u.FullName == "Kelvin");
            result.Units.Should().Contain(u => u.FullName == "Rankine");
        }
    }
}
