using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public static class ExtensionMethods
    {
        public static bool BelongsToSameQuantityOf(this Unit unit, Unit otherUnit)
        {
            return unit.Quantity == otherUnit.Quantity;
        }
    }
}
