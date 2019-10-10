using System;

namespace UtilityManagerXamarin.Models
{
    public class Item
    {
        public long Id { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public string PersonneId { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}