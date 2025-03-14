using Microsoft.AspNetCore.Mvc;
using Progetto_S17_L5.Services;

namespace Progetto_S17_L5.Controllers
{
    public class ViolationController : Controller
    {
        private readonly ViolationService _violationService;

        public ViolationController(ViolationService violationService)
        {
            _violationService = violationService;
        }

        public async Task<IActionResult> Index()
        {
            var violationsList = await _violationService.GetAllViolationsAsync();

            return View(violationsList);
        }
    }
}
