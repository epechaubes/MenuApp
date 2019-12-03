using System.Collections.Generic;
using Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => App.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.ComposeMenus, Title = "Composer mon menu", Image = "compose.png"},
                new HomeMenuItem {Id = MenuItemType.CheckMenus, Title = "Consulter mes menus", Image = "check.png"},
                new HomeMenuItem {Id = MenuItemType.About, Title = "À propos", Image = "about.png"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}