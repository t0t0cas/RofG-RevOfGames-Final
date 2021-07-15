using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabPrático.Data;
using TrabPrático.Models;

namespace TrabPrático.Controllers
{
    public class LojasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _path;
        public LojasController(ApplicationDbContext context, IWebHostEnvironment path)
        {
            _context = context;
            _path = path;
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loja.ToListAsync());
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Where(a => a.IdLoja == id)
                                       .Include(r => r.LojaJogos)
                                       .FirstOrDefaultAsync();
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: Lojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoja,Nome,ImagemLoja,Link")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoja,Nome,ImagemLoja,Link")] Loja loja, IFormFile imagem)
        {
            if (imagem != null)
            {
                loja.ImagemLoja = imagem.FileName;

                //_webhost.WebRootPath vai ter o path para a pasta wwwroot
                var guardarImagem = Path.Combine(_path.WebRootPath, "fotoloja", imagem.FileName);

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
                Loja lojaAux = _context.Loja.Find(loja.IdLoja);

                _context.Entry<Loja>(lojaAux).State = EntityState.Detached;


                loja.ImagemLoja = lojaAux.ImagemLoja;
            }

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
