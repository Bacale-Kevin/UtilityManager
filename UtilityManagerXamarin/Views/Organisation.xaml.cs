using Newtonsoft.Json;
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
using UtilityManagerXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UtilityManagerXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Organisation : TabbedPage
    {

        //Obersavable collection of Towns
        //Observable collection is used to display a list of properties
        public ObservableCollection<string> Towns = new ObservableCollection<string>();
        public ObservableCollection<string> Towns2 = new ObservableCollection<string>() { "Yaounde, Douala" };
        public ObservableCollection<Town> TownList = new ObservableCollection<Town>();
        public long TownId = -1;


        //Observable collection of Quarters
        public ObservableCollection<string> Quarters = new ObservableCollection<string>();
        public ObservableCollection<string> Quarters2 = new ObservableCollection<string>() { "Awae", "Nkomo" };
        public ObservableCollection<Quarter> QuarterList = new ObservableCollection<Quarter>();
        //added

        //Here we just just need to select the item selected so no need for an observable collection
        public long QuartersId = -1;



        //List of activity Domain
        public ObservableCollection<string> ActivityDomains = new ObservableCollection<string>();
        public ObservableCollection<string> ActivityDomains2 = new ObservableCollection<string>()
        {
                    "Kamer","Lagos"
        };
        public ObservableCollection<ActivityDomain> ActivityDomainsList = new ObservableCollection<ActivityDomain>();
        //added
        public long ActivityDomainId = -1;



        public ObservableCollection<string> Items = new ObservableCollection<string>();
        public ObservableCollection<string> Items2 = new ObservableCollection<string>
                {
                    "Kamer","Lagos","Niger","Mali","Togo","Senegale"
                };


        public ErrorMessage error = new ErrorMessage();
        public ObservableCollection<Country> CountryList = new ObservableCollection<Country>();
        public long CountryId = -1;

        public Structure structure = new Structure();

        public MonToken montoken = new MonToken();
        public ErrorMessage erreur = new ErrorMessage();


        public Organisation()
        {
            InitializeComponent();

            loadCountries();
            SelectCountry.ItemsSource = Items2;

            loadActivityDomain();
            SelectActivityDomain.ItemsSource = ActivityDomains2;

            loadTown();
            SelectTown.ItemsSource = Towns2;

            loadQuarters();
            SelectQuarter.ItemsSource = Quarters2;
        }






        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrganisationViewPage());
        }

        //private void SelectCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}


        //Load list of countries
        public async void loadCountries()
        {
            if (await GetCountriesAsync())
            {
                Items2 = Items;
                //SelectCountry.SelectedItem = Items2.ElementAt<string>(1);
                SelectCountry.ItemsSource = Items2;

              //  SelectCountry.SelectedItem = CountryId;
            }
            else
            {
                Items2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }



        //Load Towns

        public async void loadTown()
        {
            if (await GetTownAsync())
            {
                Towns2 = Towns;
                SelectTown.ItemsSource = Towns2;

                SelectTown.SelectedItem = TownId;
            }
            else
            {
                Towns2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }








        //GetTownsAsync
        public async Task<Boolean> GetTownAsync()
        {
            var result = false;


            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Towns"; //103.63.2.147
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
                    //CountryNames.Clear();
                    //var content = await response.Content.ReadAsStringAsync();
                    //CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                    var content = await response.Content.ReadAsStringAsync();
                    TownList = JsonConvert.DeserializeObject<ObservableCollection<Town>>(content);

                    foreach (Town el in TownList)
                    {
                        Towns.Add(el.Name);
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





        //Load Quarters
        public async void loadQuarters()
        {
            if (await GetQuartersAsync())
            {
                Quarters2 = Quarters;
                SelectQuarter.ItemsSource = Quarters2;


                SelectQuarter.SelectedItem = QuartersId;


            }
            else
            {
                ActivityDomains2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }


       /// This event fires when an Item is selected on a picker
        private void SelectQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // here we make sure the element selected has an index 
            var selectIndex = SelectQuarter.SelectedIndex;
            //if the index is greater than -1 do this ...
            if (selectIndex != -1)
            {
                //Iterate through the list of quarter in the database
                foreach (Quarter el in QuarterList)
                {
                    //Element on a picker are populated as objects so we need to convert it tostring() before making a comparison
                    var selectedItem = SelectQuarter.SelectedItem.ToString();
                    //Remember we converted the selected item tostring() so the string value got will be compared with that of the database
                    //if true we collect the id and assign it to a variable that will be use in our transfer of data to the webservice during registration
                    if (selectedItem.Equals(el.Name))
                    {
                        QuartersId = el.Id;
                    }
                }

            }
        }




        //GetQuarterAsync

        public async Task<Boolean> GetQuartersAsync()
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
                    //CountryNames.Clear();
                    //var content = await response.Content.ReadAsStringAsync();
                    //CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
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
                error.Message= exc.Message;
            }

            return result;
        }




        //load ActivityDomain
        public async void loadActivityDomain()
        {
            if (await GetActivityDomainAsync())
            {
                ActivityDomains2 = ActivityDomains;
                SelectActivityDomain.ItemsSource = ActivityDomains2;
            }
            else
            {
                ActivityDomains2 = new ObservableCollection<string>
                {
                    "null"
                };
            }
        }




        public async Task<Boolean> GetActivityDomainAsync()
        {
            var result = false;


            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/ActivityDomains"; //103.63.2.147
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
                    //CountryNames.Clear();
                    //var content = await response.Content.ReadAsStringAsync();
                    //CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                    var content = await response.Content.ReadAsStringAsync();
                    ActivityDomainsList = JsonConvert.DeserializeObject<ObservableCollection<ActivityDomain>>(content);


                    foreach (ActivityDomain el in ActivityDomainsList)
                    {
                        ActivityDomains.Add(el.Name);
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

        
        public async Task<Boolean> GetCountriesAsync()
        {
            var result = false;


            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Countries"; //103.63.2.147
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
                    //CountryNames.Clear();
                    //var content = await response.Content.ReadAsStringAsync();
                    //CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
                    var content = await response.Content.ReadAsStringAsync();
                    CountryList = JsonConvert.DeserializeObject<ObservableCollection<Country>>(content);


                    foreach (Country el in CountryList)
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


        //Register the structure
        public async Task<Boolean> RegisterStructureAsync(string name, string pobox, string phone, long activityDomainId, long quarterId)
        {

            var model = new Models.Structure
            {
                Name = name,
                POBOX = pobox,
                Phone = phone,
                //In the connexion form the login was put in session so we can collect back the personne id stored in session to use it when needed with this command below
                PersonneId = Application.Current.Properties["Id"] as string,

                ActivityDomainId = activityDomainId,
                QuarterId = quarterId
            };
            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Structures"; //103.63.2.147
            var httpClient = new HttpClient();
            //data been send to the browser and needs to be serialize
            var jsonLogin = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(jsonLogin);
            //Attach the request header the token
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"] as string);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                structure = JsonConvert.DeserializeObject<Structure>(content);

                if (structure != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Status 201", "Structure registered successfully", "OK");

                }
                else
                {
                     content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }

            }

            return response.IsSuccessStatusCode;

        }


        private void SelectCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectIndex = SelectCountry.SelectedIndex;
            if(selectIndex != -1)
            {
                
                foreach(Country el in CountryList)
                {
                    var selectItem = SelectCountry.SelectedItem.ToString();
                    if (selectItem.Equals(el.Name))
                    {
                        CountryId = el.Id;
                    }
                }
            }
        }

        private void SelectTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectIndex = SelectTown.SelectedIndex;
            if (selectIndex != -1)
            {

                foreach (Town el in TownList)
                {
                    var selectItem = SelectTown.SelectedItem.ToString();
                    if (selectItem.Equals(el.Name))
                    {
                        TownId = el.Id;
                    }
                }
            }
        }

        private void SelectActivityDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectIndex = SelectActivityDomain.SelectedIndex;
            if (selectIndex != -1)
            {

                foreach (ActivityDomain el in ActivityDomainsList)
                {
                    var selectItem = SelectActivityDomain.SelectedItem.ToString();
                    if (selectItem.Equals(el.Name))
                    {
                        ActivityDomainId = el.Id;
                    }
                }
            }
        }

        private async void CreateStructureButton_Clicked(object sender, EventArgs e)
        {
            if( await RegisterStructureAsync(Organisatione.Text, POBOX.Text, Phone.Text, ActivityDomainId, QuartersId ))
            {
               // await Application.Current.MainPage.DisplayAlert("Status 201", "Structure registered successfully", "OK");
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}
