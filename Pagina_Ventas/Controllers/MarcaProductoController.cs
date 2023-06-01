using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pagina_Ventas.Models;
using Pagina_Ventas.Models.dbModels;

namespace Pagina_Ventas.Controllers
{
    public class MarcaProductoController : Controller
    {
        private readonly TiendaSoftContext _context;

        public MarcaProductoController(TiendaSoftContext context)
        {
            _context = context;
        }

        // GET: MarcaProducto
        public async Task<IActionResult> Index()
        {
              return _context.MarcaProductos != null ? 
                          View(await _context.MarcaProductos.ToListAsync()) :
                          Problem("Entity set 'TiendaSoftContext.MarcaProductos'  is null.");
        }

        // GET: MarcaProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // GET: MarcaProducto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,NombreMar,DescripcionMar")] MarcaProductoHR marcaProducto)
        {
            if (ModelState.IsValid)
            {
                MarcaProducto marcaProducto1 = new MarcaProducto
                { 
                    NombreMar = marcaProducto.NombreMar,
                    DescripcionMar = marcaProducto.DescripcionMar
                };
                _context.MarcaProductos.Add(marcaProducto1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaProducto);
        }

        // GET: MarcaProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos.FindAsync(id);
            if (marcaProducto == null)
            {
                return NotFound();
            }
            return View(marcaProducto);
        }

        // POST: MarcaProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,NombreMar,DescripcionMar")] MarcaProducto marcaProducto)
        {
            if (id != marcaProducto.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaProductoExists(marcaProducto.IdMarca))
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
            return View(marcaProducto);
        }

        // GET: MarcaProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaProductos == null)
            {
                return NotFound();
            }

            var marcaProducto = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProducto == null)
            {
                return NotFound();
            }

            return View(marcaProducto);
        }

        // POST: MarcaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaProductos == null)
            {
                return Problem("Entity set 'TiendaSoftContext.MarcaProductos'  is null.");
            }
            var marcaProducto = await _context.MarcaProductos.FindAsync(id);
            if (marcaProducto != null)
            {
                _context.MarcaProductos.Remove(marcaProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaProductoExists(int id)
        {
          return (_context.MarcaProductos?.Any(e => e.IdMarca == id)).GetValueOrDefault();
        }
    }
}
