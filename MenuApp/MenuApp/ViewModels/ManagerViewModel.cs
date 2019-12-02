using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MenuApp.ViewModels
{
    /// <summary>
    /// The view model of the manager
    /// </summary>
    public class ManagerViewModel : BaseViewModel<Manager>
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="T:MenuApp.ViewModels.ManagerViewModel"/> class
        /// </summary>
        /// <param name="model">The main facade of the model</param>
        public ManagerViewModel(Manager model) : base(model)
        {

        }

        /// <summary>
        /// Trie to authenticate with mail and password
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>true if authentication succeed</returns>
        public User Authenticate(string Email, string Password) => Model.Authenticate(Email, Password);

        /// <summary>
        /// Add a new user (email and password)
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The number of line added in the database</returns>
        public Task<int> AddUser(string Email, string Password) => Model.AddUser(Email, Password);

        /// <summary>
        /// Delete all the users in the database
        /// </summary>
        public void DeleteAllUsers() => Model.DeleteAllUsers();
    }
}
