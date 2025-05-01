using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Maquis_EvaluacionProgreso1_PrograIV.Models;

namespace Maquis_EvaluacionProgreso1_PrograIV.Controllers
{
    public class PropietarioMascotasController : Controller
    {
        private readonly Maquis_DataBase_EvaluacionProgreso1_PrograIV _context;

        public PropietarioMascotasController(Maquis_DataBase_EvaluacionProgreso1_PrograIV context)
        {
            _context = context;
        }

        // GET: PropietarioMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropietarioMascota.ToListAsync());
        }

        // GET: PropietarioMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietarioMascota = await _context.PropietarioMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propietarioMascota == null)
            {
                return NotFound();
            }

            return View(propietarioMascota);
        }

        // GET: PropietarioMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropietarioMascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Telefono,Correo,FechaNacimiento,TieneDeuda,Deuda")] PropietarioMascota propietarioMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propietarioMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propietarioMascota);
        }

        // GET: PropietarioMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietarioMascota = await _context.PropietarioMascota.FindAsync(id);
            if (propietarioMascota == null)
            {
                return NotFound();
            }
            return View(propietarioMascota);
        }

        // POST: PropietarioMascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Telefono,Correo,FechaNacimiento,TieneDeuda,Deuda")] PropietarioMascota propietarioMascota)
        {
            if (id != propietarioMascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietarioMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioMascotaExists(propietarioMascota.Id))
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
            return View(propietarioMascota);
        }

        // GET: PropietarioMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietarioMascota = await _context.PropietarioMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propietarioMascota == null)
            {
                return NotFound();
            }

            return View(propietarioMascota);
        }

        // POST: PropietarioMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propietarioMascota = await _context.PropietarioMascota.FindAsync(id);
            if (propietarioMascota != null)
            {
                _context.PropietarioMascota.Remove(propietarioMascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropietarioMascotaExists(int id)
        {
            return _context.PropietarioMascota.Any(e => e.Id == id);
        }
    }
}
