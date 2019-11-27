using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace MenuApp.ViewModels
{
    public class ManagerViewModel : BaseViewModel<Manager>
    {
        public ManagerViewModel(Manager model) : base(model)
        {

        }

        public bool Authenticate(string Email, string Password, MenuAppDatabase database) => Model.Authenticate(Email, Password, database);
    }
}
