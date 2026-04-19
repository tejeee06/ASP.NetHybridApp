using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisitesMediques.Application.Services;
using VisitesMediques.Domain.Entities;

namespace VisitesMediques.WebUI.Controllers
{
    public class VisitaMedicaController : Controller
    {
        private readonly IVisitaMedicaService _service;

        public VisitaMedicaController(IVisitaMedicaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var visitas = await _service.ObtenerTodasAsync();
            return View(visitas);
        }

        public async Task<IActionResult> Details(long id)
        {
            var visita = await _service.ObtenerPorIdAsync(id);
            if (visita == null) return NotFound();
            return View(visita);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitaMedica visita)
        {
            if (ModelState.IsValid)
            {
                await _service.CrearAsync(visita);
                return RedirectToAction(nameof(Index));
            }
            return View(visita);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var visita = await _service.ObtenerPorIdAsync(id);
            if (visita == null) return NotFound();
            return View(visita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, VisitaMedica visita)
        {
            if (id != visita.IdVisita) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.ActualizarAsync(visita);
                return RedirectToAction(nameof(Index));
            }
            return View(visita);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var visita = await _service.ObtenerPorIdAsync(id);
            if (visita == null) return NotFound();
            return View(visita);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _service.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}