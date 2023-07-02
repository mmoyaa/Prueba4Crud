using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba4Crud.Models;

namespace Prueba4Crud.Controllers
{
    public class TbusuariosController : Controller
    {
        private readonly Bdprueba4Context _context;

        public TbusuariosController(Bdprueba4Context context)
        {
            _context = context;
        }

        // GET: Tbusuarios
        public async Task<IActionResult> Index()
        {
              return _context.Tbusuarios != null ? 
                          View(await _context.Tbusuarios.ToListAsync()) :
                          Problem("Entity set 'Bdprueba4Context.Tbusuarios'  is null.");
        }

        // GET: Tbusuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tbusuarios == null)
            {
                return NotFound();
            }

            var tbusuario = await _context.Tbusuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tbusuario == null)
            {
                return NotFound();
            }

            return View(tbusuario);
        }

        // GET: Tbusuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbusuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Clave,Nombre,Correo,Fono,Perfil")] Tbusuario tbusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbusuario);
        }

        // GET: Tbusuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tbusuarios == null)
            {
                return NotFound();
            }

            var tbusuario = await _context.Tbusuarios.FindAsync(id);
            if (tbusuario == null)
            {
                return NotFound();
            }
            return View(tbusuario);
        }

        // POST: Tbusuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Clave,Nombre,Correo,Fono,Perfil")] Tbusuario tbusuario)
        {
            if (id != tbusuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbusuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbusuarioExists(tbusuario.IdUsuario))
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
            return View(tbusuario);
        }

        // GET: Tbusuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tbusuarios == null)
            {
                return NotFound();
            }

            var tbusuario = await _context.Tbusuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tbusuario == null)
            {
                return NotFound();
            }

            return View(tbusuario);
        }

        // POST: Tbusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tbusuarios == null)
            {
                return Problem("Entity set 'Bdprueba4Context.Tbusuarios'  is null.");
            }
            var tbusuario = await _context.Tbusuarios.FindAsync(id);
            if (tbusuario != null)
            {
                _context.Tbusuarios.Remove(tbusuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbusuarioExists(int id)
        {
          return (_context.Tbusuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
