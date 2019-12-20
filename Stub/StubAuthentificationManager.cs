using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    /// <summary>
    /// The stub version of the IAuthentificationManager
    /// </summary>
    public class StubAuthentificationManager : IAuthentificationManager
    {
        /// <summary>
        /// Trie to authenticate with email and password
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>true if the authentication succeed</returns>
        public bool Authenticate(string Email, string Password)
         {
            var user = users.Find(t => t.email == Email && t.password == Password);
            if (user != null)
            {
                AuthenticatedUser = user;
                return true;
            }
            else
            {
                return false;
            }
         }

        public User AuthenticatedUser { get; set; }

        /// <summary>
        /// Add a user 
        /// </summary>
        /// <param name="Email">Email of the user</param>
        /// <param name="Password">Password of the user</param>
        /// <returns>The int 1</returns>
        /// <remarks>Impossible to add a user in stub. The return simulate a successfull adding</remarks>
        public Task<int> AddUser(string Email, string Password)
        {
            if (!users.Exists(t => t.email == Email))
            {
                users.Add(new User()
                {
                    email = Email,
                    password = Password
                });
                return Task.FromResult(1);
            }
            else
            {
                throw new Exception("Cet email est déjà utilisé.");
            }
        }

        /// <summary>
        /// Delete all users
        /// </summary>
        /// <remarks>Impossible to delete the users in stub</remarks>
        public void DeleteAllUsers()
        {

        }

        /// <summary>
        /// Stub users and their passwords
        /// </summary>
        List<User> users = new List<User>()
        {
            new User { email = "groot", password = "groot" },
            new User { email = "test", password = "test" },
        };

    }
}
