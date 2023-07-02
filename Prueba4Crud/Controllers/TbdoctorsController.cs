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
    public class TbdoctorsController : Controller
    {
        private readonly Bdprueba4Context _context;

        public TbdoctorsController(Bdprueba4Context context)
        {
            _context = context;
        }

        // GET: Tbdoctors
        public async Task<IActionResult> Index()
        {
              return _context.Tbdoctors != null ? 
                          View(await _context.Tbdoctors.ToListAsync()) :
                          Problem("Entity set 'Bdprueba4Context.Tbdoctors'  is null.");
        }

        // GET: Tbdoctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tbdoctors == null)
            {
                return NotFound();
            }

            var tbdoctor = await _context.Tbdoctors
                .FirstOrDefaultAsync(m => m.IdDoctor == id);
            if (tbdoctor == null)
            {
                return NotFound();
            }

            return View(tbdoctor);
        }

        // GET: Tbdoctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbdoctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoctor,Nombre,Apellido,Fono,Correo,Especialidad,Convenio,TipoCita")] Tbdoctor tbdoctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbdoctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbdoctor);
        }

        // GET: Tbdoctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tbdoctors == null)
            {
                return NotFound();
            }

            var tbdoctor = await _context.Tbdoctors.FindAsync(id);
            if (tbdoctor == null)
            {
                return NotFound();
            }
            return View(tbdoctor);
        }

        // POST: Tbdoctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoctor,Nombre,Apellido,Fono,Correo,Especialidad,Convenio,TipoCita")] Tbdoctor tbdoctor)
        {
            if (id != tbdoctor.IdDoctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbdoctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbdoctorExists(tbdoctor.IdDoctor))
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
            return View(tbdoctor);
        }

        // GET: Tbdoctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tbdoctors == null)
            {
                return NotFound();
            }

            var tbdoctor = await _context.Tbdoctors
                .FirstOrDefaultAsync(m => m.IdDoctor == id);
            if (tbdoctor == null)
            {
                return NotFound();
            }

            return View(tbdoctor);
        }

        // POST: Tbdoctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tbdoctors == null)
            {
                return Problem("Entity set 'Bdprueba4Context.Tbdoctors'  is null.");
            }
            var tbdoctor = await _context.Tbdoctors.FindAsync(id);
            if (tbdoctor != null)
            {
                _context.Tbdoctors.Remove(tbdoctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbdoctorExists(int id)
        {
          return (_context.Tbdoctors?.Any(e => e.IdDoctor == id)).GetValueOrDefault();
        }
    }
}
