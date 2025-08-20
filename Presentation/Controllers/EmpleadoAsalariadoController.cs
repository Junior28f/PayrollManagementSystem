using System.Linq;
using System.Threading.Tasks;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Models.EmpleadoAsalariado;
using Infrastructure.Context;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoAsalariadoController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoAsalariadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoAsalariado
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
                SalarioSemanal = e.Salariosemanal1
            }).ToList();

            return View(modelos);
        }

        // GET: EmpleadoAsalariado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new DetailsEmpleadoAsalariadoModel(
                empleado.TipoDeEmpleado,
                empleado.Nombre,
                empleado.Apellido,
                empleado.NumeroDeSeguro,
                empleado.Activo,
                empleado.Salariosemanal1
            );

            return View(model);
        }

        // GET: EmpleadoAsalariado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoAsalariado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmpleadoAsalariadoModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoAsalariado
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    Salariosemanal1 = model.Salariosemanal1
                };

                _context.EmpleadoAsalariados.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: EmpleadoAsalariado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EditEmpleadoAsalariadoModel(
                empleado.TipoDeEmpleado,
                empleado.Nombre,
                empleado.Apellido,
                empleado.NumeroDeSeguro,
                empleado.Activo,
                empleado.Salariosemanal1
            );

            return View(model);
        }

        // POST: EmpleadoAsalariado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoAsalariadoModel model)
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

        // GET: EmpleadoAsalariado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalariados
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new DisableEmpleadoAsalariado(
                empleado.TipoDeEmpleado,
                empleado.Nombre,
                empleado.Apellido,
                empleado.NumeroDeSeguro,
                empleado.Activo,
                empleado.Salariosemanal1
            );

            return View(model);
        }

        // POST: EmpleadoAsalariado/Delete/5
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
