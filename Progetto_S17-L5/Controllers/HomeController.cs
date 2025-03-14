using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Progetto_S17_L5.Services;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Controllers;

public class HomeController : Controller
{
    private readonly HomeService _homeService;

    public HomeController(HomeService homeService)
    {
        _homeService = homeService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Other()
    {
        return View();
    }

    public async Task<IActionResult> OptionOne()
    {
        var result = await _homeService.OptionOneAsync();

        return View(result);
    }

    public async Task<IActionResult> OptionTwo()
    {
        var result = await _homeService.OptionTwoAsync();

        return View(result);
    }

    public async Task<IActionResult> OptionThree()
    {
        var result = await _homeService.OptionThreeAsync();

        return View(result);
    }

    public async Task<IActionResult> OptionFour()
    {
        var result = await _homeService.OptionFourAsync();

        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
