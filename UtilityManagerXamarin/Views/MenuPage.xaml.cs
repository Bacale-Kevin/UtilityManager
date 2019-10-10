using UtilityManagerXamarin.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UtilityManagerXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse", Icon="browse.png" },
                new HomeMenuItem {Id = MenuItemType.CreateInterprice, Title="Organisation", Icon="company.png" },
                new HomeMenuItem {Id = MenuItemType.CreateAShop, Title="Shop", Icon="shopping.png" },
                new HomeMenuItem {Id = MenuItemType.Personel, Title="Employees", Icon="hiring.png"  },
                new HomeMenuItem {Id = MenuItemType.Sell, Title="Sales", Icon="garage.png"  },
                new HomeMenuItem {Id = MenuItemType.ManageStock, Title="Stocks", Icon="warehous.png"  },
                new HomeMenuItem {Id = MenuItemType.BusinessHealth, Title="Finances", Icon="dollar.png"},
                new HomeMenuItem {Id = MenuItemType.Statistics, Title="Statistics", Icon="statistics.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" , Icon="journalist.png"},
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", Icon="settings.png" },
                new HomeMenuItem {Id = MenuItemType.LogOut, Title="LogOut" , Icon="LogOut.png"},
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

            //ListViewMenu.SelectedItem = menuItems[2];
            //ListViewMenu.ItemSelected +=  (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //     Application.Current.MainPage = new AboutPage();
            //};
        }
    }
}