using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests.Model
{
    public class PressureUnitsTests
    {
        [Fact]
        public void Check_If_Pascal_Is_Corrected_Created()
        {
            //Arrange
            Pascal sut = new Pascal();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("Pascal");
            sut.Symbol.Should().Be("Pa");
            sut.Quantity.Should().Be("Pressure");
            sut.Point1.Should().Be(0.0);
            sut.Point2.Should().Be(1.0);
        }

        [Fact]
        public void Check_If_Psi_Is_Corrected_Created()
        {
            //Arrange
            Psi sut = new Psi();

            //Act

            //Assert
            sut.Should().BeAssignableTo<Unit>();
            sut.FullName.Should().Be("psi");
            sut.Symbol.Should().Be("psi");
            sut.Quantity.Should().Be("Pressure");
            sut.Point1.Should().Be(0.0);
            sut.Point2.Should().BeApproximately(1 / 6.894757e3, 1e-7);
        }
    }
}
