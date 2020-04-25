using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    internal class UnitRepository
    {
        internal List<Unit> LoadUnitsByQuantity(string quantity)
        {
            return DataRepository.GetUnitsByQuantity(quantity);
        }

        internal Unit LoadUnitByFullName(string v)
        {
            return DataRepository.GetUnitByFullName(v);
        }

        internal Unit LoadUnitBySymbol(string v)
        {
            return DataRepository.GetUnitBySymbol(v);
        }
    }
}
