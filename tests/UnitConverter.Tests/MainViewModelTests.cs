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
            LoadQuantitiesService loadQuantitiesService = new LoadQuantitiesService();
            LoadUnitsService loadUnitsService = new LoadUnitsService();
            UnitConverterService unitConverterService = new UnitConverterService();
            MainViewModel sut = new MainViewModel(loadQuantitiesService, loadUnitsService, unitConverterService);

            //Act

            //Assert
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Temperature");
            sut.SourceUnits.Should().HaveCount(4);
            sut.SourceUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.DestinationUnits.Should().HaveCount(4);
            sut.DestinationUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.SelectedSourceUnit.Should().Be(new Celsius());
            sut.SelectedDestinationUnit.Should().Be(new Celsius());
            sut.SourceValue.Should().Be(new Value("0 °C"));
            sut.DestinationValue.Should().Be(new Value("0 °C"));
        }
    }
}
