using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebShopContext context)
        {
            var rand = new Random();
            context.Database.EnsureCreated();

            if(!context.Products.Any())
            {
                for (int i = 1; i < 20; i++)
                {
                    context.Products.Add(new Product { Name = $"Product_{i}", Price = (decimal)(rand.NextDouble() * 100.0), Image = $"images/bikes/Bike_0{rand.Next(1, 5)}.jpg" });
                }
            }

            context.SaveChanges();

            if(!context.Costumers.Any())
            {
                context.Costumers.Add(new Costumer { FirstName = "Matthijs", Name = "Debacker", CostumerShoppingBags = new List<ShoppingBag>() });
            }

            context.SaveChanges();
        }
    }
}
