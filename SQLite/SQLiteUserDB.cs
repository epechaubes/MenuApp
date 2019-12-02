using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    /// <summary>
    /// The class who control the user table
    /// </summary>
    class SQLiteUserDB
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="T:SQLite.SQLiteUserDB"/> class
        /// </summary>
        public SQLiteUserDB()
        {

        }

        /// <summary>
        /// Trie to get a user of the table with the given email
        /// </summary>
        /// <param name="mail">Email of the user</param>
        /// <returns>The user</returns>
        public Task<User> GetUserByEmail(string mail)
        {
            return SQLiteManager.GetInstance()._database.Table<User>().Where(i => i.email == mail).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new user (email and password)
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The number of line added in the database</returns>
        public Task<int> AddUser(string Email, string Password)
        {
            var newUser = new User
            {
                email = Email,
                password = Password
            };
            return SQLiteManager.GetInstance()._database.InsertAsync(newUser);
        }

        /// <summary>
        /// Delete all the users in the database
        /// </summary>
        public void DeleteAllUsers()
        {
            SQLiteManager.GetInstance()._database.ExecuteAsync("DELETE FROM User");
        }
    }
}
