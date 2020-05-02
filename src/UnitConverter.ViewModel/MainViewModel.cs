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
            SourceUnits = new ObservableCollection<Unit>();
            DestinationUnits = new ObservableCollection<Unit>();
            Quantities = new ObservableCollection<string>((loadQuantitiesService.LoadQuantities()).Quantities);
            SelectedQuantity = Quantities.FirstOrDefault();            
            UpdateUnits(SelectedQuantity);
        }

        private void UpdateUnits(string selectedQuantity)
        {
            SourceUnits.Clear();
            foreach (var unit in (loadUnitsService.LoadUnits(selectedQuantity)).Units)
            {
                SourceUnits.Add(unit);
            }
            SelectedSourceUnit = SourceUnits.FirstOrDefault();
            SourceValue = 0;
            DestinationUnits.Clear();
            foreach (var unit in (loadUnitsService.LoadUnits(selectedQuantity)).Units)
            {
                DestinationUnits.Add(unit);
            }
            SelectedDestinationUnit = DestinationUnits.FirstOrDefault();
            DestinationValue = (unitConverterService.ConvertUnit(SourceValue, SelectedSourceUnit.FullName,
                SelectedDestinationUnit.FullName)).Value.Amount;
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
                    if (SelectedDestinationUnit != null && SelectedSourceUnit != null && SelectedDestinationUnit.Quantity == SelectedSourceUnit.Quantity)
                    {
                        SourceValue = new Value(SourceValue, SelectedSourceUnit.FullName).Amount;
                        DestinationValue = (unitConverterService.ConvertUnit(SourceValue, SelectedSourceUnit.FullName,
                            SelectedDestinationUnit.FullName)).Value.Amount;
                    }
                    OnPropertyChanged(nameof(SelectedSourceUnit));
                }
            }
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
                    if (SelectedDestinationUnit != null && SelectedSourceUnit != null)
                    {
                        SourceValue = new Value(SourceValue, SelectedSourceUnit.FullName).Amount;
                        DestinationValue = (unitConverterService.ConvertUnit(SourceValue, SelectedSourceUnit.FullName,
                            SelectedDestinationUnit.FullName)).Value.Amount;
                    }
                    OnPropertyChanged(nameof(SelectedDestinationUnit));
                }
            }
        }

        private double sourceValue;
        public double SourceValue
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
                        DestinationValue = unitConverterService.ConvertUnit(sourceValue, SelectedSourceUnit.FullName, SelectedDestinationUnit.FullName).Value.Amount;
                    OnPropertyChanged(nameof(SourceValue));
                }
            }
        }

        private double destinationValue;
        public double DestinationValue
        {
            get
            {
                return destinationValue;
            }
            set
            {
                if (destinationValue != value)
                {
                    destinationValue = value;
                    OnPropertyChanged(nameof(DestinationValue));
                }
            }
        }
    }
}
