using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitConverter.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            InitializeMainViewModel();
        }

        private async void InitializeMainViewModel()
        {
            LoadUnitsService loadUnitsService = new LoadUnitsService();
            Quantities = new ObservableCollection<string>();
            Quantities.Add("Temperature");
            Quantities.Add("Pressure");
            SelectedQuantity = "Temperature";
            SourceUnits = new ObservableCollection<Unit>();
            SourceUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Celsius"));
            SourceUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Fahrenheit"));
            SourceUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Kelvin"));
            SourceUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Rankine"));
            DestinationUnits = new ObservableCollection<Unit>();
            DestinationUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Celsius"));
            DestinationUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Fahrenheit"));
            DestinationUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Kelvin"));
            DestinationUnits.Add((await loadUnitsService.LoadUnits("Temperature")).Units.FirstOrDefault(u => u.FullName == "Rankine"));
            SourceValue = new Value("0 °C");
            DestinationValue = new Value("0 °C");
        }

        public ObservableCollection<string> Quantities { set; get; }
        public string SelectedQuantity { set; get; }
        public ObservableCollection<Unit> SourceUnits { set; get; }
        public ObservableCollection<Unit> DestinationUnits { set; get; }
        public Value SourceValue { set; get; }
        public Value DestinationValue { set; get; }
    }
}
