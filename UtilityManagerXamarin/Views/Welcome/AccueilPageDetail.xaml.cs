using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityManagerXamarin.Models;
using UtilityManagerXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UtilityManagerXamarin.Views.Welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccueilPageDetail : ContentPage
    {
        ItemsViewModel viewModel;
        public AccueilPageDetail()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(/*new ItemDetailViewModel(item)*/));

            // Manually deselect item.
            // ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            //    viewModel.LoadItemsCommand.Execute(null);
        }

        private void HomeButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Organisation());
        }

        private void SalesButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShopPage());
        }

        private void StoreButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StockPage());
        }

        private void EmployeeButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sales());
        }

        private void StockButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Employee());
        }

        private void OrganisationButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Finances());
        }

        private void SettingButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }

        private void AboutButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}