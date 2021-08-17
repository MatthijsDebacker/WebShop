using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products;
        public ProductController()
        {
            Random rand = new Random();
            products = new List<Product>();

            for (int i = 1; i < 5; i++)
            {
                products.Add(new Product { ID = i, Name = "Bike_0" + i, Price = (decimal)(rand.NextDouble() * 100.0), Image = $"images/bikes/Bike_0{i}.jpg" });
            }
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = products.Where(p => p.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}
