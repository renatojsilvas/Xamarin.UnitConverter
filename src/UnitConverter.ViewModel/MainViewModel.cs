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

        private async void InitializeMainViewModel()
        {
            Quantities = new ObservableCollection<string>((await loadQuantitiesService.LoadQuantities()).Quantities);
            SelectedQuantity = Quantities.FirstOrDefault();
            await UpdateUnits(SelectedQuantity);
        }

        private async Task UpdateUnits(string selectedQuantity)
        {
            SourceUnits = new ObservableCollection<Unit>((await loadUnitsService.LoadUnits(selectedQuantity)).Units);
            SelectedSourceUnit = SourceUnits.FirstOrDefault();
            SourceValue = new Value(0, SelectedSourceUnit.FullName);
            DestinationUnits = new ObservableCollection<Unit>((await loadUnitsService.LoadUnits(selectedQuantity)).Units);
            SelectedDestinationUnit = DestinationUnits.FirstOrDefault();
            DestinationValue = (await unitConverterService.ConvertUnit(SourceValue.Amount, SelectedSourceUnit.FullName,
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
                    _ = UpdateUnits(selectedQuantity);
                    OnPropertyChanged(nameof(SelectedQuantity));
                }
            }             
        }        

        public ObservableCollection<Unit> SourceUnits { set; get; }
        public ObservableCollection<Unit> DestinationUnits { set; get; }
        
        public Unit SelectedSourceUnit { get; set; }
        public Unit SelectedDestinationUnit { get; set; }
        public Value SourceValue { set; get; }
        public Value DestinationValue { set; get; }
    }
}
