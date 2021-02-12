using Komar.Data;
using Komar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CustomError()
        {
            ViewBag.Errors = TempData["Errors"];
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DisplayBitesFor(string user, bool all)
        {
            var bitesList = await GetBites(user, all);
            return PartialView("_DisplayBites", bitesList);
        }

        [Authorize]
        public JsonResult LoadBubbleData(int bite)
        {
            var biteObj = _context.Bites.Find(bite);
            var userId = _userManager.GetUserId(User);
            var bubbled = _context.Bubbles.Any(b => b.Bubbler.Id == userId && b.Bite.Id == bite);
            return Json(new { bubbleCount = biteObj.BubbleCount, bubbled });
        }
        [Authorize]
        public async Task<JsonResult> LoadBubblesStatus(string user, bool all)
        {
            var bitesList = await GetBites(user, all);
            var dict = new Dictionary<int, bool>();
            var userId = _userManager.GetUserId(User);
            foreach (var bite in bitesList)
            {
                dict.Add(bite.Id, _context.Bubbles.Any(b => b.Bubbler.Id == userId && b.Bite == bite));
            }
            return Json(dict);
        }

        [Authorize]
        private async Task<List<Bite>> GetBites(string user, bool all)
        {
            if (!all)
            {
                var bites = from b in _context.Bites
                            where b.User.Id == user
                            orderby b.CreationDate descending
                            select b;
                return await bites.ToListAsync();
            }
            else
            {
                var bites = from b in _context.Bites
                            orderby b.CreationDate descending
                            select b;
                return await bites.ToListAsync();
            }
            
        }

    }
}
