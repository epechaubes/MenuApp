using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stub
{
    public class StubAuthentificationManager : IAuthentificationManager
    {
        public bool Authenticate(string Email, string Password, MenuAppDatabase database)
        {
            var user = database.GetUserByEmail(Email);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
