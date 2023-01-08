using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inleveropdracht_B2C4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inleveropdracht_B2C4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteDrink : ContentPage
    {
        public DeleteDrink()
        {
            InitializeComponent();
        }

        private async void Cl_Delete(object sender, EventArgs e)
        {
            Data test = new Data();
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            string delete = En_DeDrink.Text;

            try
            {
                connection.Delete(delete);
                await DisplayAlert("Drank", "Drank " + delete + " is verwijderd.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Drank", "Drank kon niet verwijderd worden.", "OK");
            }

            connection.Close();
        }
    }
}