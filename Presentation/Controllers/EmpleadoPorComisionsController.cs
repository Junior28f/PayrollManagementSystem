using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Models.EmpleadoPorComision;
using Infrastructure.Context;
using Domain.entities;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoPorComisionsController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoPorComisionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoPorComisions
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.EmpleadoPorComision.ToListAsync();

            var modelos = empleados.Select(e => new EmpleadoPorComisionModel
            {
                TipoDeEmpleado = e.TipoDeEmpleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NumeroDeSeguro = e.NumeroDeSeguro,
                Activo = e.Activo,
                VentasBrutas = e.VentaBruta,
                TarifaPorComision = e.TarifaPorComision
            }).ToList();

            return View(modelos);
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorComision
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new EmpleadoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                VentasBrutas = empleado.VentaBruta,
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
        public async Task<IActionResult> Create(CreateEmpleadoPorComisionModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new EmpleadoPorComision
                {
                    TipoDeEmpleado = model.TipoDeEmpleado,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    NumeroDeSeguro = model.NumeroDeSeguro,
                    Activo = model.Activo,
                    VentaBruta = model.VentasBrutas,
                    TarifaPorComision = model.TarifaPorComision
                };

                _context.EmpleadoPorComision.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.EmpleadoPorComision.FindAsync(id);
            if (empleado == null) return NotFound();

            var model = new EditEmpleadoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                VentasBrutas = empleado.VentaBruta,
                TarifaPorComision = empleado.TarifaPorComision
            };

            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoPorComisionModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.EmpleadoPorComision.FindAsync(id);
                    if (entity == null) return NotFound();

                    entity.TipoDeEmpleado = model.TipoDeEmpleado;
                    entity.Nombre = model.Nombre;
                    entity.Apellido = model.Apellido;
                    entity.Activo = model.Activo;
                    entity.VentaBruta = model.VentasBrutas;
                    entity.TarifaPorComision = model.TarifaPorComision;

                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoPorComisionExists(model.NumeroDeSeguro))
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

            var empleado = await _context.EmpleadoPorComision
                .FirstOrDefaultAsync(m => m.NumeroDeSeguro == id);

            if (empleado == null) return NotFound();

            var model = new DisableEmpleadoPorComisionModel
            {
                TipoDeEmpleado = empleado.TipoDeEmpleado,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDeSeguro = empleado.NumeroDeSeguro,
                Activo = empleado.Activo,
                VentasBrutas = empleado.VentaBruta,
                TarifaPorComision = empleado.TarifaPorComision
            };

            return View(model);
        }

        // POST: Disable
        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(int id)
        {
            var empleado = await _context.EmpleadoPorComision.FindAsync(id);
            if (empleado != null)
            {
                empleado.Activo = false;
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoPorComisionExists(int id)
        {
            return _context.EmpleadoPorComision.Any(e => e.NumeroDeSeguro == id);
        }
    }
}
