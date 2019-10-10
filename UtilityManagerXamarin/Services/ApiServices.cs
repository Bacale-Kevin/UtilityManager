using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UtilityManagerXamarin.Parameters;
using UtilityManagerXamarin.Utility;
using UtilityManagerXamarin.Views;
using Xamarin.Forms;
using System.Collections;
using UtilityManagerXamarin.Models;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Services;

namespace UtilityManagerXamarin.Services
{
    class ApiServices
    {
        public MonToken montoken = new MonToken();
        public ErrorMessage erreur = new ErrorMessage();
        //added
        List<Country> CountryList = new List<Country>();
        public ObservableCollection<string> Items { get; set; }

        public Personne employee = new Personne();
        public ErrorMessage error = new ErrorMessage();
        Parametre parametre = new Parametre();

        public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string password, string Picture, string phone, string residence, string idCardNumber, string sex)
        {
            var client = new HttpClient();
            var model = new Models.RegisterViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,

                PhoneNumber = phone,
                Residence = residence,
                IDCardNumber = idCardNumber,
                Sex = sex,
                Picture = "aaf"


            };
            
            string MyUrl = "http://192.168.43.101/TeamIsUMProject/register";

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(new Uri(MyUrl), content);

            

            return response.IsSuccessStatusCode;
        }


        //Login Users
        public async Task<Boolean> ConnexionAsync(string username, string password)
        {
            // **** added code
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            PopupNavigation.PushAsync(new PopUp(), true);
            bool result = false;
            Log loginresult = new Log() { Username = username, Password = password };
            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/login"; //103.63.2.147
            var httpClient = new HttpClient();
            //data been send to the browser and needs to be serialize
            var jsonLogin = JsonConvert.SerializeObject(loginresult);
            HttpContent httpContent = new StringContent(jsonLogin);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //recuperation du token mis en session
            //string token = Application.Current.Properties["token"] as string;
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                montoken = JsonConvert.DeserializeObject<MonToken>(content);
                if (montoken != null )
                {
                    Application.Current.Properties.Clear();
                    //Here we collect the return type of the webservice with the exact attributes name as the return type given by the web service(Postman)...
                    Application.Current.Properties.Add("Token", montoken);
                    Application.Current.Properties.Add("Id", montoken.id);
                    Application.Current.Properties.Add("Email", montoken.Username);
                    Application.Current.Properties.Add("token", montoken.token);
                    result = true;
                    //added
                    PopupNavigation.PopAsync();
                    Application.Current.MainPage = new MainPage();
                }
            }
            else
            {
                erreur.Message = await response.Content.ReadAsStringAsync();
                //added
                PopupNavigation.PopAsync();

                await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email or Password", "OK");
                result = false;

            }
            return result;
        }



        //Register Employee
        public async Task<bool> RegisterEmployeeAsync(string firstName, string lastName, string email, string password, string Picture, string phone, string residence, string idCardNumber, string sex)
        {

            var model = new Models.RegisterViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,

                PhoneNumber = phone,
                Residence = residence,
                IDCardNumber = idCardNumber,
                Sex = sex,
                Picture = "aaf"


            };
            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/Employee"; //103.63.2.147
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
                employee = JsonConvert.DeserializeObject<Personne>(content);
                if (employee != null)
                {
                    await App.Current.MainPage.DisplayAlert("Status Successfull", "An Employee Registered Successfully", "OK");

                }
                else
                {
                    content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }

            }


            return response.IsSuccessStatusCode;
        }


        //
        //public async void GetCountriesAsync()
        //{



        //    Parametre parametre = new Parametre();
        //    string BaseUrl = parametre.ServeurName + "/api/Countries"; //103.63.2.147
        //    var httpClient = new HttpClient();
        //    //Tell Xamarin to accept data in json format
        //    httpClient.DefaultRequestHeaders.Accept
        //             .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = await httpClient.GetAsync(new Uri(BaseUrl));
        //    //added
        //    if (response.IsSuccessStatusCode)
        //    {
        //        CountryList.Clear();
        //        var content = await response.Content.ReadAsStringAsync();
        //        CountryList = JsonConvert.DeserializeObject<List<Country>>(content);
        //        Items = new ObservableCollection<string>
        //        {

        //        };
        //        foreach (var country in CountryList)
        //        {
        //            Items.Add(country.Name);
        //        }
        //    }


        //    return response.IsSuccessStatusCode;
        //}







        //public void CountryNames()
        //{
        //    Items = new ObservableCollection<string>
        //    {

        //    };
        //    foreach(var country in CountryList)
        //    {
        //        Items.Add(country.Name);
        //    }
        //    SelectCountry.ItemsSource = Items;
        //}
    }
}
