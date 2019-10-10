using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilityManagerXamarin.Models;
using UtilityManagerXamarin.Parameters;
using UtilityManagerXamarin.Services;
using UtilityManagerXamarin.Utility;
using Xamarin.Forms;

namespace UtilityManagerXamarin.ViewModels
{
    public class OrganisationViewModel : BaseViewModel
    {
        RegisterStructureServices registerStructureServices = new RegisterStructureServices();

        public long Id { get; set; }
        public string Name { get; set; }


        public string POBOX { get; set; }

        public string Phone { get; set; }

        public long ActivityDomainId { get; set; }
        public ActivityDomain ActivityDomain { get; set; }

        
        public long QuarterId { get; set; }
        public Quarter Quarter { get; set; }


        public MonToken montoken = new MonToken();
        public ErrorMessage erreur = new ErrorMessage();
        //added

        //List<Country> CountryList = new List<Country>();
        //public ObservableCollection<string> Items = new ObservableCollection<string>();

        //Get the list of Countries

        //private ObservableCollection<Country> _CountryNames; 
        //public ObservableCollection<Country> CountryNames
        //{
        //    get => _CountryNames;
        //    set
        //    {
        //        _CountryNames = value;
        //        OnPropertyChanged();
        //    }

        //}

        //Get the Country Selected
        //private string _CountrySelected;
        //public string CountrySelected
        //{
        //    get => _CountrySelected;
        //    set
        //    {
        //        _CountrySelected = value;
        //        OnPropertyChanged();
        //    }
        //}






        //public ICommand RegisterStructureCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var isSuccess = await registerStructureServices.RegisterStructureAsync(Name, POBOX, Phone, ActivityDomainId, QuarterId);

        //        });



        //    }
        //}







    }

   
    
}
