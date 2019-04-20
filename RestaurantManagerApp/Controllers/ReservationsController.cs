using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantManagerApp.Models;

namespace RestaurantManagerApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AdvDatabaseProjectContext _context;

        public ReservationsController(AdvDatabaseProjectContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var advDatabaseProjectContext = _context.Reservations.Include(r => r.RCnumNavigation);
            return View(await advDatabaseProjectContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .Include(r => r.RCnumNavigation)
                .FirstOrDefaultAsync(m => m.RNum == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["RCnum"] = new SelectList(_context.Customers, "CNum", "CAddy");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RNum,RDate,RTime,RCnum,RSubtotal,RPaid,RTable")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RCnum"] = new SelectList(_context.Customers, "CNum", "CAddy", reservations.RCnum);
            return View(reservations);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }
            ViewData["RCnum"] = new SelectList(_context.Customers, "CNum", "CAddy", reservations.RCnum);
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RNum,RDate,RTime,RCnum,RSubtotal,RPaid,RTable")] Reservations reservations)
        {
            if (id != reservations.RNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationsExists(reservations.RNum))
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
            ViewData["RCnum"] = new SelectList(_context.Customers, "CNum", "CAddy", reservations.RCnum);
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .Include(r => r.RCnumNavigation)
                .FirstOrDefaultAsync(m => m.RNum == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(int id)
        {
            return _context.Reservations.Any(e => e.RNum == id);
        }
    }
}
