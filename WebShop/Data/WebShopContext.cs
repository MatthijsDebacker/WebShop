using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data
{
    public class WebShopContext: DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options)
        {

        }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

    }
}
