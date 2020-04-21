using FluentAssertions;
using Xunit;

namespace UnitConverter.Tests
{
    public class ExtensionMethodsTests
    {
        [Fact]
        public void Test_equality_of_two_units()
        {
            //Arrange
            Unit unit1 = new Celsius();
            Unit unit2 = new Celsius();

            //Act

            //Assert
            unit1.Equals(unit2).Should().BeTrue();
        }

        [Fact]
        public void Test_inequality_of_two_units()
        {
            //Arrange
            Unit unit1 = new Celsius();
            Unit unit2 = new Fahrenheit();

            //Act

            //Assert
            unit1.Equals(unit2).Should().BeFalse();
        }

        [Fact]
        public void Test_if_the_quantity_of_two_units_are_the_same()
        {
            //Arrange
            Unit unit1 = new Celsius();
            Unit unit2 = new Fahrenheit();

            //Act

            //Assert
            unit1.BelongsToSameQuantityOf(unit2).Should().BeTrue();
        }

        [Fact]
        public void Test_if_the_quantity_of_two_units_are_not_the_same()
        {
            //Arrange
            Unit unit1 = new Celsius();
            Unit unit2 = new Pascal();

            //Act

            //Assert
            unit1.BelongsToSameQuantityOf(unit2).Should().BeFalse();
        }
    }
}
