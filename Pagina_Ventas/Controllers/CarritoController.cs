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
    public class CarritoController : Controller
    {
        private readonly TiendaSoftContext _context;

        public CarritoController(TiendaSoftContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public async Task<IActionResult> Index()
        {
            var tiendaSoftContext = _context.Carritos.Include(c => c.IdProdCarritoNavigation).Include(c => c.IdUsuarioCarritoNavigation);
            return View(await tiendaSoftContext.ToListAsync());
        }

        // GET: Carrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.IdProdCarritoNavigation)
                .Include(c => c.IdUsuarioCarritoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioCarrito == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carrito/Create
        public IActionResult Create()
        {
            ViewData["IdProdCarrito"] = new SelectList(_context.Productos, "IdProd", "IdProd");
            ViewData["IdUsuarioCarrito"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos");
            return View();
        }

        // POST: Carrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioCarrito,IdProdCarrito,CantidadCarrito")] CarritoHR carrito)
        {
            if (ModelState.IsValid)
            {
                Carrito carrito1 = new Carrito
                {
                    IdProdCarrito = carrito.IdProdCarrito,
                    CantidadCarrito = carrito.CantidadCarrito
                };
                _context.Carritos.Add(carrito1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProdCarrito"] = new SelectList(_context.Productos, "IdProd", "IdProd", carrito.IdProdCarrito);
            ViewData["IdUsuarioCarrito"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", carrito.IdUsuarioCarrito);
            return View(carrito);
        }

        // GET: Carrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["IdProdCarrito"] = new SelectList(_context.Productos, "IdProd", "IdProd", carrito.IdProdCarrito);
            ViewData["IdUsuarioCarrito"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", carrito.IdUsuarioCarrito);
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarioCarrito,IdProdCarrito,CantidadCarrito")] Carrito carrito)
        {
            if (id != carrito.IdUsuarioCarrito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.IdUsuarioCarrito))
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
            ViewData["IdProdCarrito"] = new SelectList(_context.Productos, "IdProd", "IdProd", carrito.IdProdCarrito);
            ViewData["IdUsuarioCarrito"] = new SelectList(_context.Pagos, "IdPagos", "IdPagos", carrito.IdUsuarioCarrito);
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.IdProdCarritoNavigation)
                .Include(c => c.IdUsuarioCarritoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioCarrito == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carritos == null)
            {
                return Problem("Entity set 'TiendaSoftContext.Carritos'  is null.");
            }
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
          return (_context.Carritos?.Any(e => e.IdUsuarioCarrito == id)).GetValueOrDefault();
        }
    }
}
