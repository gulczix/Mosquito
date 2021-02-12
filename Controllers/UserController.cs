using Komar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index(string ID)
        {
            var user = _context.Users.Find(ID);
            if (user != null)
            {
                return View(user);
            }
            TempData["Errors"] = new string[] { $"User {ID} not found" };
            
            return RedirectToAction(nameof(HomeController.CustomError), "Home");
        }
    }
}
