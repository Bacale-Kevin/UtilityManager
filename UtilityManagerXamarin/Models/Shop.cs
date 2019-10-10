using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UtilityManagerXamarin.Models
{
    public class Shop
    {
        public long Id { get; set; }

        public string Name { get; set; }

       // public IPoint Location { get; set; }

        public DateTime ShopCreatedDate { get; set; }

        public long StructureId { get; set; }
        public Structure Structure { get; set; }

        public long QuarterId { get; set; }
        public Quarter Quarter { get; set; }

        public ImageSource Image
        {
            get
            {
                return ImageSource.FromResource("UtilityManagerXamarin.Images.shopping.jfif");
            }
        }
    }
}
