using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    internal static class ExtensionMethods
    {
        internal static bool BelongsToSameQuantityOf(this Unit unit, Unit otherUnit)
        {
            return unit.Quantity == otherUnit.Quantity;
        }
    }
}
