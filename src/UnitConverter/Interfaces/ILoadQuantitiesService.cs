using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface ILoadQuantitiesService
    {
        (bool Success, string Message, List<string> Quantities) LoadQuantities();
    }
}
