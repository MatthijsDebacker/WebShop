using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString ="{0:n2}", ApplyFormatInEditMode =true)]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
