using Model;
using System.Threading.Tasks;

namespace SQLite
{
    /// <summary>
    /// SQLite version of an IAuthentification manager
    /// </summary>
    public class SQLiteAuthentificationManager : IAuthentificationManager
    {
        /// <summary>
        /// Trie to authenticate with email and password
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>true if the authentication succeed</returns>
        public bool Authenticate(string Email, string Password)
        {
            //trie to get a user in the database with a given email
            User searchUser = SQLiteManager.GetInstance().GetUserByEmail(Email).Result;
            //if no user with this email ...
            if (searchUser == null || searchUser.password != Password)
            {
                return false;
            }
            //else
            AuthenticatedUser = searchUser;
            return true;
        }

        public User AuthenticatedUser { get; set; }

        /// <summary>
        /// Add a new user (email and password)
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The number of line added in the database</returns>
        public Task<int> AddUser(string Email, string Password) => SQLiteManager.GetInstance().AddUser(Email, Password);

        /// <summary>
        /// Delete all the users in the database
        /// </summary>
        public void DeleteAllUsers() => SQLiteManager.GetInstance().DeleteAllUsers();
    }
}