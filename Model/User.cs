using System;
using SQLite.Net.Attributes;

namespace Model
{
    public class User
    {
        [PrimaryKey, Unique]
        public string email { get; set; }
        public string password { get; set; }

        public User()
        {

        }
    }
}
