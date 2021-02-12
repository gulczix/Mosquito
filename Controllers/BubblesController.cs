using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Komar.Data;
using Komar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Komar.Views.Bubble
{
    public class BubblesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public BubblesController(
            ApplicationDbContext context, 
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bubbles/Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(int biteId)
        {
            var bite = _context.Bites.Find(biteId);
            var user = await _userManager.GetUserAsync(User);
            if (bite == null || user == null)
            {
                return NotFound();
            }
            var bubbles = await _context.Bubbles.Where(b => b.Bubbler == user && b.Bite == bite).ToListAsync();
            if (bubbles.Count == 0)
            {
                var bubble = new Models.Bubble
                {
                    Bite = bite,
                    Bubbler = user,
                    BubbleDate = DateTime.Now
                };
                _context.Add(bubble);
            } 
            else
            {
                _context.Remove(bubbles[0]);
            }

            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
