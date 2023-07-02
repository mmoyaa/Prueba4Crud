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
    public class TbpacientesController : Controller
    {
        private readonly Bdprueba4Context _context;

        public TbpacientesController(Bdprueba4Context context)
        {
            _context = context;
        }

        // GET: Tbpacientes
        public async Task<IActionResult> Index()
        {
              return _context.Tbpacientes != null ? 
                          View(await _context.Tbpacientes.ToListAsync()) :
                          Problem("Entity set 'Bdprueba4Context.Tbpacientes'  is null.");
        }

        // GET: Tbpacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tbpacientes == null)
            {
                return NotFound();
            }

            var tbpaciente = await _context.Tbpacientes
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (tbpaciente == null)
            {
                return NotFound();
            }

            return View(tbpaciente);
        }

        // GET: Tbpacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbpacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Fono,Correo,Edad,Dirección,Previsión")] Tbpaciente tbpaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbpaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbpaciente);
        }

        // GET: Tbpacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tbpacientes == null)
            {
                return NotFound();
            }

            var tbpaciente = await _context.Tbpacientes.FindAsync(id);
            if (tbpaciente == null)
            {
                return NotFound();
            }
            return View(tbpaciente);
        }

        // POST: Tbpacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nombre,Apellido,Fono,Correo,Edad,Dirección,Previsión")] Tbpaciente tbpaciente)
        {
            if (id != tbpaciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbpaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbpacienteExists(tbpaciente.IdPaciente))
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
            return View(tbpaciente);
        }

        // GET: Tbpacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tbpacientes == null)
            {
                return NotFound();
            }

            var tbpaciente = await _context.Tbpacientes
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (tbpaciente == null)
            {
                return NotFound();
            }

            return View(tbpaciente);
        }

        // POST: Tbpacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tbpacientes == null)
            {
                return Problem("Entity set 'Bdprueba4Context.Tbpacientes'  is null.");
            }
            var tbpaciente = await _context.Tbpacientes.FindAsync(id);
            if (tbpaciente != null)
            {
                _context.Tbpacientes.Remove(tbpaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbpacienteExists(int id)
        {
          return (_context.Tbpacientes?.Any(e => e.IdPaciente == id)).GetValueOrDefault();
        }
    }
}
