using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using UnitConverter.ViewModel;

namespace UnitConverter.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void Ìnitial_state_of_view()
        {
            //Arrange
            MainViewModel sut = new MainViewModel();

            //Act

            //Assert
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Temperature");
            sut.SourceUnits.Should().HaveCount(4);
            sut.SourceUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.DestinationUnits.Should().HaveCount(4);
            sut.DestinationUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.SourceValue.Should().Be(new Value("0 °C"));
            sut.DestinationValue.Should().Be(new Value("0 °C"));
        }
    }
}
