using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class Employee : TabbedPage
    {
        public Employee()
        {
            InitializeComponent();
        }

        public Personne shop = new Personne();
        public ErrorMessage error = new ErrorMessage();
        Parametre parametre = new Parametre();


        //public async Task<bool> RegisterEmployeeAsync(string firstName, string lastName, string email, string password, string Picture, string phone, string residence, string idCardNumber, string sex)
        //{

        //    var model = new Models.RegisterViewModel
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Email = email,
        //        Password = password,

        //        PhoneNumber = phone,
        //        Residence = residence,
        //        IDCardNumber = idCardNumber,
        //        Sex = sex,
        //        Picture = "aaf"


        //    };
        //    Parametre parametre = new Parametre();
        //    string BaseUrl = parametre.ServeurName + "/Employee"; //103.63.2.147
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
        //        shop = JsonConvert.DeserializeObject<Personne>(content);
        //        if (shop != null)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Status Successfull", "An Employee Registered Successfully", "OK");

        //        }
        //        else
        //        {
        //            content = await response.Content.ReadAsStringAsync();
        //            error = JsonConvert.DeserializeObject<ErrorMessage>(content);
        //        }

        //    }


        //    return response.IsSuccessStatusCode;
        //}

        //private async void RegisterEmployee_Clicked(object sender, EventArgs e)
        //{
        //    if (await RegisterEmployeeAsync(Firstname.Text, Lastname.Text, Email.Text, Password.Text, Phone.Text, Residence.Text, IDCard.Text, pickers.t))
        //    {

        //    }
        //    else
        //    {
        //        await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
        //    }
        //}
    }
}