using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        private List<User> users;

        public UserController()
        {
            users = new List<User>();
            users.Add(new User { Email = "matthijsdebacker@hotmail.com", UserName = "Matthijs", Password = "SomePassword" });
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(User user)
        {
            if(ModelState.IsValid)
            {
                foreach (var u in users)
                {

                }
            }
            return View(user);
        }
    }
}
