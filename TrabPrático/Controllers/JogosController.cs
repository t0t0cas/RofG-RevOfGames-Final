using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabPrático.Data;
using TrabPrático.Models;

namespace TrabPrático.Controllers
{

    public class JogosController : Controller
    {
        //Contéudo da base de dados
        private readonly ApplicationDbContext _context;
        
        private readonly UserManager<IdentityUser> _userManager;

        public JogosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogos.ToListAsync());
        }

        // POST: Jogos/CreateRating
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(int jogoId, double nota, string comentario)
        {
            //variável que vai buscar o Utilizador que escreveu a Review
            var utilizador = _context.Utilizador.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();
            
            //Colocar nos dados da Review os daods introduzidos pelo Utilizador
            var review = new Review {
                JogoFK = jogoId,
                NotaReview = nota,
                Comentario = comentario,
                DataReview = DateTime.Now,
                Visivel = true,
                Utilizador = utilizador
            };
            
            //Adiciona a base de dados a review
            _context.Add(review);
            //Guarda as alterações feitas na base de dados
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = jogoId});
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateComment(int jogoId, string comentario)
        //{

        //    var utilizador = _context.Utilizador.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

        //    var comment = new Review
        //    {
        //        JogoFK = jogoId,
        //        Comentario = comentario,
        //        DataReview = DateTime.Now,
        //        IdReview = 0,
        //        Visivel = true,
        //        Utilizador = utilizador
        //    };

        //    _context.Add(comment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Details), new { id = jogoId });
        //}


        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                                       .Where(a => a.IdJogo == id)
                                       .Include(a => a.JogosReview)
                                       .ThenInclude(r => r.Utilizador)
                                       .FirstOrDefaultAsync();
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJogo,Nome,Tipo,CategoriaIdade,Nota,DataLancamento,Imagem,Descricao,Media")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJogo,Nome,Tipo,CategoriaIdade,Nota,DataLancamento,Imagem,Descricao,Media")] Jogos jogos)
        {
            if (id != jogos.IdJogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogosExists(jogos.IdJogo))
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
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .FirstOrDefaultAsync(m => m.IdJogo == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogos = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
            return _context.Jogos.Any(e => e.IdJogo == id);
        }
    }
}
