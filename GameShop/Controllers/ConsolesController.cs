using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameShop.Models;

namespace GameShop.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly GameShopContext _context;

        public ConsolesController(GameShopContext context)
        {
            _context = context;    
        }

        // GET: Consoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Console.ToListAsync());
        }

        // GET: Consoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _context.Console
                .SingleOrDefaultAsync(m => m.ID == id);
            if (consoles == null)
            {
                return NotFound();
            }

            return View(consoles);
        }

        // GET: Consoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price")] Consoles consoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consoles);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consoles);
        }

        // GET: Consoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _context.Console.SingleOrDefaultAsync(m => m.ID == id);
            if (consoles == null)
            {
                return NotFound();
            }
            return View(consoles);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price")] Consoles consoles)
        {
            if (id != consoles.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsolesExists(consoles.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(consoles);
        }

        // GET: Consoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoles = await _context.Console
                .SingleOrDefaultAsync(m => m.ID == id);
            if (consoles == null)
            {
                return NotFound();
            }

            return View(consoles);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consoles = await _context.Console.SingleOrDefaultAsync(m => m.ID == id);
            _context.Console.Remove(consoles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsolesExists(int id)
        {
            return _context.Console.Any(e => e.ID == id);
        }
    }
}
