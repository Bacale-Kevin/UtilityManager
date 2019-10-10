using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Models
{
    public class Structure
    {
        public long Id { get; set; }
        public string Name { get; set; }
        

        public string POBOX { get; set; }

        public string Phone { get; set; }

        public string PersonneId { get; set; }

        public long ActivityDomainId { get; set; }
        public ActivityDomain ActivityDomain { get; set; }


       

        public long QuarterId { get; set; }
        public Quarter Quarter { get; set; }
    }
}
