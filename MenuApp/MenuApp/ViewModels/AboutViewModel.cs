using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    public class AboutViewModel
    {
        public Command OpenWebCommand { get; }

        public AboutViewModel()
        {
            OpenWebCommand = new Command<string>((str) => Device.OpenUri(new Uri(str)));
        }
    }
}
