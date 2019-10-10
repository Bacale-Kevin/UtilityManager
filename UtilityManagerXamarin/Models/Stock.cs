using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Models
{
    public class Stock
    {
        long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime StockCreationDate { get; set; }
        public decimal Price { get; set; }

        public long ShopId { get; set; }
        public Shop Shop { get; set; }

        public string PersonneId { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
