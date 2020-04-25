using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitConverterService
    {
        public Task<(bool Success, string Message, Value Value)> ConvertUnit(double value, string source, string destination)
        {
            Unit sourceUnit = SelectUnit(source);
            Unit destinationUnit = SelectUnit(destination);
            UnitsConverter unitsConverter = new UnitsConverter(sourceUnit, destinationUnit);
            double convertedValue = unitsConverter.Convert(value);
            return Task.FromResult((true, string.Empty, new Value(convertedValue, destinationUnit.Symbol)));
        }

        private Unit SelectUnit(string unit)
        {
            Unit sourceUnit = DataRepository.GetUnitByFullName(unit);
            if (sourceUnit == null) 
                sourceUnit = DataRepository.GetUnitBySymbol(unit);
            return sourceUnit;
        }
    }
}
