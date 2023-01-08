using Inleveropdracht_B2C4.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Inleveropdracht_B2C4.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}