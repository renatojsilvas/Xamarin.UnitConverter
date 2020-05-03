using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.ViewModel;
using Xamarin.Forms;

namespace UnitConverter.View.Xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainViewModel MainViewModel
        {
            set
            {
                this.BindingContext = value;
            }
        }
    }
}
