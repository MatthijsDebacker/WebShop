using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ShoppingItem
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int SIProductID { get; set; }
        public int SBagID { get; set; }
    }
}
