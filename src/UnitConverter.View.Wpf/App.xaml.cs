using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UnitConverter.ViewModel;

namespace UnitConverter.View.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            System.Windows.FrameworkCompatibilityPreferences
              .KeepTextBoxDisplaySynchronizedWithTextProperty = false;

            ILoadQuantitiesService loadQuantitiesService = new LoadQuantitiesService();
            ILoadUnitsService loadUnitsService = new LoadUnitsService();
            IUnitConverterService unitConverterService = new UnitConverterService();
            MainViewModel mainViewModel = new MainViewModel(loadQuantitiesService, loadUnitsService, unitConverterService);
            MainWindow window = new MainWindow();
            window.MainViewModel = mainViewModel;
            window.Show();
        }       
    }
}
