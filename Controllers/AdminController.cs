using Komar.Data;
using Komar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public AdminController(
            ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(User);
            var users = (from u in _context.Users
                        where u.Id != currentUserId
                        select u).ToList();
            var dict = new Dictionary<string, bool>();
            var adminRole = 
                _context.Roles.Where(role => role.Name == "Administrator")
                              .FirstOrDefault();
            foreach (var user in users)
            {
                dict.Add(user.Id, _context.UserRoles.Any(
                    userRole => userRole.UserId == user.Id
                                && userRole.RoleId == adminRole.Id));
            }
            ViewBag.RoleDict = dict;
            return View(users);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult RemoveAdmin(string ID)
        {
            var adminRole =
                _context.Roles.Where(role => role.Name == "Administrator")
                              .FirstOrDefault();
            var user = _context.Users.Find(ID);
            var userRole = _context.UserRoles.Find(user.Id, adminRole.Id);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult MakeAdmin(string ID)
        {
            var adminRole =
                _context.Roles.Where(role => role.Name == "Administrator")
                              .FirstOrDefault();
            var user = _context.Users.Find(ID);
            var userRole = _context.UserRoles.Find(user.Id, adminRole.Id);
            if (userRole == null)
            {
                _context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = adminRole.Id
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
