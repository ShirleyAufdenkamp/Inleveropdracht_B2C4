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
    public partial class ChangeDrink : ContentPage
    {
        public ChangeDrink()
        {
            InitializeComponent();
        }
        private async void Cl_Change(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            SQLiteCommand command = new SQLiteCommand(connection);


            string nieuw = En_NwDrink.Text;
            string old = En_Drink.Text;
            command.CommandText = "UPDATE Data SET Drink = '" + nieuw + "' WHERE Drink = '" + old + "';";

            try
            {
                command.ExecuteNonQuery();
                await DisplayAlert("Drank", "Drank " + old + " is gewijzigd naar " + nieuw + ".", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Drank", "Drank is niet gewijzigd.", "OK");
            }
            connection.Close();
        }
    }
}