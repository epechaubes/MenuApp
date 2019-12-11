using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Model;
using MenuApp.ViewModels;

namespace MenuApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComposeMenuPage : ContentPage
    {
        public ComposeMenuPage()
        {
            InitializeComponent();
            BindingContext = new ComposeMenuViewModel();
        }
    }
}