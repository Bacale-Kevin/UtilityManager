using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Models
{
    public enum MenuItemType
    {
        Browse,
        CreateInterprice,
        CreateAShop,
        Personel,
        Sell,
        ManageStock,
        BusinessHealth,
        About,
        Statistics,
        Settings,
        LogOut
    }

    

    public class HomeMenuItem
    {

        public HomeMenuItem()
        {
           
        }
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

      //  public Type TargetType { get; set; }
    }
}
