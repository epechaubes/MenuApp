using MenuApp.ViewModels;
using MenuApp.Views;
using Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuApp
{
    public partial class App : Application
    {
        public ManagerViewModel Manager { get; set; } = new ManagerViewModel(new Model.Manager(new Stub.StubAuthentificationManager()));

        public MenuAppDatabase db = new MenuAppDatabase();

        public App()
        {
            InitializeComponent();

            var database = new MenuAppDatabase();

            MainPage = new LoginPage(database);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
