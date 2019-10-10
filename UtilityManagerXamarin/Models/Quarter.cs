using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Models
{
    public class Quarter
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long TownId { get; set; }
        public Town Town { get; set; }
    }
}
