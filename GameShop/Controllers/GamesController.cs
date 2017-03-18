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
    public class GamesController : Controller
    {
        private readonly GameShopContext _context;

        public GamesController(GameShopContext context)
        {
            _context = context;    
        }

        // GET: Games
        public async Task<IActionResult> Index(string gameGenre, string searchString, string gameConsole)
        {

            IQueryable<string> genreQuery = from m in _context.Game
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> consolesQuery = from m in _context.Console
                                            orderby m.Name
                                            select m.Name;

            var games = from m in _context.Game
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(gameGenre))
            {
                games = games.Where(x => x.Genre == gameGenre);
            }

            if (!String.IsNullOrEmpty(gameConsole))
            {
                games = games.Where(x => x.Console == gameConsole);
            }

            var gameGenreVM = new GameGenreViewModel();
            gameGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            gameGenreVM.consoles = new SelectList(await consolesQuery.Distinct().ToListAsync());
            gameGenreVM.games = await games.ToListAsync();

            return View(gameGenreVM);

        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.SingleOrDefaultAsync(m => m.ID == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public async Task<IActionResult> Create()
        {

            IQueryable<string> consolesQuery = from m in _context.Console
                                               orderby m.Name
                                               select m.Name;

            ViewBag.consoles = new SelectList(await consolesQuery.Distinct().ToListAsync());

            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Console")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.SingleOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Console")] Game game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.ID))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .SingleOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.SingleOrDefaultAsync(m => m.ID == id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.ID == id);
        }
    }
}
