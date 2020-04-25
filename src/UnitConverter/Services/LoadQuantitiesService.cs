using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LoadQuantitiesService
    {
        public Task<(bool Success, string Message, List<string> Quantities)> LoadQuantities()
        {
            return Task.FromResult((true, string.Empty, DataRepository.GetQuantities()));
        }
    }
}
