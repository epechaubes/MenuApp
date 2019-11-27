using Model;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        public MenuAppDatabase _database;

        public ManagerViewModel Manager
        {
            get; set;
        }

        public LoginViewModel(ManagerViewModel ManagerVM, MenuAppDatabase database) : base()
        {
            Manager = ManagerVM;

            _database = database;

            LoginCommand = new Command(LoginExecute, CanLogin);
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                LoginCommand.ChangeCanExecute();
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                LoginCommand.ChangeCanExecute();
            }
        }

        private void LoginExecute()
        {
            if (Manager == null) return;
            bool result = Manager.Authenticate(Email, Password, _database);
            if(result == false)
            {
                App.Current.MainPage.DisplayAlert("Echec de l'authentification.", "Les identifications ne correspondent à aucun utilisateur.", "Compris");
                return;
            }
            App.Current.MainPage.DisplayAlert("Bonjour !", "Bienvenue sur votre espace.", "Continuer");
        }

        private bool CanLogin()
        {
            return false;
        }
    }
}
