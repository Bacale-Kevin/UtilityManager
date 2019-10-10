using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Models
{
    public class Town
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}
