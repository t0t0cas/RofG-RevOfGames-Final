using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabPrático.Data;
using TrabPrático.Models;

namespace TrabPrático.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _caminho;
        public JogosAPI(ApplicationDbContext context, IWebHostEnvironment caminho)
        {
            _context = context;
            _caminho = caminho;
        }
        
        /// <summary>
        /// Lista os jogos existentes na BD
        /// </summary>
        /// <returns></returns>
        // GET: api/JogosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogosAPIViewModel>>> GetJogos()
        {
            //Variável que vai listar os jogos existentes na BD
            var listaJogos = await _context.Jogos
                                 .Select(j => new JogosAPIViewModel { 
                                         IdJogo = j.IdJogo,
                                         NomeJogo = j.Nome,
                                         ImagemFoto = j.Imagem,
                                         NotaJogo = j.Nota,
                                         DescricaoJogo = j.Descricao})
                                 .OrderBy(j=>j.IdJogo)
                                 .ToListAsync();
            return listaJogos;
        }

        // GET: api/JogosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogos>> GetJogos(int id)
        {
            var jogos = await _context.Jogos.FindAsync(id);

            if (jogos == null)
            {
                return NotFound();
            }

            return jogos;
        }

        // PUT: api/JogosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogos(int id, Jogos jogos)
        {
            if (id != jogos.IdJogo)
            {
                return BadRequest();
            }

            _context.Entry(jogos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Endpoint para receber os dados do Formulário de adição de novas fotografias
        /// </summary>
        /// <param name="jogos"></param>
        /// <param name="UpFotografia"></param>
        /// <returns></returns>
        // POST: api/JogosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jogos>> PostJogos([FromForm]Jogos jogos, IFormFile UpFotografia)
        {

            jogos.Imagem = "";
            string localizacao = _caminho.WebRootPath;
            var nomeDaImagem = Path.Combine(localizacao, "fotosJogos", UpFotografia.FileName);
            //jogos.Imagem = Path.GetExtension(UpFotografia.FileName).ToLower();
            var teste = new FileStream(nomeDaImagem, FileMode.Create);
            await UpFotografia.CopyToAsync(teste);
            jogos.Imagem = UpFotografia.FileName;
            
            _context.Jogos.Add(jogos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogos", new { id = jogos.IdJogo }, jogos);
        }

        // DELETE: api/JogosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogos(int id)
        {
            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }

            _context.Jogos.Remove(jogos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogosExists(int id)
        {
            return _context.Jogos.Any(e => e.IdJogo == id);
        }
    }
}
