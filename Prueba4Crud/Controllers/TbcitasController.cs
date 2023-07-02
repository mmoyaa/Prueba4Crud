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
    public class TbcitasController : Controller
    {
        private readonly Bdprueba4Context _context;

        public TbcitasController(Bdprueba4Context context)
        {
            _context = context;
        }

        // GET: Tbcitas
        public async Task<IActionResult> Index()
        {
            var bdprueba4Context = _context.Tbcitas.Include(t => t.IdDoctorNavigation).Include(t => t.IdPacienteNavigation);
            return View(await bdprueba4Context.ToListAsync());
        }

        // GET: Tbcitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tbcitas == null)
            {
                return NotFound();
            }

            var tbcita = await _context.Tbcitas
                .Include(t => t.IdDoctorNavigation)
                .Include(t => t.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (tbcita == null)
            {
                return NotFound();
            }

            return View(tbcita);
        }

        // GET: Tbcitas/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Tbdoctors, "IdDoctor", "IdDoctor");
            ViewData["IdPaciente"] = new SelectList(_context.Tbpacientes, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: Tbcitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,Fecha,Hora,Previsión,ModoCita,IdDoctor,IdPaciente")] Tbcita tbcita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbcita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Tbdoctors, "IdDoctor", "IdDoctor", tbcita.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Tbpacientes, "IdPaciente", "IdPaciente", tbcita.IdPaciente);
            return View(tbcita);
        }

        // GET: Tbcitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tbcitas == null)
            {
                return NotFound();
            }

            var tbcita = await _context.Tbcitas.FindAsync(id);
            if (tbcita == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Tbdoctors, "IdDoctor", "IdDoctor", tbcita.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Tbpacientes, "IdPaciente", "IdPaciente", tbcita.IdPaciente);
            return View(tbcita);
        }

        // POST: Tbcitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,Fecha,Hora,Previsión,ModoCita,IdDoctor,IdPaciente")] Tbcita tbcita)
        {
            if (id != tbcita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbcita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbcitaExists(tbcita.IdCita))
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
            ViewData["IdDoctor"] = new SelectList(_context.Tbdoctors, "IdDoctor", "IdDoctor", tbcita.IdDoctor);
            ViewData["IdPaciente"] = new SelectList(_context.Tbpacientes, "IdPaciente", "IdPaciente", tbcita.IdPaciente);
            return View(tbcita);
        }

        // GET: Tbcitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tbcitas == null)
            {
                return NotFound();
            }

            var tbcita = await _context.Tbcitas
                .Include(t => t.IdDoctorNavigation)
                .Include(t => t.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (tbcita == null)
            {
                return NotFound();
            }

            return View(tbcita);
        }

        // POST: Tbcitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tbcitas == null)
            {
                return Problem("Entity set 'Bdprueba4Context.Tbcitas'  is null.");
            }
            var tbcita = await _context.Tbcitas.FindAsync(id);
            if (tbcita != null)
            {
                _context.Tbcitas.Remove(tbcita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbcitaExists(int id)
        {
          return (_context.Tbcitas?.Any(e => e.IdCita == id)).GetValueOrDefault();
        }
    }
}
