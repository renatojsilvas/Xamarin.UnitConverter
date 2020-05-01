using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace UnitConverter.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Load_unit_by_full_name()
        {
            //Arrange
            UnitRepository sut = new UnitRepository();

            //Act
            Unit unit = sut.LoadUnitByFullName("Kelvin");

            //Assert
            unit.Should().BeAssignableTo<Kelvin>();
        }

        [Fact]
        public void Load_unit_by_symbol()
        {
            //Arrange
            UnitRepository sut = new UnitRepository();

            //Act
            Unit unit = sut.LoadUnitBySymbol("Ra");

            //Assert
            unit.Should().BeAssignableTo<Rankine>();
        }

        [Fact]
        public void Load_all_quantities()
        {
            //Arrange
            QuantityRepository sut = new QuantityRepository();

            //Act
            List<string> quantities = sut.LoadQuantities();

            //Assert
            quantities.Should().HaveCount(2);
            quantities.Should().Contain("Temperature");
            quantities.Should().Contain("Pressure");
        }

        [Fact]
        public void Load_temperature_units()
        {
            //Arrange
            UnitRepository sut = new UnitRepository();

            //Act
            List<Unit> units = sut.LoadUnitsByQuantity("Temperature");

            //Assert
            units.Should().HaveCount(4);
            units.Should().AllBeAssignableTo<Unit>();
            units.Should().Contain(u => u.FullName == "Celsius");
            units.Should().Contain(u => u.FullName == "Fahrenheit");
            units.Should().Contain(u => u.FullName == "Kelvin");
            units.Should().Contain(u => u.FullName == "Rankine");
        }

        [Fact]
        public void Load_pressure_units()
        {
            //Arrange
            UnitRepository sut = new UnitRepository();

            //Act
            List<Unit> units = sut.LoadUnitsByQuantity("Pressure");

            //Assert
            units.Should().HaveCount(2);
            units.Should().AllBeAssignableTo<Unit>();
            units.Should().Contain(u => u.FullName == "Pascal");
            units.Should().Contain(u => u.FullName == "psi");
        }
    }
}
