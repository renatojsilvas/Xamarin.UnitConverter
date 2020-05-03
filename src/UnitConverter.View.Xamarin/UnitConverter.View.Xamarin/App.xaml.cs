using System;
using UnitConverter.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnitConverter.View.Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ILoadQuantitiesService loadQuantitiesService = new LoadQuantitiesService();
            ILoadUnitsService loadUnitsService = new LoadUnitsService();
            IUnitConverterService unitConverterService = new UnitConverterService();
            MainViewModel mainViewModel = new MainViewModel(loadQuantitiesService, loadUnitsService, unitConverterService);
            MainPage = new MainPage()
            {
                MainViewModel = mainViewModel
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
