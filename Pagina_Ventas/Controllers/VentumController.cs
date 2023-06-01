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
    public class VentumController : Controller
    {
        private readonly TiendaSoftContext _context;

        public VentumController(TiendaSoftContext context)
        {
            _context = context;
        }

        // GET: Ventum
        public async Task<IActionResult> Index()
        {
            var tiendaSoftContext = _context.Venta.Include(v => v.IdPagosNavigation).Include(v => v.IdUsuarioVentaNavigation);
            return View(await tiendaSoftContext.ToListAsync());
        }

        // GET: Ventum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdPagosNavigation)
                .Include(v => v.IdUsuarioVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventum/Create
        public IActionResult Create()
        {
            ViewData["IdPagos"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos");
            ViewData["IdUsuarioVenta"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ventum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdUsuarioVenta,FechaVenta,HoraVenta,IdPagos")] VentumHR ventum)
        {
            if (ModelState.IsValid)
            {
                Ventum ventum1 = new Ventum {
                    IdUsuarioVenta = ventum.IdUsuarioVenta,
                    FechaVenta = ventum.FechaVenta,
                    HoraVenta = ventum.HoraVenta,
                    IdPagos = ventum.IdPagos
                };
                _context.Venta.Add(ventum1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPagos"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", ventum.IdPagos);
            ViewData["IdUsuarioVenta"] = new SelectList(_context.Users, "Id", "Id", ventum.IdUsuarioVenta);
            return View(ventum);
        }

        // GET: Ventum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["IdPagos"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", ventum.IdPagos);
            ViewData["IdUsuarioVenta"] = new SelectList(_context.Users, "Id", "Id", ventum.IdUsuarioVenta);
            return View(ventum);
        }

        // POST: Ventum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdUsuarioVenta,FechaVenta,HoraVenta,IdPagos")] Ventum ventum)
        {
            if (id != ventum.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.IdVenta))
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
            ViewData["IdPagos"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", ventum.IdPagos);
            ViewData["IdUsuarioVenta"] = new SelectList(_context.Users, "Id", "Id", ventum.IdUsuarioVenta);
            return View(ventum);
        }

        // GET: Ventum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdPagosNavigation)
                .Include(v => v.IdUsuarioVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'TiendaSoftContext.Venta'  is null.");
            }
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                _context.Venta.Remove(ventum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(int id)
        {
          return (_context.Venta?.Any(e => e.IdVenta == id)).GetValueOrDefault();
        }
    }
}
