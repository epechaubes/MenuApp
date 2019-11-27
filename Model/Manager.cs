using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Manager
    {
        public IAuthentificationManager AuthentificationManager { get; set; }

        public Manager (IAuthentificationManager authMgr)
        {
            AuthentificationManager = authMgr;
        }

        public bool Authenticate(string Email, string Password, MenuAppDatabase database) => AuthentificationManager.Authenticate(Email, Password, database);
    }
}
