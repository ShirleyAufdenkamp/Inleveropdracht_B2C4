using Inleveropdracht_B2C4.Services;
using Inleveropdracht_B2C4.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inleveropdracht_B2C4
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App(string databaseLocation)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DatabaseLocation = databaseLocation;
            MainPage = new LoginPage();
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
