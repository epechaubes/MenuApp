using MenuApp.ViewModels;
using MenuApp.Views;
using Xamarin.Forms;

namespace MenuApp
{
    public partial class App : Application
    {
        public ManagerViewModel Manager { get; set; } = new ManagerViewModel(new Model.Manager(new Stub.StubAuthentificationManager(),
                                                                                               new Stub.StubAliments()));

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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
