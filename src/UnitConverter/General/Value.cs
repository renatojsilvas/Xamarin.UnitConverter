using Math.Rounding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UnitConverter
{
    public class Value
    {
        public Value(string value)
        {
            var aux = value.Split(' ');
            LoadArguments(double.Parse(aux[0], CultureInfo.InvariantCulture), aux[1]);
        }

        public Value(double amount) 
            : this(amount, string.Empty)
        {
        }
        
        public Value(double amount, string symbol)
        {
            LoadArguments(amount, symbol);
        }

        private void LoadArguments(double amount, string symbol)
        {
            Amount = amount;
            Unit = DataRepository.GetUnitByFullName(symbol);
            if (Unit != null) return;
            Unit = DataRepository.GetUnitBySymbol(symbol);
        }

        public double Amount { get; private set; }
        private Unit Unit { get; set; }

        public string ToString(int significantFigures)
        {
            return $"{Amount.ToString(significantFigures)} {Unit.Symbol}".TrimEnd();
        }
    }
}
