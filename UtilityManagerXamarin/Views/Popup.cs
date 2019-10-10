using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UtilityManagerXamarin.Views
{
    public class PopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopUp()
        {
            Content = new StackLayout
            {
                Children = {new StackLayout{ Children ={new ActivityIndicator { IsEnabled = true, IsRunning = true,
                    IsVisible = true, HorizontalOptions = LayoutOptions.Center,
                                Color = Color.Green }, new Label { Text = "Loading...", TextColor = Color.Green, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center}
                    } }
                }
            };
        }
    }
}
