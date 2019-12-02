using MenuApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel((App.Current as App).Manager);
        }
    }
}