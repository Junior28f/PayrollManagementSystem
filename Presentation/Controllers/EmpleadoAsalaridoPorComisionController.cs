using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision;
using Infrastructure.Context;
using Domain.entities;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoAsalaridoPorComisionController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoAsalaridoPorComisionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoAsalaridoPorComision
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.EmpleadoAsalaridoPorComision.ToListAsync();

            var modelos = empleados.Select(e => new EmpleadoAsalaridoPorComisionModel
            {
                TipoDeEmpleado = e.TipoDeEmpleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NumeroDeSeguro = e.NumeroDeSeguro,
                Activo = e.Activo,
                SalarioBase = e.SalarioBase,
                VentaBruta = e.VentaBruta,
                TarifaPorComision = e.TarifaPorComision
            }).ToList();

            return View(modelos);
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalaridoPorComision
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoAsalaridoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SalarioBase = empleado.SalarioBase,
                VentaBruta = empleado.VentaBruta,
                TarifaPorComision = empleado.TarifaPorComision
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
        public async Task<IActionResult> Create(EmpleadoAsalaridoPorComisionModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoAsalaridoPorComision
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    SalarioBase = model.SalarioBase,
                    VentaBruta = model.VentaBruta,
                    TarifaPorComision = model.TarifaPorComision
                };

                _context.EmpleadoAsalaridoPorComision.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoAsalaridoPorComision.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EditEmpleadoAsalaridoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SalarioBase = empleado.SalarioBase,
                VentaBruta = empleado.VentaBruta,
                TarifaPorComision = empleado.TarifaPorComision
            };

            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoAsalaridoPorComisionModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.EmpleadoAsalaridoPorComision.FindAsync(id);
                    if (entity == null) return NotFound();

                    entity.TipoDeEmpleado = model.TipoDeEmpleado;
                    entity.Nombre = model.Nombre;
                    entity.Apellido = model.Apellido;
                    entity.Activo = model.Activo;
                    entity.SalarioBase = model.SalarioBase;
                    entity.VentaBruta = model.VentaBruta;
                    entity.TarifaPorComision = model.TarifaPorComision;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoAsalaridoPorComisionExists(model.NumeroDeSeguro))
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

            var empleado = await _context.EmpleadoAsalaridoPorComision
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new DisableEmpleadoAsalaridoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                SalarioBase = empleado.SalarioBase,
                VentaBruta = empleado.VentaBruta,
                TarifaPorComision = empleado.TarifaPorComision
            };

            return View(model);
        }

        // POST: Disable
        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(int id)
        {
            var empleado = await _context.EmpleadoAsalaridoPorComision.FindAsync(id);
            if (empleado != null)
            {
                empleado.Activo = false;
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoAsalaridoPorComisionExists(int id)
        {
            return _context.EmpleadoAsalaridoPorComision.Any(e => e.NumeroDeSeguro == id);
        }
    }
}
