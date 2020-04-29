using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IUnitConverterService
    {
        (bool Success, string Message, Value Value) ConvertUnit(double value, string source, string destination);
    }
}
