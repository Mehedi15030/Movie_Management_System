using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Movie_Ticket_Management.Data;
using Online_Movie_Ticket_Management.Models;

namespace Online_Movie_Ticket_Management.Controllers
{
    [Authorize]
    public class ActressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actresses
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actress.ToListAsync());
        }

        // GET: Actresses/Details/5
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actress = await _context.Actress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actress == null)
            {
                return NotFound();
            }

            return View(actress);
        }

        // GET: Actresses/Create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfilePictureURL,FullName,Bio")] Actress actress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actress);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Actresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actress = await _context.Actress.FindAsync(id);
            if (actress == null)
            {
                return NotFound();
            }
            return View(actress);
        }

        // POST: Actresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actress actress)
        {
            if (id != actress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActressExists(actress.Id))
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
            return View(actress);
        }

        // GET: Actresses/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actress = await _context.Actress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actress == null)
            {
                return NotFound();
            }

            return View(actress);
        }

        // POST: Actresses/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actress = await _context.Actress.FindAsync(id);
            if (actress != null)
            {
                _context.Actress.Remove(actress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActressExists(int id)
        {
            return _context.Actress.Any(e => e.Id == id);
        }
    }
}
