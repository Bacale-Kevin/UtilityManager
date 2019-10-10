using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UtilityManagerXamarin.Models;
using UtilityManagerXamarin.Services;
using Xamarin.Forms;

namespace UtilityManagerXamarin.ViewModels
{
    class ShopViewModel : BaseViewModel
    {

        RegisterShopServices registerShopServices = new RegisterShopServices();

        public long Id { get; set; }

        public string Name { get; set; }

       // public IPoint Location { get; set; }

        public DateTime ShopCreatedDate { get; set; }

        public long StructureId { get; set; }
        public Structure Structure { get; set; }

        public long QuarterId { get; set; }
        public Quarter Quarter { get; set; }

        public ICommand RegisterShopCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await registerShopServices.RegisterShopAsync(Name, /*Location*/ ShopCreatedDate, StructureId, QuarterId);

                });



            }
        }
    }
    
}
