using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class ShopPage : TabbedPage
	{
		public ShopPage ()
		{

			InitializeComponent ();

            GetListShopAsync();
            //ItemsListView.ItemsSource = Shops2;

            LoadStructures();
            SelectStructure.ItemsSource = Structures2;

            LoadQuarters();
            SelectQuarter.ItemsSource = Quarters2;

            ItemsListView.ItemsSource = ShopList;



        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            TimeSpan ts = TimeSpan.FromSeconds(0);
            await locator.StartListeningAsync(ts, 50);

            var position = await locator.GetPositionAsync();

            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 3.8667, 11.5167);
            locationMap.MoveToRegion(span);
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationMap.MoveToRegion(span);
        }

        public ErrorMessage error = new ErrorMessage();

        //Observable collections of Structures
        public ObservableCollection<string> Structures = new ObservableCollection<string>();
        public ObservableCollection<string> Structures2 = new ObservableCollection<string>() { "Utility Manager"};
        public ObservableCollection<Structure> StructureList = new ObservableCollection<Structure>();
        public long StructureId = -1;


        //Observable collection of Quarters
        public ObservableCollection<string> Quarters = new ObservableCollection<string>();
        public ObservableCollection<string> Quarters2 = new ObservableCollection<string>() { "Mvan", "Bastos" };
        public ObservableCollection<Quarter> QuarterList = new ObservableCollection<Quarter>();
        public long QuarterId = -1;

        //Observable collection of Shops
        public ObservableCollection<Shop> ShopList = new ObservableCollection<Shop>();
        public ObservableCollection<string> Shops = new ObservableCollection<string>();
        public ObservableCollection<string> Shops2 = new ObservableCollection<string>();
        public Shop shop = new Shop();



        //Load the list of shops to the listView
        //public async void LoadShops()
        //{
        //    if (await GetListShopAsync())
        //    {
        //        //Quarters2 = Quarters;
        //        //Get the list of Quarters
        //        Shops2 = Shops;
        //        ItemsListView.ItemsSource = Shops2;
        //        //Get the selected item
        //        //SelectQuarter.SelectedItem = QuarterId;
        //    }
        //    else
        //    {
        //        Structures2 = new ObservableCollection<string>
        //        {
        //            "null"
        //        };
        //    }
        //}



        //Get List of Shops
        public async void /*Task<Boolean>*/ GetListShopAsync()
        {
            

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
                    ShopList = JsonConvert.DeserializeObject<ObservableCollection<Shop>>(content);

                    ItemsListView.ItemsSource = ShopList;
                    //foreach (Shop el in ShopList)
                    //{
                    //    Shops.Add(el.Name);
                    //}
                    //result = true;
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

            //return result;
        }


        //Load List of quarters
        //Load List of Structures
        public async void LoadQuarters()
        {
            if (await GetListQuatrterAsync())
            {
                Quarters2 = Quarters;
                //Get the list of Quarters
                SelectQuarter.ItemsSource = Quarters2;
                //Get the selected item
                SelectQuarter.SelectedItem = QuarterId;
            }
            else
            {
                Structures2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }



        //Get List of Quarters
        public async Task<Boolean> GetListQuatrterAsync()
        {
            var result = false;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Quarters"; //103.63.2.147
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
                    QuarterList = JsonConvert.DeserializeObject<ObservableCollection<Quarter>>(content);


                    foreach (Quarter el in QuarterList)
                    {
                        Quarters.Add(el.Name);
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


        //Load List of Structures
        public async void LoadStructures()
        {
            if (await GetStructuresAsync())
            {
                Structures2 = Structures;
                SelectStructure.ItemsSource = Structures2;

                SelectStructure.SelectedItem = StructureId;
            }
            else
            {
                Structures2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }







        //Get List of Structures
        public async Task<Boolean> GetStructuresAsync()
        {
            var result = false;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Structures"; //103.63.2.147
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
                    StructureList = JsonConvert.DeserializeObject<ObservableCollection<Structure>>(content);


                    foreach (Structure el in StructureList)
                    {
                        Structures.Add(el.Name);
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

        private void SelectStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = SelectStructure.SelectedIndex;
            if(selectedIndex != -1)
            {
                foreach(Structure el in StructureList)
                {
                    var selectItem = SelectStructure.SelectedItem.ToString();
                    if (selectItem.Equals(el.Name))
                    {
                        StructureId = el.Id;
                    }
                }
            }
        }

        private void SelectQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectIndex = SelectQuarter.SelectedIndex;
            if(selectIndex != -1)
            {
                foreach(Quarter el in QuarterList)
                {
                    var selectedItem = SelectQuarter.SelectedItem.ToString();
                    if (selectedItem.Equals(el.Name))
                    {
                        QuarterId = el.Id;
                    }
                }
            }
        }

        //Register a shop
        public async Task<Boolean> RegisterShopAsync(string name, /*Ipoint lacation*/ DateTime shopCreatedDate, long structureId, long quarterId)
        {
            var model = new Models.Shop
            {
                Name = name,
                ShopCreatedDate = shopCreatedDate,
                StructureId = structureId,
                QuarterId = quarterId
            };

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Shops"; //103.63.2.147
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
                shop = JsonConvert.DeserializeObject<Shop>(content);
                if(shop != null)
                {
                await App.Current.MainPage.DisplayAlert("Status Successfull", "Shop Registered Successfully", "OK");

                }
                else
                {
                    content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }

            }
            

            return response.IsSuccessStatusCode;
        }







        ////Delete a shop
        //public async Task<Boolean> DeleteShopAsync(string name, /*Ipoint lacation*/ DateTime shopCreatedDate, long structureId, long quarterId)
        //{
        //    var model = new Models.Shop
        //    {
        //        Name = name,
        //        ShopCreatedDate = shopCreatedDate,
        //        StructureId = structureId,
        //        QuarterId = quarterId
        //    };

        //    Parametre parametre = new Parametre();
        //    string BaseUrl = parametre.ServeurName + "/api/Shops"; //103.63.2.147
        //    var httpClient = new HttpClient();
        //    //data been send to the browser and needs to be serialize
        //    var jsonLogin = JsonConvert.SerializeObject(model);
        //    HttpContent httpContent = new StringContent(jsonLogin);
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"] as string);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    httpClient.DefaultRequestHeaders.Accept
        //              .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);
        //    if (response.IsSuccessStatusCode)
        //    {

        //        var content = await response.Content.ReadAsStringAsync();
        //        shop = JsonConvert.DeserializeObject<Shop>(content);
        //        if (shop != null)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Status Successfull", "Shop Registered Successfully", "OK");

        //        }
        //        else
        //        {
        //            content = await response.Content.ReadAsStringAsync();
        //            error = JsonConvert.DeserializeObject<ErrorMessage>(content);
        //        }

        //    }


        //    return response.IsSuccessStatusCode;
        //}

        private async void CreateShopButton_Clicked(object sender, EventArgs e)
        {
            if(await RegisterShopAsync(Name.Text, Date.Date, StructureId, QuarterId))
            {

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }

        //Update Button Clicked
        private void UpdateItem_Clicked(object sender, EventArgs e)
        {
            
        }

        //Delete Button Clicked
        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            //var shop = (sender as MenuItem).CommandParameter as Shop;
            

            var shop = ((MenuItem)sender).CommandParameter as Shop;

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Shops/"+shop.Id; //103.63.2.147
            var httpClient = new HttpClient();
            //data been send to the browser and needs to be serialize
            var jsonLogin = JsonConvert.SerializeObject(shop);
            HttpContent httpContent = new StringContent(jsonLogin);
           // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"] as string);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response =  httpClient.DeleteAsync(BaseUrl);
            
            //if (response)
            //{

            //    var content = await response.Content.ReadAsStringAsync();
            //    shop = JsonConvert.DeserializeObject<Shop>(content);
            //    if (shop != null)
            //    {
            //        await App.Current.MainPage.DisplayAlert("Status Successfull", "Shop Registered Successfully", "OK");

            //    }
            //    else
            //    {
            //        content = await response.Content.ReadAsStringAsync();
            //        error = JsonConvert.DeserializeObject<ErrorMessage>(content);
            //    }

            //}

        }


    }
    
}