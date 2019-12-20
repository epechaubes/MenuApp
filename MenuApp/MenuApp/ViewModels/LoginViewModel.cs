using Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    /// <summary>
    /// le ViewModel de la LoginPage
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// commande de login
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// commande de delete
        /// </summary>
        public Command DeleteAllUsersCommand { get; set; }

        /// <summary>
        /// commande pour aller à la RegisterPage
        /// </summary>
        public Command NavigateToRegisterPageCommand { get; set; }
        = new Command(
            () => (App.Current as App).MainPage = new Views.RegisterPage()
            );

        /// <summary>
        /// référence au ViewModel du manager
        /// </summary>
        public ManagerViewModel Manager
        {
            get; set;
        }

        /// <summary>
        /// initialise une nouvelle instance de la classe LoginViewModel
        /// </summary>
        /// <param name="ManagerVM">le ViewModel du manager</param>
        public LoginViewModel(ManagerViewModel ManagerVM) : base()
        {
            Manager = ManagerVM;
            LoginCommand = new Command(LoginExecute, CanLogin);
            DeleteAllUsersCommand = new Command(DeleteExecute);
        }

        /// <summary>
        /// l'email de l'utilisateur
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
        /// le mot de passe de l'utilisateur 
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
        /// l'execute de la commande de login 
        /// </summary>
        private void LoginExecute()
        {
            if (Manager == null) return;
            //essaie de s'authentifier 
            bool result = Manager.Authenticate(Email, Password);
            //en cas d'échec ...
            if(result == false)
            {
                App.Current.MainPage.DisplayAlert("Echec de l'authentification.", "Identifiant ou mot de passe incorrect.", "Compris");
                return;
            }
            //en cas dee succès, vérifie le mot de passe
            else
            {
                App.Current.MainPage.DisplayAlert("Bonjour !", $"Bienvenue {Manager.AuthenticatedUser.email}. Vous êtes désormais sur votre espace personnel.", "Continuer");
                App.Current.MainPage = new Views.MainPage();
            }
        }

        /// <summary>
        /// le can execute de la commande de login
        /// </summary>
        /// <returns>peut s'identifier => true / ne peut pas => false</returns>
        private bool CanLogin()
        {
            //Email et Password non null
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
        /// l'execute de la commande de delete
        /// </summary>
        public void DeleteExecute()
        {
            //supprime tous les utilisateurs de la base
            Manager.DeleteAllUsers();
            App.Current.MainPage.DisplayAlert("Suppression OK", "Les utilisateurs ont tous été supprimé de la base de donnée.", "Compris");
        }
    }
}
