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
    public class ShoppingBagsController : Controller
    {
        private readonly WebShopContext _context;

        public ShoppingBagsController(WebShopContext context)
        {
            _context = context;
        }

        // GET: ShoppingBags
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingBags.ToListAsync());
        }

        // GET: ShoppingBags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBag = await _context.ShoppingBags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingBag == null)
            {
                return NotFound();
            }

            return View(shoppingBag);
        }
    }
}
