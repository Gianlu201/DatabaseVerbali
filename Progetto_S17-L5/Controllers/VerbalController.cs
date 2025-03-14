using Microsoft.AspNetCore.Mvc;
using Progetto_S17_L5.Services;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Controllers
{
    public class VerbalController : Controller
    {
        private readonly VerbalService _verbalService;

        public VerbalController(VerbalService verbalService)
        {
            _verbalService = verbalService;
        }

        public async Task<IActionResult> Index()
        {
            var verbalsList = await _verbalService.GetAllVerbalsAsync();

            return View(verbalsList);
        }

        public async Task<IActionResult> AddVerbal()
        {
            var registersList = await _verbalService.GetAllRegistersAsync();
            var violationsList = await _verbalService.GetAllViolationsAsync();

            ViewBag.Registers = registersList;
            ViewBag.Violations = violationsList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVerbal(AddVerbalViewModel addVerbalViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Something went wrong! Check your datas and try again!";
                return RedirectToAction("AddVerbal");
            }

            var result = await _verbalService.AddVerbalAsync(addVerbalViewModel);

            if (!result)
            {
                TempData["Error"] = "Something went wrong!";
            }

            return RedirectToAction("Index");
        }
    }
}
