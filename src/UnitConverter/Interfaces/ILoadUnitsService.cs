using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface ILoadUnitsService
    {
        Task<(bool Success, string Message, List<Unit> Units)> LoadUnits(string quantity);
    }
}
