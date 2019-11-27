using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IAuthentificationManager
    {
        bool Authenticate(string Email, string Password, MenuAppDatabase database);
    }
}
