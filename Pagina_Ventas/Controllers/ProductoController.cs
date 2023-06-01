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
    public class ProductoController : Controller
    {
        private readonly TiendaSoftContext _context;

        public ProductoController(TiendaSoftContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var tiendaSoftContext = _context.Productos.Include(p => p.EstadoProdNavigation).Include(p => p.IdCatProdNavigation).Include(p => p.MarcaProdNavigation);
            return View(await tiendaSoftContext.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.EstadoProdNavigation)
                .Include(p => p.IdCatProdNavigation)
                .Include(p => p.MarcaProdNavigation)
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["EstadoProd"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat");
            ViewData["MarcaProd"] = new SelectList(_context.MarcaProductos, "IdMarca", "IdMarca");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProd,IdCatProd,MarcaProd,CostoProd,ExistenciaProd,DescuentoProd,PrecioProd,EstadoProd,DescripcionProd")] ProductoHR producto)
        {
            if (ModelState.IsValid)
            {   
                Producto producto1 = new Producto { 
                    IdCatProd = producto.IdCatProd,
                    MarcaProd = producto.MarcaProd,
                    CostoProd = producto.CostoProd, 
                    ExistenciaProd = producto.ExistenciaProd,
                    DescuentoProd = producto.DescuentoProd,
                    PrecioProd = producto.PrecioProd,
                    EstadoProd = producto.EstadoProd,
                    DescripcionProd = producto.DescripcionProd

                };

                _context.Productos.Add(producto1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoProd"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", producto.EstadoProd);
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat", producto.IdCatProd);
            ViewData["MarcaProd"] = new SelectList(_context.MarcaProductos, "IdMarca", "IdMarca", producto.MarcaProd);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["EstadoProd"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", producto.EstadoProd);
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat", producto.IdCatProd);
            ViewData["MarcaProd"] = new SelectList(_context.MarcaProductos, "IdMarca", "IdMarca", producto.MarcaProd);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProd,IdCatProd,MarcaProd,CostoProd,ExistenciaProd,DescuentoProd,PrecioProd,EstadoProd,DescripcionProd")] Producto producto)
        {
            if (id != producto.IdProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProd))
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
            ViewData["EstadoProd"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", producto.EstadoProd);
            ViewData["IdCatProd"] = new SelectList(_context.CategoriaProductos, "IdCat", "IdCat", producto.IdCatProd);
            ViewData["MarcaProd"] = new SelectList(_context.MarcaProductos, "IdMarca", "IdMarca", producto.MarcaProd);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.EstadoProdNavigation)
                .Include(p => p.IdCatProdNavigation)
                .Include(p => p.MarcaProdNavigation)
                .FirstOrDefaultAsync(m => m.IdProd == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'TiendaSoftContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.IdProd == id)).GetValueOrDefault();
        }
    }
}
