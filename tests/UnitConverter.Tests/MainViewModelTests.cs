using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using UnitConverter.ViewModel;
using Moq;

namespace UnitConverter.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void Ìnitial_state_of_view()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns(Task.FromResult((true, string.Empty, new List<string>() { "Temperature", "Pressure" })));           
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits("Temperature"))
                .Returns(Task.FromResult((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() })));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult((true, string.Empty, new Value(0, "°C"))));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);

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
