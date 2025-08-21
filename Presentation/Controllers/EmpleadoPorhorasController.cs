using Microsoft.AspNetCore.Mvc;
using PayrollManagementSystem.Models.EmpleadoPorHoras;
using PayrollManagementSystem.Models.Interface;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoPorhorasController : Controller
    {
        private readonly IEmpleadoPorHorasService _service;

        public EmpleadoPorhorasController(IEmpleadoPorHorasService service)
        {
            _service = service;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var empleados = await _service.GetAllEmpleadoPorHoraModel();
            return View(empleados);
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _service.GetEmpleadoPorHoraModelById(id.Value);
            if (empleado == null) return NotFound();

            return View(empleado);
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
            if (!ModelState.IsValid) return View(model);

            var result = await _service.CreateEmpleadoPorHoraModel(model);
            if (!result) return BadRequest("No se pudo crear el empleado.");

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _service.GetEmpleadoPorHoraModelById(id.Value);
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
            if (!ModelState.IsValid) return View(model);

            var result = await _service.UpdateEmpleadoPorHoraModel(id, model);
            if (!result) return NotFound("No se pudo actualizar el empleado.");

            return RedirectToAction(nameof(Index));
        }

        // GET: Disable
        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _service.GetEmpleadoPorHoraModelById(id.Value);
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
            var model = new DisableEmpleadoPorHoraModel { Activo = false };
            var result = await _service.DisableEmpleadoPorHoraModel(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
