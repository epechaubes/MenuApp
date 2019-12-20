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
        /// commande pour créer un compte
        /// </summary>
        public Command RegisterCommand { get; set; }

        /// <summary>
        /// commande pour revenir à la page de login
        /// </summary>
        public Command GoBackToLoginCommand { get; set; }

        /// <summary>
        /// référence au ViewModel du manager
        /// </summary>
        public ManagerViewModel Manager { get; set; }

        /// <summary>
        /// initialise une nouvelle instance de la classe RegisterViewModel
        /// </summary>
        /// <param name="managerVM">le ViewModel du manager</param>
        public RegisterViewModel(ManagerViewModel managerVM)
        {
            Manager = managerVM;
            RegisterCommand = new Command(RegisterExecute, CanRegister);
            GoBackToLoginCommand = new Command(GoBackExecute);
        }

        /// <summary>
        /// email de l'utilisateur
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
        /// password de l'utilisateur
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
        /// vérification du password
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
        /// l'execute de la commande register
        /// </summary>
        public void RegisterExecute()
        {
            //essaye de créer un compte
            try
            {
                int registerResult = Manager.AddUser(email, password).Result;
                //retourne à la page de login et affiche un message
                App.Current.MainPage = new Views.LoginPage();
                App.Current.MainPage.DisplayAlert("Le compte utilisateur a bien été crée", "Vous pouvez désormais vous connecter avec vos identifiants.", "Compris");
            }
            //si un compte avec ce mail existe déjà, affiche un message
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Erreur", "Un compte utilisant cette adresse mail existe déjà.", "Compris");
                return;
            }
        }

        /// <summary>
        /// le can execute de la commande regiser
        /// </summary>
        /// <returns>true si password et verif password sont égaux</returns>
        public bool CanRegister()
        {
            if (ConfirmPassword == Password) { return true; }
            return false;
        }

        /// <summary>
        /// l'execute de la commande go back to login page
        /// </summary>
        public void GoBackExecute()
        {
            App.Current.MainPage = new Views.LoginPage();
        }
    }
}
