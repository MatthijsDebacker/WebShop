using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ShoppingBag
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int SBCostumerID { get; set; }
        public IEnumerable<ShoppingItem> SBShoppingItems { get; set; }
    }
}
