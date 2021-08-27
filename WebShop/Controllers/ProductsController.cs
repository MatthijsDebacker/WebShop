using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebShopContext _context;

        public ProductsController(WebShopContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParameter"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParameter"] = sortOrder == "Price" ? "price_desc" : "price";

            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            
            var products = from p in _context.Products select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult AddToCart(int productID, int quantity)
        {
            var user = _context.Costumers.FirstOrDefault();

            if (user.CostumerShoppingBags == null || !user.CostumerShoppingBags.Any())
            {
                user.CostumerShoppingBags = new List<ShoppingBag>() { new ShoppingBag { Date = DateTime.Now, SBCostumerID = user.ID } };
            }

            try
            {

                _context.ShoppingItems.Add(new ShoppingItem { Quantity = quantity, SBagID = user.CostumerShoppingBags.FirstOrDefault().ID, SIProductID = productID });
                _context.SaveChanges();
                return RedirectToAction("Details", "Costumers", new { id = user.ID });
            }
            catch (Exception)
            {
                return RedirectToAction("Details", "Products", new { id = productID });
            }
           
        }
    }
}
