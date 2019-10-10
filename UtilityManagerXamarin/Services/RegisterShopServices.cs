using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UtilityManagerXamarin.Parameters;
using UtilityManagerXamarin.Utility;

namespace UtilityManagerXamarin.Services
{
    public class RegisterShopServices
    {
        public MonToken montoken = new MonToken();
        public ErrorMessage erreur = new ErrorMessage();


        public async Task<Boolean> RegisterShopAsync(string name, /*Ipoint lacation*/ DateTime shopCreatedDate, long structureId, long quarterId)
        {
            var model = new Models.Shop
            {
                Name = name,
             //   Location = location,
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

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);
            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Status Successfull", "Shop Registered Successfully", "OK");

            }

            return response.IsSuccessStatusCode;
        }

    }
}
