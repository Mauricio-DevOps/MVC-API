using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste.Api;

namespace Teste.Models
{
    public class ImovelsController : Controller
    {
        private readonly Contexto _context;

        public static ExecutaApi executaApi = new ExecutaApi();

        public ImovelsController(Contexto context)
        {
            _context = context;
        }

        // GET: Imovels
        public async Task<IActionResult> Index()
        {
              return _context.Imovel != null ? 
                          View(await _context.Imovel.ToListAsync()) :
                          Problem("Entity set 'Contexto.Imovel'  is null.");
        }

        // GET: Imovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imovel == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoImovel,ValorVenda,ValorLocacao,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Cep")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                //Criando Via API
                Api.ExecutaApi.ConsultaVerboPost<Imovel>("https://localhost:7018/Imoveis/AdicionarImovel",imovel);
                //_context.Add(imovel);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        // GET: Imovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imovel == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }

        // POST: Imovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoImovel,ValorVenda,ValorLocacao,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Cep")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Api.ExecutaApi.ConsultaVerboPost<Imovel>("https://localhost:7018/Imoveis/EditarImovel/"+imovel.Id, imovel);
                    //_context.Update(imovel);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            return View(imovel);
        }

        // GET: Imovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imovel == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imovel == null)
            {
                return Problem("Entity set 'Contexto.Imovel'  is null.");
            }
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel != null)
            {
                Api.ExecutaApi.ConsultaVerboGet("https://localhost:7018/Imoveis/RemoverImovel?id="+imovel.Id);

                //_context.Imovel.Remove(imovel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
          return (_context.Imovel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
