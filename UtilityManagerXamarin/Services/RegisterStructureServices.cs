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
    class RegisterStructureServices
    {
        public MonToken montoken = new MonToken();
        public ErrorMessage erreur = new ErrorMessage();

        


        public async Task<Boolean> RegisterStructureAsync( string name, string pobox, string phone, string personneId, long activityDomainId, long quarterId)
        {
            
            var model = new Models.Structure
            {
                Name = name,
                POBOX = pobox,
                Phone = phone,
                PersonneId = personneId,
                ActivityDomainId = activityDomainId,
                QuarterId = quarterId
            };
            Parametre parametre = new Parametre();
            string BaseUrl = parametre.ServeurName + "/api/Structures"; //103.63.2.147
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
                await App.Current.MainPage.DisplayAlert("Status Successfull","Structure Registered Successfully", "OK");
                
            }

            return response.IsSuccessStatusCode;
            
        }

    }
}
