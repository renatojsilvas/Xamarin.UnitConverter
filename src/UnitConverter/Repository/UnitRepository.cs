using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class UnitRepository
    {
        public List<Unit> LoadUnitsByQuantity(string quantity)
        {
            return DataRepository.GetUnitsByQuantity(quantity);
        }

        public Unit LoadUnitByFullName(string v)
        {
            return DataRepository.GetUnitByFullName(v);
        }

        public Unit LoadUnitBySymbol(string v)
        {
            return DataRepository.GetUnitBySymbol(v);
        }
    }
}
