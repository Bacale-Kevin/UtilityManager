using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UtilityManagerXamarin.Views;
using UtilityManagerXamarin.Views.Welcome;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UtilityManagerXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new HomePage();
            //MainPage = new AccueilPage();
            // MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
