using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        private readonly IWebHostEnvironment _path;
        public JogosController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment path)
        {
            _context = context;
            _userManager = userManager;
            _path = path;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogos.Include(j => j.Loja);
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: Jogos/CreateComment
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(int jogoId, string comentario)
        {

            //variável que vai buscar o Utilizador que escreveu a Review
            var utilizador = _context.Utilizador.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

            //Colocar nos dados da Review os daods introduzidos pelo Utilizador
            var review = new Review
            {
                NotaReview = 0,
                Comentario = comentario,
                DataReview = DateTime.Now,
                Visivel = true,
                Utilizador = utilizador,
                JogoFK = jogoId
            };

            //Adiciona a base de dados a review
            _context.Add(review);
            //Guarda as alterações feitas na base de dados
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = jogoId });
        }

        // POST: Jogos/CreateRating
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRating(int jogoId, double nota)
        {

            //variável que vai buscar o Utilizador que escreveu a Review
            var utilizador = _context.Utilizador.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

            //Colocar nos dados da Review os daods introduzidos pelo Utilizador
            var review = new Review
            {
                NotaReview = nota,
                Comentario = "0",
                DataReview = DateTime.Now,
                Visivel = true,
                Utilizador = utilizador,
                JogoFK = jogoId
            };

            //Adiciona a base de dados a review
            _context.Add(review);
            await _context.SaveChangesAsync();
            //Guarda as alterações feitas na base de dados
            return RedirectToAction(nameof(Details), new { id = jogoId });
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                 .Where(a => a.IdJogo == id)
                                        .Include(a => a.Loja)
                                        .ThenInclude(r => r.LojaJogos)
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
            ViewData["LojaFK"] = new SelectList(_context.Loja, "IdLoja", "IdLoja");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJogo,Nome,Tipo,CategoriaIdade,Nota,DataLancamento,Imagem,Descricao,Media,LinkJogo,LojaFK")] Jogos jogos, IFormFile imagem)
        {
            jogos.Imagem = imagem.FileName;

            var guardarImagem = Path.Combine(_path.WebRootPath, "fotosjogos", imagem.FileName);
            var textoImagem = Path.GetExtension(imagem.FileName);

            if (textoImagem == ".jpg" || textoImagem == ".png" || textoImagem == ".JPG" || textoImagem == ".PNG")
            {
                using (var uploadimg = new FileStream(guardarImagem, FileMode.Create))
                {
                    await imagem.CopyToAsync(uploadimg);

                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(jogos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LojaFK"] = new SelectList(_context.Loja, "IdLoja", "IdLoja", jogos.LojaFK);
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
            ViewData["LojaFK"] = new SelectList(_context.Loja, "IdLoja", "IdLoja", jogos.LojaFK);
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJogo,Nome,Tipo,CategoriaIdade,Nota,DataLancamento,Imagem,Descricao,Media,LinkJogo,LojaFK")] Jogos jogos, IFormFile imagem)
        {
            if (imagem != null)
            {
                jogos.Imagem = imagem.FileName;

                //_webhost.WebRootPath vai ter o path para a pasta wwwroot
                var guardarImagem = Path.Combine(_path.WebRootPath, "fotosjogos", imagem.FileName);

                var textoImagem = Path.GetExtension(imagem.FileName);

                if (textoImagem == ".jpg" || textoImagem == ".png" || textoImagem == ".JPG" || textoImagem == ".PNG")
                {
                    using (var uploadimg = new FileStream(guardarImagem, FileMode.Create))
                    {
                        await imagem.CopyToAsync(uploadimg);

                    }
                }
            }
            else
            {
                Jogos jogosAux = _context.Jogos.Find(jogos.IdJogo);

                _context.Entry<Jogos>(jogosAux).State = EntityState.Detached;


                jogos.Imagem = jogosAux.Imagem;
            }

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
            ViewData["LojaFK"] = new SelectList(_context.Loja, "IdLoja", "IdLoja", jogos.LojaFK);
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
                .Include(j => j.Loja)
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
            var imagem = "";
            int counter = 0;
            foreach (var item in _context.Jogos)
            {
                {
                    if (item.IdJogo == id)
                    {
                        imagem = item.Imagem;
                    }
                }
            }

            foreach (var item in _context.Jogos)
            {
                if (item.Imagem == imagem)
                {
                    counter += 1;
                }
            }

            if (counter <= 1)
            {
                foreach (var item in _context.Jogos)
                {
                    if (item.IdJogo == id)
                    {
                        Jogos jogoAux;
                        jogoAux = item;
                        string nomeImagem = jogoAux.Imagem;
                        var guardarImagem = Path.Combine(_path.WebRootPath, "fotosjogos", nomeImagem);
                        System.IO.File.Delete(guardarImagem);
                    }
                }
            }

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
