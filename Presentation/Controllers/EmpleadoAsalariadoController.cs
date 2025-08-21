using Microsoft.AspNetCore.Mvc;
using PayrollManagementSystem.Models.EmpleadoAsalariado;
using PayrollManagementSystem.Models.Interface;

namespace PayrollManagementSystem.Controllers
{
    public class EmpleadoAsalariadoController : Controller
    {
        private readonly IEmpleadoAsalariadoService _service;

        public EmpleadoAsalariadoController(IEmpleadoAsalariadoService service)
        {
            _service = service;
        }

        // GET: EmpleadoAsalariado
        public async Task<IActionResult> Index()
        {
            var modelos = await _service.GetAllAEmpleadoAsalariado();
            return View(modelos);
        }

        // GET: EmpleadoAsalariado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoAsalariadoById(id.Value);
            if (model == null) return NotFound();

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
            if (!ModelState.IsValid) return View(model);

            var result = await _service.CreateEmpleadoAsalariado(model);
            if (!result) return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // GET: EmpleadoAsalariado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoAsalariadoById(id.Value);
            if (model == null) return NotFound();

            var editModel = new EditEmpleadoAsalariadoModel(
                model.TipoDeEmpleado,
                model.Nombre,
                model.Apellido,
                model.NumeroDeSeguro,
                model.Activo,
                model.SalarioSemanal,
                model.PagoSemanal
            );

            return View(editModel);
        }

        // POST: EmpleadoAsalariado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmpleadoAsalariadoModel model)
        {
            if (id != model.NumeroDeSeguro) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var result = await _service.UpdateEmpleadoAsalariado(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: EmpleadoAsalariado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var model = await _service.GetEmpleadoAsalariadoById(id.Value);
            if (model == null) return NotFound();

            var disableModel = new DisableEmpleadoAsalariado(
                model.TipoDeEmpleado,
                model.Nombre,
                model.Apellido,
                model.NumeroDeSeguro,
                model.Activo,
                model.SalarioSemanal,
                model.PagoSemanal
            );

            return View(disableModel);
        }

        // POST: EmpleadoAsalariado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = new DisableEmpleadoAsalariado(); // puedes pasar el modelo si lo necesitas
            var result = await _service.DisableEmpleadoAsalariado(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
