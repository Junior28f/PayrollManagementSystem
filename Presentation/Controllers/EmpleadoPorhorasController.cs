using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Models;
using Infrastructure.Context;
using Domain.entities;
using PayrollManagementSystem.Models.EmpleadoPorHoras;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoPorhorasController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoPorhorasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.EmpleadoPorHoras.ToListAsync();

            var modelos = empleados.Select(e => new EmpleadoPorHoraModel
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

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoPorHoraModel
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

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmpleadoPorHoraModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoPorhoras
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    SueldoPorhora = model.SueldoPorhora,
                    HorasTrabajadas = model.HorasTrabajadas
                };

                _context.EmpleadoPorHoras.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EditEmpleadoPorHoraModel
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

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoPorHoraModel model)
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

        // GET: Disable
        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorHoras
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new DisableEmpleadoPorHoraModel
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

        // POST: Disable
        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(int id)
        {
            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);
            if (empleado != null)
            {
                empleado.Activo = false;
                _context.Update(empleado);
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
