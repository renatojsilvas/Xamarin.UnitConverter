using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitConverterService
    {
        public Task<ServiceResult> ConvertUnit(double value, string source, string destination)
        {
            Unit sourceUnit = SelectUnit(source);
            Unit destinationUnit = SelectUnit(destination);
            UnitsConverter unitsConverter = new UnitsConverter(sourceUnit, destinationUnit);
            double convertedValue = unitsConverter.Convert(value);
            ServiceResult result = new ServiceResult(true, string.Empty, new Value(convertedValue, destinationUnit.Symbol));
            return Task.FromResult(result);
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
