using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Model
{
    public class MenuAppDatabase
    {

        private static MenuAppDatabase instance; 

        private SQLiteConnection _connection;

        private MenuAppDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<User>();
        }

        public static MenuAppDatabase GetInstance()
        {
            if(instance == null)
            {
                instance = new MenuAppDatabase();
            }

            return instance;
        }

        public User GetUserByEmail(string mail)
        {
            return _connection.Table<User>().FirstOrDefault(t => t.email == mail);
        }

        public void AddUser(string email, string password)
        {
            var newUser = new User
            {
                email = email,
                password = password
            };
            _connection.Insert(newUser);
        }
    }
}
