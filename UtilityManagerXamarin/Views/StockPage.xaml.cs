using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UtilityManagerXamarin.Models;
using UtilityManagerXamarin.Parameters;
using UtilityManagerXamarin.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UtilityManagerXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StockPage : TabbedPage
	{
		public StockPage ()
		{
			InitializeComponent();

            LoadCategories();
            CategoryPicker.ItemsSource = Categories2;

            LoadShops();
            ShopPicker.ItemsSource = Shop2;

            LoadItems();
            ItemPicker.ItemsSource = Items2;
;

        }

        public ObservableCollection<string> Categories = new ObservableCollection<string>();
        public ObservableCollection<string> Categories2 = new ObservableCollection<string>() { "Utility Manager" };
        public ObservableCollection<Category> categoryList = new ObservableCollection<Category>();
        public long CategoryId = -1;
        Item item = new Item();



        public ObservableCollection<string> Items = new ObservableCollection<string>();
        public ObservableCollection<string> Items2 = new ObservableCollection<string>() { "Utility Manager" };
        public ObservableCollection<Item> ItemsList = new ObservableCollection<Item>();
        public long ItemsId = -1;


        public ObservableCollection<string> Shops = new ObservableCollection<string>();
        public ObservableCollection<string> Shop2 = new ObservableCollection<string>() { "Utility Manager" };
        public ObservableCollection<Shop> ShopsList = new ObservableCollection<Shop>();
        public long ShopsId = -1;
        Shop shop = new Shop();
        Stock stock = new Stock();




        public ErrorMessage error = new ErrorMessage();




        public async void LoadShops()
        {
            if (await GetListShopAsync())
            {
                //Quarters2 = Quarters;
                //Get the list of Quarters
                Shop2 = Shops;
                ShopPicker.ItemsSource = Shop2;
                //Get the selected item
                ShopPicker.SelectedItem = ShopsId;
            }
            else
            {
                Shops = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }




        public async void LoadItems()
        {
            if (await GetListItemAsync())
            {
                //Quarters2 = Quarters;
                //Get the list of Quarters
                Items2 = Items;
                ItemPicker.ItemsSource = Items2;
                //Get the selected item
                ItemPicker.SelectedItem = ItemsId;
            }
            else
            {
                Shops = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }






        //Get List of Items
        public async Task<Boolean> GetListItemAsync()
        {
            var result = false;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Items"; //103.63.2.147
            var httpClient = new HttpClient();
            //Tell Xamarin to accept data in json format
            httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                //added
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    ItemsList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(content);


                    foreach (Item el in ItemsList)
                    {
                        Items.Add(el.Name);
                    }
                    result = true;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }
            }
            catch (Exception exc)
            {

            }

            return result;
        } 
        
        
        //Get List of Shops
        public async Task<Boolean> GetListShopAsync()
        {
            var result = false;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Shops"; //103.63.2.147
            var httpClient = new HttpClient();
            //Tell Xamarin to accept data in json format
            httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                //added
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    ShopsList = JsonConvert.DeserializeObject<ObservableCollection<Shop>>(content);


                    foreach (Shop el in ShopsList)
                    {
                        Shops.Add(el.Name);
                    }
                    result = true;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }
            }
            catch (Exception exc)
            {

            }

            return result;
        }


        public async void LoadCategories()
        {
            if (await GetListCategoryAsync())
            {
                //Quarters2 = Quarters;
                //Get the list of Quarters
                Categories2 = Categories;
                CategoryPicker.ItemsSource = Categories2;
                //Get the selected item
                CategoryPicker.SelectedItem = CategoryId;
            }
            else
            {
                Categories2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }





        //Get List of Categories
        public async Task<Boolean> GetListCategoryAsync()
        {
            var result = false;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Categories"; //103.63.2.147
            var httpClient = new HttpClient();
            //Tell Xamarin to accept data in json format
            httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                //added
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<ObservableCollection<Category>>(content);


                    foreach (Category el in categoryList)
                    {
                        Categories.Add(el.Name);
                    }
                    result = true;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }
            }
            catch (Exception exc)
            {

            }

            return result;
        }



        //Register Item
        public async Task<Boolean> RegisterItemAsync(string name, string models, long categoryId)
        {
            var model = new Models.Item
            {
                Name = name,
                Model = models,
                PersonneId = Application.Current.Properties["Id"] as string,
                CategoryId = categoryId
            };

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Items"; //103.63.2.147
            var httpClient = new HttpClient();
            //data been send to the browser and needs to be serialize
            var jsonLogin = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonLogin);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"] as string);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<Item>(content);
                if (item != null)
                {
                    await App.Current.MainPage.DisplayAlert("Status Successfull", "Item Registered Successfully", "OK");

                }
                else
                {
                    content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }

            }


            return response.IsSuccessStatusCode;
        }

        

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = CategoryPicker.SelectedIndex;
            if(index != -1)
            {
                
                foreach( Category el in categoryList)
                {
                    var selectedItem = CategoryPicker.SelectedItem.ToString();
                    if (selectedItem.Equals(el.Name))
                    {
                        CategoryId = el.Id;
                    }
                }
            }
        }

        private async void SaveItemButton_Clicked(object sender, EventArgs e)
        {
            if (await RegisterItemAsync(Name.Text, Model.Text, CategoryId))
            {
                // await Application.Current.MainPage.DisplayAlert("Status 201", "Structure registered successfully", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }

        private void CreateCategorieButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new CategoriePopUp());
        }

        private void ItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ItemPicker.SelectedIndex;
            if (index != -1)
            {

                foreach (Item el in ItemsList)
                {
                    var selectedItem = ItemPicker.SelectedItem.ToString();
                    if (selectedItem.Equals(el.Name))
                    {
                        ItemsId = el.Id;
                    }
                }
            }
        }

        private void ShopPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ShopPicker.SelectedIndex;
            if (index != -1)
            {

                foreach (Shop el in ShopsList)
                {
                    var selectedItem = ShopPicker.SelectedItem.ToString();
                    if (selectedItem.Equals(el.Name))
                    {
                        ShopsId = el.Id;
                    }
                }
            }
        }


        //Register a shop
        public async Task<Boolean> RegisterStockAsync(string name, DateTime date, decimal price, long itemId, int quantity, long shopId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var model = new Models.Stock();

                model.Name = name;
                model.StockCreationDate = date;
                model.Price = price;
                model.PersonneId = Application.Current.Properties["Id"] as string;
                model.ItemId = itemId;
                model.Quantity = quantity;
                model.ShopId = shopId;
                

                Parametre parametre = new Parametre();
                string BaseUrl = parametre.ServeurName + "/api/Stocks"; //103.63.2.147
                var httpClient = new HttpClient();
                //data been send to the browser and needs to be serialize
                var jsonLogin = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(jsonLogin);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"] as string);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept
                          .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    stock = JsonConvert.DeserializeObject<Stock>(content);
                    if (stock != null)
                    {
                        await App.Current.MainPage.DisplayAlert("Status Successfull", "Stock Registered Successfully", "OK");

                    }
                    else
                    {
                        content = await response.Content.ReadAsStringAsync();
                        error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                    }

                }
            }catch(Exception exc)
            {
                await DisplayAlert("Oups", exc.Message, "Ok");
            }


            return response.IsSuccessStatusCode;
        }

        private async void SaveStocButton_Clicked(object sender, EventArgs e)
        {
            //this method convert the string representation of an entry to a non string value like decimal
            decimal.TryParse(Price.Text ,out decimal tmp);
            int.TryParse(Quantity.Text, out int quantity);
            if (await RegisterStockAsync(NameStock.Text, DateStock.Date, tmp, ItemsId, quantity, ShopsId))
            {

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }


       
    }

}