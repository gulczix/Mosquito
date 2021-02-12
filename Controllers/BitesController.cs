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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace Komar.Controllers
{
    public class BitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _user_manager;

        public BitesController(ApplicationDbContext context, UserManager<User> user_manager)
        {
            _context = context;
            _user_manager = user_manager;
        }

        // GET: Bites
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index(string searchString)
        {
            var bites = from m in _context.Bites select m;  

            if (!String.IsNullOrEmpty(searchString))
            {
                bites = bites.Where(s => s.Text.Contains(searchString));
            }
            
            return View(await bites.ToListAsync());
        }

        // GET: Bites/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bite = await _context.Bites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bite == null)
            {
                return NotFound();
            }

            return View(bite);
        }

        // GET: Bites/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Text")] Bite bite)
        {
            bite.CreationDate = DateTime.Now;
            bite.User = await _context.Users.FindAsync(_user_manager.GetUserId(User));
            ModelState.Clear();
            if(await TryUpdateModelAsync(bite) && ModelState.IsValid)
            {
                _context.Add(bite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bite);
        }

        [HttpPost]
        [Authorize]
        public async Task<int> SubmitBite(string biteText)
        {
            var bite = new Bite
            {
                Text = biteText,
                CreationDate = DateTime.Now,
                User = await _context.Users.FindAsync(_user_manager.GetUserId(User))
            };
            var entry = _context.Add(bite);
            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        // GET: Bites/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bite = await _context.Bites.FindAsync(id);
            if (bite == null)
            {
                return NotFound();
            }
            return View(bite);
        }

        // POST: Bites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text")] Bite bite)
        {

            if (id != bite.Id)
            {
                return NotFound();
            }

                try
                {
                    var oldBite = _context.Bites.Find(id);
                    oldBite.Text = bite.Text;
                    _context.Update(oldBite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiteExists(bite.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Bites/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bite = await _context.Bites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bite == null)
            {
                return NotFound();
            }

            return View(bite);
        }

        // POST: Bites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bite = await _context.Bites.FindAsync(id);
            _context.Bites.Remove(bite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiteExists(int id)
        {
            return _context.Bites.Any(e => e.Id == id);
        }
    }
}
