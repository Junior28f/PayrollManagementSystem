using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Models; 
using Infrastructure.Context;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoPorhorasController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoPorhorasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoPorhoras
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.EmpleadoPorHoras.ToListAsync();

            var modelos = empleados.Select(e => new EmpleadoPorHorasModel
            {
                TipoDeEmpleado = e.TipoDeEmpleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NumeroDeSeguro = e.NumeroDeSeguro,
                Activo = e.Activo,
                SueldoPorhora = e.SueldoPorhora,
                HorasTrabajadas = e.HorasTrabajadas
            }).ToList();

            return View(modelos);
        }

        // GET: EmpleadoPorhoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoPorHorasModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SueldoPorhora = empleado.SueldoPorhora,
                HorasTrabajadas = empleado.HorasTrabajadas
            };

            return View(model);
        }

        // GET: EmpleadoPorhoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoPorhoras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoPorHorasModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoPorHorasModel()
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    SueldoPorhora = model.SueldoPorhora,
                    HorasTrabajadas = model.HorasTrabajadas
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EmpleadoPorhoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EmpleadoPorHorasModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SueldoPorhora = empleado.SueldoPorhora,
                HorasTrabajadas = empleado.HorasTrabajadas
            };

            return View(model);
        }

        // POST: EmpleadoPorhoras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmpleadoPorHorasModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.EmpleadoPorHoras.FindAsync(id);
                    if (entity == null) return NotFound();

                    entity.TipoDeEmpleado = model.TipoDeEmpleado;
                    entity.Nombre = model.Nombre;
                    entity.Apellido = model.Apellido;
                    entity.Activo = model.Activo;
                    entity.SueldoPorhora = model.SueldoPorhora;
                    entity.HorasTrabajadas = model.HorasTrabajadas;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoPorhorasExists(model.NumeroDeSeguro))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EmpleadoPorhoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoPorHorasModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SueldoPorhora = empleado.SueldoPorhora,
                HorasTrabajadas = empleado.HorasTrabajadas
            };

            return View(model);
        }

        // POST: EmpleadoPorhoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);
            if (empleado != null)
            {
                _context.EmpleadoPorHoras.Remove(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoPorhorasExists(int id)
        {
            return _context.EmpleadoPorHoras.Any(e => e.NumeroDeSeguro == id);
        }
    }
}
