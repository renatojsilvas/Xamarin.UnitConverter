﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Pressure;
using UnitConverter.ViewModel;
using Xunit;
using FluentAssertions;

namespace UnitConverter.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Change_quantity_and_destination_unit_and_source_value()
        {
            //Arrange
            LoadQuantitiesService loadQuantitiesService = new LoadQuantitiesService();
            LoadUnitsService loadUnitsService = new LoadUnitsService();
            UnitConverterService unitConverterService = new UnitConverterService();
            MainViewModel mainViewModel = new MainViewModel(loadQuantitiesService, loadUnitsService, unitConverterService);

            //Act
            mainViewModel.SelectedQuantity = "Pressure";
            mainViewModel.SelectedDestinationUnit = new Psi();
            mainViewModel.SourceValue = new Value(100, "Pa");

            //Assert
            mainViewModel.Quantities.Should().HaveCount(2);
            mainViewModel.Quantities.Should().ContainInOrder("Temperature", "Pressure");
            mainViewModel.SelectedQuantity.Should().Be("Pressure");
            mainViewModel.SourceUnits.Should().HaveCount(2);
            mainViewModel.SourceUnits.Should().ContainInOrder(new Pascal(), new Psi());
            mainViewModel.DestinationUnits.Should().HaveCount(2);
            mainViewModel.DestinationUnits.Should().ContainInOrder(new Pascal(), new Psi());
            mainViewModel.SelectedSourceUnit.Should().Be(new Pascal());
            mainViewModel.SelectedDestinationUnit.Should().Be(new Psi());
            mainViewModel.SourceValue.Should().Be(new Value("100 Pa"));
            mainViewModel.DestinationValue.Amount.Should().BeApproximately(new Value("0,01450377 Pa").Amount, 1e-8);
            mainViewModel.DestinationValue.Unit.Symbol.Should().Be("psi"); 
        }
    }
}
