using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MenuApp.ViewModels
{
    /// <summary>
    /// le ViewModel du manager
    /// </summary>
    public class ManagerViewModel : BaseViewModel<Manager>
    {
        /// <summary>
        /// initialise une nouvelle instance de la classe ManagerViewModel
        /// </summary>
        /// <param name="model">la facade principale du model</param>
        public ManagerViewModel(Manager model) : base(model)
        {

        }

        /// <summary>
        /// essaye de s'identifier avec email et password
        /// </summary>
        /// <param name="Email">email de l'utilisateur</param>
        /// <param name="Password">mot de passe de l'utilisateur</param>
        /// <returns>true si l'authentification est un succès</returns>
        public bool Authenticate(string Email, string Password) => Model.Authenticate(Email, Password);

        /// <summary>
        /// l'utilisateur authentifié
        /// </summary>
        public User AuthenticatedUser => Model.AuthenticatedUser;

        /// <summary>
        /// ajoute un nouvel utilisateur
        /// </summary>
        /// <param name="Email">email de l'utilisateur</param>
        /// <param name="Password">mot de passe de l'utilisateur</param>
        /// <returns>le nombre de lignes ajoutées à la base de donnée</returns>
        public Task<int> AddUser(string Email, string Password) => Model.AddUser(Email, Password);

        /// <summary>
        /// supprime tous les utilisateurs de la base
        /// </summary>
        public void DeleteAllUsers() => Model.DeleteAllUsers();

        /// <summary>
        /// tous les aliments existants
        /// </summary>
        /// <returns>liste d'aliments</returns>
        public List<Aliments> GetAllAliments() => Model.GetAllAliments();

        /// <summary>
        /// les aliments appartenant à une catégorie du menu
        /// </summary>
        /// <param name="cate">catégorie du menu</param>
        /// <returns>liste d'aliments</returns>
        public List<Aliments> GetAlimentsByCategory(int cate) => Model.GetAlimentsByCategory(cate);
    }
}
