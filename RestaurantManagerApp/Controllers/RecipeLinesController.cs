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
    public class RecipeLinesController : Controller
    {
        private readonly AdvDatabaseProjectContext _context;

        public RecipeLinesController(AdvDatabaseProjectContext context)
        {
            _context = context;
        }

        // GET: RecipeLines
        public async Task<IActionResult> Index()
        {
            var advDatabaseProjectContext = _context.RecipeLines.Include(r => r.RlInvNumNavigation).Include(r => r.RlItemNumNavigation);
            return View(await advDatabaseProjectContext.ToListAsync());
        }

        // GET: RecipeLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeLines = await _context.RecipeLines
                .Include(r => r.RlInvNumNavigation)
                .Include(r => r.RlItemNumNavigation)
                .FirstOrDefaultAsync(m => m.RlNum == id);
            if (recipeLines == null)
            {
                return NotFound();
            }

            return View(recipeLines);
        }

        // GET: RecipeLines/Create
        public IActionResult Create()
        {
            ViewData["RlInvNum"] = new SelectList(_context.Inventory, "InvNum", "InvDesc");
            ViewData["RlItemNum"] = new SelectList(_context.Items, "ItemNum", "ItemName");
            return View();
        }

        // POST: RecipeLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RlNum,RlItemNum,RlInvNum,RlQty")] RecipeLines recipeLines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeLines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RlInvNum"] = new SelectList(_context.Inventory, "InvNum", "InvDesc", recipeLines.RlInvNum);
            ViewData["RlItemNum"] = new SelectList(_context.Items, "ItemNum", "ItemName", recipeLines.RlItemNum);
            return View(recipeLines);
        }

        // GET: RecipeLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeLines = await _context.RecipeLines.FindAsync(id);
            if (recipeLines == null)
            {
                return NotFound();
            }
            ViewData["RlInvNum"] = new SelectList(_context.Inventory, "InvNum", "InvDesc", recipeLines.RlInvNum);
            ViewData["RlItemNum"] = new SelectList(_context.Items, "ItemNum", "ItemName", recipeLines.RlItemNum);
            return View(recipeLines);
        }

        // POST: RecipeLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RlNum,RlItemNum,RlInvNum,RlQty")] RecipeLines recipeLines)
        {
            if (id != recipeLines.RlNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeLines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeLinesExists(recipeLines.RlNum))
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
            ViewData["RlInvNum"] = new SelectList(_context.Inventory, "InvNum", "InvDesc", recipeLines.RlInvNum);
            ViewData["RlItemNum"] = new SelectList(_context.Items, "ItemNum", "ItemName", recipeLines.RlItemNum);
            return View(recipeLines);
        }

        // GET: RecipeLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeLines = await _context.RecipeLines
                .Include(r => r.RlInvNumNavigation)
                .Include(r => r.RlItemNumNavigation)
                .FirstOrDefaultAsync(m => m.RlNum == id);
            if (recipeLines == null)
            {
                return NotFound();
            }

            return View(recipeLines);
        }

        // POST: RecipeLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeLines = await _context.RecipeLines.FindAsync(id);
            _context.RecipeLines.Remove(recipeLines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeLinesExists(int id)
        {
            return _context.RecipeLines.Any(e => e.RlNum == id);
        }
    }
}
