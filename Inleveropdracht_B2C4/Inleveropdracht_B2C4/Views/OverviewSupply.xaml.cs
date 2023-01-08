using Inleveropdracht_B2C4.Models;
using SQLite;
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
    public partial class OverviewSupply : ContentPage
    {
        public OverviewSupply()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<Data>();
            var databaseData = connection.Table<Data>().ToList();
            foreach (Data data in databaseData)
            {
                if (data.Image == "")
                {
                    continue;
                }
                data.Picture = data.Image.Substring(6);
            }
            DataListView.ItemsSource = databaseData;
            connection.Close();
        }
    }
}