using Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SQLite
{
    /// <summary>
    /// The manager to create databse, instance of database and tables
    /// </summary>
    public class SQLiteManager
    {
        /// <summary>
        /// The instance of the database
        /// </summary>
        private static SQLiteManager instance;

        /// <summary>
        /// The connection to the database
        /// </summary>
        public SQLiteAsyncConnection _database;

        /// <summary>
        /// The reference to the database user table
        /// </summary>
        private SQLiteUserDB userDb = new SQLiteUserDB();

        /// <summary>
        /// Initialize a new instance of the <see cref="T:SQLite.SQLiteAuthenticationManager"/> class
        /// </summary>
        private SQLiteManager()
        {
            //The file name of the database
            string fileName = "MenuAppDB.db";
            //The path of the storage folder of the database file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //The complete path of the database file
            string fullPath = Path.Combine(path, fileName);
            //Create the database and the tables
            _database = new SQLiteAsyncConnection(fullPath);
            _database.CreateTableAsync<User>().Wait();
        }

        /// <summary>
        /// Singleton of the database
        /// </summary>
        /// <returns>The instance of the database</returns>
        public static SQLiteManager GetInstance()
        {
            if(instance == null)
            {
          instance = new SQLiteManager();
            }
            return instance;
        }

        /// <summary>
        /// Trie to get a user of the table with the given email
        /// </summary>
        /// <param name="mail">Email of the user</param>
        /// <returns>The user</returns>
        public Task<User> GetUserByEmail(string mail) => userDb.GetUserByEmail(mail);

        /// <summary>
        /// Add a new user (email and password)
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The number of line added in the database</returns>
        public Task<int> AddUser(string email, string password) => userDb.AddUser(email, password);

        /// <summary>
        /// Delete all the users in the database
        /// </summary>
        public void DeleteAllUsers() => userDb.DeleteAllUsers();
    }
}
