using System;
using System.Collections.ObjectModel;

namespace UnitConverter.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Quantities = new ObservableCollection<string>();
            Quantities.Add("Temperature");
            Quantities.Add("Pressure");
            SelectedQuantity = "Temperature";
            SourceUnits = new ObservableCollection<string>();
            SourceUnits.Add("Celsius");
            SourceUnits.Add("Fahrenheit");
            SourceUnits.Add("Kelvin");
            SourceUnits.Add("Rankine");
            DestinationUnits = new ObservableCollection<string>();
            DestinationUnits.Add("Celsius");
            DestinationUnits.Add("Fahrenheit");
            DestinationUnits.Add("Kelvin");
            DestinationUnits.Add("Rankine");
            SourceValue = "0 °C";
            DestinationValue = "0 °C";
        }

        public ObservableCollection<string> Quantities { set; get; }
        public string SelectedQuantity { set; get; }
        public ObservableCollection<string> SourceUnits { set; get; }
        public ObservableCollection<string> DestinationUnits { set; get; }
        public string SourceValue { set; get; }
        public string DestinationValue { set; get; }
    }
}
