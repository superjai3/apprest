using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcPlato.Data;
using apprest.Models;
using apprest.ViewModels;
using System.Collections.Generic;

namespace apprest.Controllers
{
    public class PlatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plato
        public async Task<IActionResult> Index()
        {
            var platoListViewModel = new List<PlatoViewModel>();

            // Verificar si _context.Platos es nulo antes de usarlo
            if (_context.Platos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Platos' is null.");
            }

            var platos = await _context.Platos.ToListAsync();

            foreach (var item in platos)
            {
                platoListViewModel.Add(
                    new PlatoViewModel
                    {
                        Name = item.Name,
                        Pais = item.Pais,
                        Price = item.Price
                    }
                );
            }
            return View(platoListViewModel);
        }

        // GET: Plato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // GET: Plato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pais,Tipo_Comida,Disponibilidad,Price")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: Plato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }

        // POST: Plato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pais,Tipo_Comida,Disponibilidad,Price")] Plato plato)
        {
            if (id != plato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.Id))
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
            return View(plato);
        }

        // GET: Plato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: Plato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato != null)
            {
                _context.Platos.Remove(plato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.Id == id);
        }
    }
}
