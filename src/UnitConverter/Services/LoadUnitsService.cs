using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LoadUnitsService : ILoadUnitsService
    {
        public (bool Success, string Message, List<Unit> Units) LoadUnits(string quantity)
        {
            return (true, string.Empty, DataRepository.GetUnitsByQuantity(quantity));
        }
    }
}
