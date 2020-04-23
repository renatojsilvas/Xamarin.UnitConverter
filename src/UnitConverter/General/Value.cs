using Math.Rounding;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Value
    {
        public Value(double amount, Unit unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public Value(double amount) 
            : this(amount, string.Empty)
        {
        }
        
        public Value(double amount, string symbol)
        {
            Amount = amount;
            Unit = DataRepository.GetUnitByFullName(symbol);
            if (Unit != null) return;
            Unit = DataRepository.GetUnitBySymbol(symbol);
        }

        public double Amount { get; }
        public Unit Unit { get; }

        public string ToString(int significantFigures)
        {
            return $"{Amount.ToString(significantFigures)} {Unit.Symbol}".TrimEnd();
        }
    }
}
