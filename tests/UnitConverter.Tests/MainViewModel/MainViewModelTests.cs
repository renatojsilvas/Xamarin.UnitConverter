﻿using System;
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
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));           
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.IsAny<string>()))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((true, string.Empty, new Value(0, "°C")));
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
            sut.SourceValue.Should().Be(0);
            sut.DestinationValue.Should().Be(0);
        }

        [Fact]
        public void Change_quantity()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Temperature")))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Pressure")))
                .Returns((true, string.Empty, new List<Unit>() { new Pascal() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0), 
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(0, "°C")));
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Pascal"), It.Is<string>(i => i == "Pascal")))
                .Returns((true, string.Empty, new Value(0, "Pa")));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);
            string property = string.Empty;
            sut.PropertyChanged += (sender, e) =>
            {
                property = e.PropertyName;
            };

            //Act
            sut.SelectedQuantity = "Pressure";

            //Assert
            property.Should().Be("SelectedQuantity");
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Pressure");
            sut.SourceUnits.Should().HaveCount(1);
            sut.SourceUnits.Should().ContainInOrder(new Pascal());
            sut.DestinationUnits.Should().HaveCount(1);
            sut.DestinationUnits.Should().ContainInOrder(new Pascal());
            sut.SelectedSourceUnit.Should().Be(new Pascal());
            sut.SelectedDestinationUnit.Should().Be(new Pascal());
            sut.SourceValue.Should().Be(0);
            sut.DestinationValue.Should().Be(0);
        }

        [Fact]
        public void Change_source_unit()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Temperature")))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(0, "°C")));
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Fahrenheit"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(-17.778, "°C")));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);
            string property = string.Empty;
            sut.PropertyChanged += (sender, e) =>
            {
                property = e.PropertyName;
            };

            //Act
            sut.SelectedSourceUnit = new Fahrenheit();

            //Assert
            property.Should().Be("SelectedSourceUnit");
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Temperature");
            sut.SourceUnits.Should().HaveCount(4);
            sut.SourceUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.DestinationUnits.Should().HaveCount(4);
            sut.DestinationUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.SelectedSourceUnit.Should().Be(new Fahrenheit());
            sut.SelectedDestinationUnit.Should().Be(new Celsius());
            sut.SourceValue.Should().Be(0);
            sut.DestinationValue.Should().Be(-17.778);
        }

        [Fact]
        public void Change_destination_unit()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Temperature")))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(0, "°C")));
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Fahrenheit")))
                .Returns((true, string.Empty, new Value(32, "°F")));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);
            string property = string.Empty;
            sut.PropertyChanged += (sender, e) =>
            {
                property = e.PropertyName;
            };

            //Act
            sut.SelectedDestinationUnit = new Fahrenheit();

            //Assert
            property.Should().Be("SelectedDestinationUnit");
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Temperature");
            sut.SourceUnits.Should().HaveCount(4);
            sut.SourceUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.DestinationUnits.Should().HaveCount(4);
            sut.DestinationUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.SelectedSourceUnit.Should().Be(new Celsius());
            sut.SelectedDestinationUnit.Should().Be(new Fahrenheit());
            sut.SourceValue.Should().Be(0);
            sut.DestinationValue.Should().Be(32);
        }

        [Fact]
        public void Change_source_value()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Temperature")))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(0, "°C")));
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 20),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(20, "°C")));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);
            string property = string.Empty;
            sut.PropertyChanged += (sender, e) =>
            {
                property = e.PropertyName;
            };

            //Act
            sut.SourceValue = 20;

            //Assert
            property.Should().Be("SourceValue");
            sut.Quantities.Should().HaveCount(2);
            sut.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            sut.SelectedQuantity.Should().Be("Temperature");
            sut.SourceUnits.Should().HaveCount(4);
            sut.SourceUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.DestinationUnits.Should().HaveCount(4);
            sut.DestinationUnits.Should().ContainInOrder(new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine());
            sut.SelectedSourceUnit.Should().Be(new Celsius());
            sut.SelectedDestinationUnit.Should().Be(new Celsius());
            sut.SourceValue.Should().Be(20);
            sut.DestinationValue.Should().Be(20);
        }

        [Fact]
        public void Change_destination_value()
        {
            //Arrange
            var loadQuantitiesServiceMock = new Mock<ILoadQuantitiesService>();
            loadQuantitiesServiceMock.Setup(f => f.LoadQuantities())
                .Returns((true, string.Empty, new List<string>() { "Temperature", "Pressure" }));
            var loadUnitsServiceMock = new Mock<ILoadUnitsService>();
            loadUnitsServiceMock.Setup(f => f.LoadUnits(It.Is<string>(i => i == "Temperature")))
                .Returns((true, string.Empty, new List<Unit>() { new Celsius(), new Fahrenheit(), new Kelvin(), new Rankine() }));
            var unitConverterServiceMock = new Mock<IUnitConverterService>();
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 0),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(0, "°C")));
            unitConverterServiceMock.Setup(f => f.ConvertUnit(It.Is<double>(i => i == 20),
                It.Is<string>(i => i == "Celsius"), It.Is<string>(i => i == "Celsius")))
                .Returns((true, string.Empty, new Value(20, "°C")));
            MainViewModel sut = new MainViewModel(loadQuantitiesServiceMock.Object, loadUnitsServiceMock.Object, unitConverterServiceMock.Object);
            string property = string.Empty;
            sut.PropertyChanged += (sender, e) =>
            {
                property = e.PropertyName;
            };

            //Act
            sut.DestinationValue = 20;

            //Assert
            property.Should().Be("DestinationValue");
        }
    }
}
