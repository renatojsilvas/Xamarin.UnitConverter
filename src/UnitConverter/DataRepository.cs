using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitConverter
{
    public class DataRepository
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
            };
        }        

        public static List<string> GetQuantities()
        {
            InitializeRepository();
            return listOfUnits.Select(u => u.Quantity).Distinct().ToList();
        }

        public static List<Unit> GetUnitsByQuantity(string v)
        {
            InitializeRepository();
            return listOfUnits.Where(u => u.Quantity == v).ToList();
        }

        public static Unit GetUnitByFullName(string fullName)
        {
            InitializeRepository();
            return listOfUnits.FirstOrDefault(u => u.FullName == fullName);
        }

        public static Unit GetUnitBySymbol(string symbol)
        {
            InitializeRepository();
            return listOfUnits.FirstOrDefault(u => u.Symbol == symbol);
        }
    }
}
