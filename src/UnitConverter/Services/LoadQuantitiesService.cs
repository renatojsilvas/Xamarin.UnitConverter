using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LoadQuantitiesService : ILoadQuantitiesService
    {
        public (bool Success, string Message, List<string> Quantities) LoadQuantities()
        {
            return (true, string.Empty, DataRepository.GetQuantities());
        }
    }
}
