using Microsoft.AspNetCore.Mvc;
using PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision;
using PayrollManagementSystem.Models.Interface;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoAsalaridoPorComisionController : Controller
    {
        private readonly IEmpleadoAsalariadoPorComisionService _service;

        public EmpleadoAsalaridoPorComisionController(IEmpleadoAsalariadoPorComisionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var modelos = await _service.GetAllEmpleadoAsalariadoPorComision();
            return View(modelos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoAsalariadoPorComisionById(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmpleadoAsalaridoPorComisionModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _service.CreateEmpleadoAsalariadoPorComision(model);
            if (!result) return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoAsalariadoPorComisionById(id.Value);
            if (model == null) return NotFound();

            var editModel = new EditEmpleadoAsalaridoPorComisionModel
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

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoAsalaridoPorComisionModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var result = await _service.UpdateEmpleadoAsalariadoPorComision(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Disable(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetDisableModelAsync(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(int id)
        {
            var model = new DisableEmpleadoAsalaridoPorComisionModel(); // opcional si no usas datos
            var result = await _service.DisableEmpleadoAsalariadoPorComision(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
