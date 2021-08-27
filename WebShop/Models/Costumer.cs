using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Costumer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<ShoppingBag> CostumerShoppingBags { get; set; }
    }
}
