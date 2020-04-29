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
            LoadArguments(double.Parse(aux[0].Replace(',', '.'), CultureInfo.InvariantCulture), aux[1]);
        }

        public Value(double amount) 
            : this(amount, string.Empty)
        {
        }
        
        public Value(double amount, string symbol)
        {
            LoadArguments(amount, symbol);
        }

        private void LoadArguments(double amount, string symbolOrFullName)
        {
            Amount = amount;
            Unit = DataRepository.GetUnitByFullName(symbolOrFullName);
            if (Unit != null) return;
            Unit = DataRepository.GetUnitBySymbol(symbolOrFullName);
        }

        public double Amount { get; private set; }
        internal Unit Unit { get; set; }

        public string ToString(int significantFigures)
        {
            return $"{Amount.ToString(significantFigures)} {Unit.Symbol}".TrimEnd();
        }

        public override bool Equals(object obj)
        {
            return (((Value)obj).Amount == this.Amount) &&
                   (((Value)obj).Unit.Symbol == this.Unit.Symbol);
                   
        }
    }
}
