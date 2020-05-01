using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitConverter
{
    internal class DataRepository
    {
        private static List<Unit> listOfUnits = null;

        private static void InitializeRepository()
        {
            if (listOfUnits != null) return;

            listOfUnits = new List<Unit>
            {
                //Temperature
                new Celsius(),
                new Fahrenheit(),
                new Kelvin(),
                new Rankine(),

                //Pressure
                new Pascal(),
                new Psi(),
            };
        }        

        internal static List<string> GetQuantities()
        {
            InitializeRepository();
            return listOfUnits.Select(u => u.Quantity).Distinct().ToList();
        }

        internal static List<Unit> GetUnitsByQuantity(string quantity)
        {
            InitializeRepository();
            return listOfUnits.Where(u => u.Quantity == quantity).ToList();
        }

        internal static Unit GetUnitByFullName(string fullName)
        {
            InitializeRepository();
            return listOfUnits.FirstOrDefault(u => u.FullName == fullName);
        }

        internal static Unit GetUnitBySymbol(string symbol)
        {
            InitializeRepository();
            return listOfUnits.FirstOrDefault(u => u.Symbol == symbol);
        }
    }
}
