using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabPrático.Data;
using TrabPrático.Models;

namespace TrabPrático.Controllers
{
    //[Authorize]
    public class LojasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LojasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Loja.Include(l => l.Jogo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.Jogo)
                .FirstOrDefaultAsync(m => m.IdLoja == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: Lojas/Create
        public IActionResult Create()
        {
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "IdJogo", "IdJogo");
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoja,Nome,ImagemLoja,Link,JogoFK")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "IdJogo", "IdJogo", loja.JogoFK);
            return View(loja);
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "IdJogo", "IdJogo", loja.JogoFK);
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoja,Nome,ImagemLoja,Link,JogoFK")] Loja loja)
        {
            if (id != loja.IdLoja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojaExists(loja.IdLoja))
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
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "IdJogo", "IdJogo", loja.JogoFK);
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.Jogo)
                .FirstOrDefaultAsync(m => m.IdLoja == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loja = await _context.Loja.FindAsync(id);
            _context.Loja.Remove(loja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojaExists(int id)
        {
            return _context.Loja.Any(e => e.IdLoja == id);
        }
    }
}
