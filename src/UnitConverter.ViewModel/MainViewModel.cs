using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitConverter.ViewModel
{
    public class MainViewModel
    {
        private readonly ILoadQuantitiesService loadQuantitiesService;
        private readonly ILoadUnitsService loadUnitsService;
        private readonly IUnitConverterService unitConverterService;

        public MainViewModel(ILoadQuantitiesService loadQuantitiesService, 
            ILoadUnitsService loadUnitsService, IUnitConverterService unitConverterService)
        {
            this.loadQuantitiesService = loadQuantitiesService;
            this.loadUnitsService = loadUnitsService;
            this.unitConverterService = unitConverterService;
            InitializeMainViewModel();
        }

        private async void InitializeMainViewModel()
        {
            Quantities = new ObservableCollection<string>((await loadQuantitiesService.LoadQuantities()).Quantities);
            SelectedQuantity = Quantities.FirstOrDefault();
            SourceUnits = new ObservableCollection<Unit>((await loadUnitsService.LoadUnits(SelectedQuantity)).Units);
            DestinationUnits = new ObservableCollection<Unit>((await loadUnitsService.LoadUnits(SelectedQuantity)).Units);
            SelectedSourceUnit = SourceUnits.FirstOrDefault();
            SelectedDestinationUnit = DestinationUnits.FirstOrDefault();
            SourceValue = new Value(0, SelectedSourceUnit.FullName);
            DestinationValue = (await unitConverterService.ConvertUnit(SourceValue.Amount, 
                SelectedSourceUnit.FullName, SelectedDestinationUnit.FullName)).Value;
        }

        public ObservableCollection<string> Quantities { set; get; }
        public string SelectedQuantity { set; get; }
        public ObservableCollection<Unit> SourceUnits { set; get; }
        public ObservableCollection<Unit> DestinationUnits { set; get; }
        public Unit SelectedSourceUnit { get; set; }
        public Unit SelectedDestinationUnit { get; set; }
        public Value SourceValue { set; get; }
        public Value DestinationValue { set; get; }
    }
}
