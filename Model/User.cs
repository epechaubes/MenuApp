using SQLite;

namespace Model
{
    /// <summary>
    /// a user who can be authenticated
    /// </summary>
    public class User
    {
        /// <summary>
        /// The email of the user
        /// </summary>
        [PrimaryKey, Unique]
        public string email { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="T:Model.User"/> class
        /// </summary>
        public User()
        {

        }
    }
}
