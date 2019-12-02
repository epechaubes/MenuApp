using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        /// <summary>
        /// Command for create a new account
        /// </summary>
        public Command RegisterCommand { get; set; }

        /// <summary>
        /// Command for go back to the login page
        /// </summary>
        public Command GoBackToLoginCommand { get; set; }

        /// <summary>
        /// The reference to the view model of the manager
        /// </summary>
        public ManagerViewModel Manager { get; set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="T:MenuApp.ViewModels.RegisterViewModel"/> class
        /// </summary>
        /// <param name="managerVM">The view model of the manager</param>
        public RegisterViewModel(ManagerViewModel managerVM)
        {
            Manager = managerVM;
            RegisterCommand = new Command(RegisterExecute, CanRegister);
            GoBackToLoginCommand = new Command(GoBackExecute);
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
                RegisterCommand.ChangeCanExecute();
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
                RegisterCommand.ChangeCanExecute();
            }
        }

        /// <summary>
        /// The verification of the password
        /// </summary>
        private string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                SetProperty(ref confirmPassword, value);
                RegisterCommand.ChangeCanExecute();
            }
        }

        /// <summary>
        /// The execute of the register command
        /// </summary>
        public void RegisterExecute()
        {
            //trie to create the account
            try
            {
                int registerResult = Manager.AddUser(email, password).Result;
                //Go back to the login page and display a message
                App.Current.MainPage = new Views.LoginPage();
                App.Current.MainPage.DisplayAlert("Le compte utilisateur a bien été crée", "Vous pouvez désormais vous connecter avec vos identifiants.", "Compris");
            }
            //if an account with this email already exist, display an alert
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Erreur", "Un compte utilisant cette adresse mail existe déjà.", "Compris");
                return;
            }
        }

        /// <summary>
        /// The can execute of the register command
        /// </summary>
        /// <returns>True if the password and confirmPassword are equals</returns>
        public bool CanRegister()
        {
            if (ConfirmPassword == Password) { return true; }
            return false;
        }

        /// <summary>
        /// The execute of the go back to login page command
        /// </summary>
        public void GoBackExecute()
        {
            App.Current.MainPage = new Views.LoginPage();
        }
    }
}
