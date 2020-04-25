using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LoadUnitsService
    {
        public Task<(bool Success, string Message, List<string> Units)> LoadUnits(string quantity)
        {
            return Task.FromResult((true, string.Empty, DataRepository.GetUnitsByQuantity(quantity).Select(u => u.FullName).ToList()));
        }
    }
}
