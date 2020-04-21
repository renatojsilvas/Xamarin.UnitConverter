using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class QuantityRepository
    {
        public List<string> LoadQuantities()
        {
            return DataRepository.GetQuantities();
        }
    }
}
