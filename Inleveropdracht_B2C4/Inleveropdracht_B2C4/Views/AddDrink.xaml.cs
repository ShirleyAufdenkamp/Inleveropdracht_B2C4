using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Inleveropdracht_B2C4.Models;

namespace Inleveropdracht_B2C4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDrink : ContentPage
    {
        private string PhotoPath;
        public AddDrink()
        {
            InitializeComponent();
        }

        private async void Cl_AddAsync(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Drink = En_Drink.Text;
            if (PhotoImage.Source == null)//This makes it so that someone can add drink without picture.
            {
                data.Image = string.Empty;
            }
            else
            {
                data.Image = PhotoImage.Source.ToString();
            }
            data.Count = 0;
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<Data>();
            int InsertRows = connection.Insert(data);
            if (InsertRows > 0)
            {
                await DisplayAlert("Drank", "Drank is toegevoegd.", "OK");
            }
            else
            {
                await DisplayAlert("Drank", "Drank is niet toegevoegd.", "OK");
            }
            connection.Close();
        }

        public async void Cl_Camera(object sender, EventArgs e)
        {
            //https://thedavidmasters.com/2020/11/19/how-do-you-take-pictures-with-xamarin-forms/
            await TakePhotoAsync();

            async Task TakePhotoAsync()
            {
                try
                {
                    var mpo = new MediaPickerOptions()
                    {
                        Title = "Hello"
                    };

                    var photo = await MediaPicker.CapturePhotoAsync();
                    await LoadPhotoAsync(photo);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                }
            }

            async Task LoadPhotoAsync(FileResult photo)
            {
                if (photo == null)
                {
                    PhotoPath = null;
                }

                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                PhotoPath = newFile;
                PhotoImage.Source = newFile;
            }
        }
    }
}