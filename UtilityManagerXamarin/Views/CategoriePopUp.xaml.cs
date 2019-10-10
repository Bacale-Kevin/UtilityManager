using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class CategoriePopUp: PopupPage 
	{
		public CategoriePopUp ()
		{
			InitializeComponent ();
		}

        public ErrorMessage error = new ErrorMessage();

        Category category = new Category();

        //Register a shop
        public async Task<Boolean> RegisterCategoryAsync(string name)
        {
            var model = new Models.Category
            {
                Name = name
            };

            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Categories"; //103.63.2.147
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
                category = JsonConvert.DeserializeObject<Category>(content);
                if (category != null)
                {
                    await App.Current.MainPage.DisplayAlert("Status Successfull", "Category Registered Successfully", "OK");

                }
                else
                {
                    content = await response.Content.ReadAsStringAsync();
                    error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }

            }


            return response.IsSuccessStatusCode;
        }

        private async void SaveCategoryButton_Clicked(object sender, EventArgs e)
        {
            if (await RegisterCategoryAsync(Name.Text))
            {
                await PopupNavigation.Instance.PopAsync(true);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Cancel");
            }
            
        }
    }
}