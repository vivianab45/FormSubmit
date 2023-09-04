using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmit.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormSubmit.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult CreateUser(User u)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success");
        } else{

            return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
