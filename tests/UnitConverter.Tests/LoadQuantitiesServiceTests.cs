using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace UnitConverter.Tests
{
  
    public class LoadQuantitiesServiceTests
    {
        [Fact]
        public void Load_quantities()
        {
            //Arrange
            LoadQuantitiesService sut = new LoadQuantitiesService();

            //Act
            var result = sut.LoadQuantities();

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be(string.Empty);
            result.Quantities.Should().HaveCount(2);
            result.Quantities.Should().Contain("Temperature");
            result.Quantities.Should().Contain("Pressure");
        }
    }
}
