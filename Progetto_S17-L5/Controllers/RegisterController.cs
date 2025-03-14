using Microsoft.AspNetCore.Mvc;
using Progetto_S17_L5.Services;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterService _registerService;

        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        public async Task<IActionResult> Index()
        {
            var registersList = await _registerService.GetAllRegistersAsync();

            return View(registersList);
        }

        public IActionResult AddRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRegister(AddRegisterViewModel addRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Something went wrong! Check your datas!";
                return RedirectToAction("Add");
            }

            var result = await _registerService.AddRegisterAsync(addRegisterViewModel);

            if (!result)
            {
                TempData["Error"] = "Something went wrong! Fail in adding new register!";
            }

            return RedirectToAction("Index");
        }
    }
}
