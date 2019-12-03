using Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    /// <summary>
    /// The view model of the login page
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The login command
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// The delete command
        /// </summary>
        public Command DeleteAllUsersCommand { get; set; }

        /// <summary>
        /// The command to use to go to the register page
        /// </summary>
        public Command NavigateToRegisterPageCommand { get; set; }
        = new Command(
            () => (App.Current as App).MainPage = new Views.RegisterPage()
            );

        /// <summary>
        /// The reference to the view model of the manager
        /// </summary>
        public ManagerViewModel Manager
        {
            get; set;
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="T:MenuApp.ViewModels.LoginViewModel"/> class
        /// </summary>
        /// <param name="ManagerVM">The view model of the manager</param>
        public LoginViewModel(ManagerViewModel ManagerVM) : base()
        {
            Manager = ManagerVM;
            LoginCommand = new Command(LoginExecute, CanLogin);
            DeleteAllUsersCommand = new Command(DeleteExecute);
        }

        /// <summary>
        /// The email of the user
        /// </summary>
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

        /// <summary>
        /// The password of the user
        /// </summary>
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

        /// <summary>
        /// Execute of the login command
        /// </summary>
        private void LoginExecute()
        {
            if (Manager == null) return;
            //trie to authenticate
            bool result = Manager.Authenticate(Email, Password);
            //if it fails ...
            if(result == false)
            {
                App.Current.MainPage.DisplayAlert("Echec de l'authentification.", "Identifiant ou mot de passe incorrect.", "Compris");
                return;
            }
            //if it's a success, verify the password
            else
            {
                App.Current.MainPage.DisplayAlert("Bonjour !", $"Bienvenue {Manager.AuthenticatedUser.email}. Vous êtes désormais sur votre espace personnel.", "Continuer");
                App.Current.MainPage = new Views.MainPage();
            }
        }

        /// <summary>
        /// The can execute of the login command
        /// </summary>
        /// <returns>can login => true / can't login => false</returns>
        private bool CanLogin()
        {
            //Email and Password not null
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The execute of the delete command
        /// </summary>
        public void DeleteExecute()
        {
            //Delete all the users on the database
            Manager.DeleteAllUsers();
            App.Current.MainPage.DisplayAlert("Suppression OK", "Les utilisateurs ont tous été supprimé de la base de donnée.", "Compris");
        }
    }
}
