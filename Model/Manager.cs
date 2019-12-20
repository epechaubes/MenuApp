using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Main facade of the model
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// The dependency for the authentification
        /// </summary>
        public IAuthentificationManager AuthentificationManager { get; set; }

        public IAlimentsManager AlimentsManager { get; set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="T:Model.Manager"/> class
        /// </summary>
        /// <param name="authMgr">The manager for authentification</param>
        public Manager (IAuthentificationManager authMgr, IAlimentsManager alimMgr)
        {
            AuthentificationManager = authMgr;
            AlimentsManager = alimMgr;
        }

        /// <summary>
        /// Trie to authenticate with email and password
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>true if the authentication succeed</returns>
        public bool Authenticate(string Email, string Password) => AuthentificationManager.Authenticate(Email, Password);

        public User AuthenticatedUser => AuthentificationManager.AuthenticatedUser;

        /// <summary>
        /// Add a new user (email and password)
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The number of line added in the database</returns>
        public Task<int> AddUser(string Email, string Password) => AuthentificationManager.AddUser(Email, Password);

        /// <summary>
        /// Delete all the users in the database
        /// </summary>
        public void DeleteAllUsers() => AuthentificationManager.DeleteAllUsers();

        public List<Aliments> GetAllAliments() => AlimentsManager.GetAllAliments();

        public List<Aliments> GetAlimentsByCategory(int cate) => AlimentsManager.GetAlimentsByCategory(cate);
    }
}
