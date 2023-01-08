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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

        }

        private void Cl_Login(object sender, EventArgs e)
        {
            bool UsernameEmpty = string.IsNullOrEmpty(En_Username.Text);
            bool PasswordEmpyt = string.IsNullOrEmpty(En_Password.Text);
            if (UsernameEmpty)
            {
                En_Username.Placeholder = "Cannot be empty";
            }
            else if (PasswordEmpyt)
            {
                En_Password.Placeholder = "Cannot be empty";
            }
            else
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}