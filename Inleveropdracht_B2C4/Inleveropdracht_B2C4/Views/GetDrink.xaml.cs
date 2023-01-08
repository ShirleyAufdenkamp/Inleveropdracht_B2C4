using Inleveropdracht_B2C4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inleveropdracht_B2C4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetDrink : ContentPage
    {
        public ObservableCollection<Data> drinks;
        public GetDrink()
        {
            InitializeComponent();
            drinks = new ObservableCollection<Data>();
            BindingContext = drinks;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<Data>();
            var databaseData = connection.Table<Data>().ToList();
            foreach (Data data in databaseData)
            {
                if (data.Count == 0) //This is because stepper can't have maximum if count is 0. And it wouldn't make sence to show a drink to grab if there is none.
                {
                    continue;
                }
                else
                {
                    if (data.Image == "")
                    {
                        data.Picture = "";
                    }
                    else
                    {
                        data.Picture = data.Image.Substring(6);
                    }
                    drinks.Add(data);
                }
            }
            DataListViewDrinks.ItemsSource = drinks;
            connection.Close();
        }

        public async void Cl_Get(object sender, EventArgs e)
        {
            int _counter = new int();
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<Data>();

            //var dataListViewData = DataListViewDrinks.ItemsSource.Cast<Data>();

            foreach (var item in drinks)
            {
                var drinkName = item.Drink;
                var drinkCount = item.Count;


                Data databaseRecord = connection.FindWithQuery<Data>("SELECT * FROM Data WHERE Drink = '" + drinkName + "'");
                var newDrinkCount = databaseRecord.Count - drinkCount;

                connection.Query<Data>("Update Data Set Count = ' " + newDrinkCount + "' WHERE Drink ='" + drinkName + "'");
                _counter++;
            }

            if (_counter > 0)
            {
                await DisplayAlert("Drink", "Alle dranken zijn geupdate.", "OK");
            }
            else
            {
                await DisplayAlert("Drink", "Dranken konden niet worden geupdate.", "OK");
            }
            connection.Close();
        }
    }
}