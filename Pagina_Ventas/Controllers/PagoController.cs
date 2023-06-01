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
    public class PagoController : Controller
    {
        private readonly TiendaSoftContext _context;

        public PagoController(TiendaSoftContext context)
        {
            _context = context;
        }

        // GET: Pago
        public async Task<IActionResult> Index()
        {
              return _context.Pagos != null ? 
                          View(await _context.Pagos.ToListAsync()) :
                          Problem("Entity set 'TiendaSoftContext.Pagos'  is null.");
        }

        // GET: Pago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .FirstOrDefaultAsync(m => m.IdPagos == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagos,MetodosPagoPagos,DescripcionPagos")] PagoHR pago)
        {
            if (ModelState.IsValid)
            {
                Pago pago1 = new Pago {
                    MetodosPagoPagos = pago.MetodosPagoPagos,
                    DescripcionPagos = pago.DescripcionPagos
                };
                _context.Pagos.Add(pago1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        // GET: Pago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            return View(pago);
        }

        // POST: Pago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagos,MetodosPagoPagos,DescripcionPagos")] Pago pago)
        {
            if (id != pago.IdPagos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.IdPagos))
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
            return View(pago);
        }

        // GET: Pago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .FirstOrDefaultAsync(m => m.IdPagos == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagos == null)
            {
                return Problem("Entity set 'TiendaSoftContext.Pagos'  is null.");
            }
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return (_context.Pagos?.Any(e => e.IdPagos == id)).GetValueOrDefault();
        }
    }
}
