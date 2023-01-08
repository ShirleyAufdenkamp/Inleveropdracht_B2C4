using Inleveropdracht_B2C4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inleveropdracht_B2C4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Weather : ContentPage
    {
        public Weather()
        {
            InitializeComponent();
            this.BindingContext = new WeatherViewModel();
        }
    }
}