using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Herreria_web.Models;

namespace Herreria_web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HerreriaDb db;
    public HomeController(ILogger<HomeController> logger, HerreriaDb contex)
    {
       
        _logger = logger;
         db = contex;
    }

    public IActionResult Index()
    {
        return View();
    }
      public IActionResult Galery()
    {   
        ViewBag.Prod = db.ProDB.ToList();
        ViewBag.Cat = db.CatDB.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
