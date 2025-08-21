using Microsoft.AspNetCore.Mvc;
using PayrollManagementSystem.Models.EmpleadoPorComision;
using PayrollManagementSystem.Models.Interface;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoPorComisionsController : Controller
    {
        private readonly IEmpleadoPorComisionService _service;

        public EmpleadoPorComisionsController(IEmpleadoPorComisionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var modelos = await _service.GetAllEmpleadoPorComision();
            return View(modelos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoPorComisionById(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmpleadoPorComisionModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _service.CreateEmpleadoPorComision(model);
            if (!result) return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoPorComisionById(id.Value);
            if (model == null) return NotFound();

            var editModel = new EditEmpleadoPorComisionModel
            {
                TipoDeEmpleado = model.TipoDeEmpleado,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                NumeroDeSeguro = model.NumeroDeSeguro,
                Activo = model.Activo,
                VentasBrutas = model.VentasBrutas,
                TarifaPorComision = model.TarifaPorComision,
                PagoSemanal = model.PagoSemanal
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoPorComisionModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var result = await _service.UpdateEmpleadoPorComision(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoPorComisionById(id.Value);
            if (model == null) return NotFound();

            var disableModel = new DisableEmpleadoPorComisionModel
            {
                TipoDeEmpleado = model.TipoDeEmpleado,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                NumeroDeSeguro = model.NumeroDeSeguro,
                Activo = model.Activo,
                VentasBrutas = model.VentasBrutas,
                TarifaPorComision = model.TarifaPorComision,
                PagoSemanal = model.PagoSemanal
            };

            return View(disableModel);
        }

        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(int id)
        {
            var result = await _service.DisableEmpleadoPorComision(id );
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
