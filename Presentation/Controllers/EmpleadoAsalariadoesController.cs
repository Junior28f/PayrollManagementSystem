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
    public class EmpleadoAsalariadoesController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoAsalariadoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoAsalariadoes
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.EmpleadoAsalariados.ToListAsync();

            var modelos = empleados.Select(e => new EmpleadoAsalariadoModel
            {
                TipoDeEmpleado = e.TipoDeEmpleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NumeroDeSeguro = e.NumeroDeSeguro,
                Activo = e.Activo,
                Salariosemanal1 = e.Salariosemanal1
            }).ToList();

            return View(modelos);
        }

        // GET: EmpleadoAsalariadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoAsalariadoModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                Salariosemanal1 = empleado.Salariosemanal1
            };

            return View(model);
        }

        // GET: EmpleadoAsalariadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoAsalariadoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoAsalariadoModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoAsalariadoModel()
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    Salariosemanal1 = model.Salariosemanal1
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EmpleadoAsalariadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EmpleadoAsalariadoModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                Salariosemanal1 = empleado.Salariosemanal1
            };

            return View(model);
        }

        // POST: EmpleadoAsalariadoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmpleadoAsalariadoModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.EmpleadoAsalariados.FindAsync(id);
                    if (entity == null) return NotFound();

                    entity.TipoDeEmpleado = model.TipoDeEmpleado;
                    entity.Nombre = model.Nombre;
                    entity.Apellido = model.Apellido;
                    entity.Activo = model.Activo;
                    entity.Salariosemanal1 = model.Salariosemanal1;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoAsalariadoExists(model.NumeroDeSeguro))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EmpleadoAsalariadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoAsalariadoModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                Salariosemanal1 = empleado.Salariosemanal1
            };

            return View(model);
        }

        // POST: EmpleadoAsalariadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.EmpleadoAsalariados.FindAsync(id);
            if (empleado != null)
            {
                _context.EmpleadoAsalariados.Remove(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoAsalariadoExists(int id)
        {
            return _context.EmpleadoAsalariados.Any(e => e.NumeroDeSeguro == id);
        }
    }
}
