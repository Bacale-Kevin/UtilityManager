using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UtilityManagerXamarin.Services;
using Xamarin.Forms;

namespace UtilityManagerXamarin.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            
        }

        private ApiServices apiServices = new ApiServices();

        public string PersonneId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await apiServices.ConnexionAsync(Username, Password);
                    //Application.Current.MainPage = new MasterDetailPage1();

                });
            }

        }
    }
}
