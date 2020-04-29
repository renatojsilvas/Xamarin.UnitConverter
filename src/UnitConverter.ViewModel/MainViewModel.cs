using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConverter.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

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

        private void InitializeMainViewModel()
        {
            Quantities = new ObservableCollection<string>((loadQuantitiesService.LoadQuantities()).Quantities);
            SelectedQuantity = Quantities.FirstOrDefault();
            UpdateUnits(SelectedQuantity);
        }

        private void UpdateUnits(string selectedQuantity)
        {
            SourceUnits = new ObservableCollection<Unit>((loadUnitsService.LoadUnits(selectedQuantity)).Units);
            SelectedSourceUnit = SourceUnits.FirstOrDefault();
            SourceValue = new Value(0, SelectedSourceUnit.FullName);
            DestinationUnits = new ObservableCollection<Unit>((loadUnitsService.LoadUnits(selectedQuantity)).Units);
            SelectedDestinationUnit = DestinationUnits.FirstOrDefault();
            DestinationValue = (unitConverterService.ConvertUnit(SourceValue.Amount, SelectedSourceUnit.FullName,
                SelectedDestinationUnit.FullName)).Value;
        }

        public ObservableCollection<string> Quantities { set; get; }

        private string selectedQuantity;
        public string SelectedQuantity 
        {
            get
            {
                return selectedQuantity;
            }
            set
            {
                if (selectedQuantity != value)
                {
                    selectedQuantity = value;
                    UpdateUnits(selectedQuantity);
                    OnPropertyChanged(nameof(SelectedQuantity));
                }
            }             
        }        

        public ObservableCollection<Unit> SourceUnits { set; get; }
        public ObservableCollection<Unit> DestinationUnits { set; get; }

        private Unit selectedSourceUnit;
        public Unit SelectedSourceUnit
        {
            get
            {
                return selectedSourceUnit;
            }
            set
            {
                if (selectedSourceUnit != value)
                {
                    selectedSourceUnit = value;
                    if (SelectedDestinationUnit != null)
                       UpdateDestinationValue(selectedSourceUnit, SelectedDestinationUnit);
                    OnPropertyChanged(nameof(SelectedSourceUnit));
                }
            }
        }

        private void UpdateDestinationValue(Unit selectedSourceUnit, Unit selectedDestinationUnit)
        {
            SourceValue = new Value(SourceValue.Amount, selectedSourceUnit.FullName);
            DestinationValue = (unitConverterService.ConvertUnit(SourceValue.Amount, selectedSourceUnit.FullName,
                selectedDestinationUnit.FullName)).Value;
        }

        private Unit selectDestinationUnit;
        public Unit SelectedDestinationUnit
        {
            get
            {
                return selectDestinationUnit;
            }
            set
            {
                if (selectDestinationUnit != value)
                {
                    selectDestinationUnit = value;
                    if (SelectedSourceUnit != null)
                        UpdateDestinationValue(SelectedSourceUnit, selectDestinationUnit);
                    OnPropertyChanged(nameof(SelectedDestinationUnit));
                }
            }
        }

        private Value sourceValue;
        public Value SourceValue
        {
            get
            {
                return sourceValue;
            }
            set
            {
                if (sourceValue != value)
                {
                    sourceValue = value;
                    if (SelectedSourceUnit != null && SelectedDestinationUnit != null)
                        DestinationValue = unitConverterService.ConvertUnit(sourceValue.Amount, SelectedSourceUnit.FullName, SelectedDestinationUnit.FullName).Value;
                    OnPropertyChanged(nameof(SourceValue));
                }
            }
        }

        public Value DestinationValue { set; get; }
    }
}
