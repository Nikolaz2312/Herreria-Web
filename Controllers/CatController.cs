using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Herreria_web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Herreria_web.Controllers
{
   
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;
        private readonly HerreriaDb db;

        public CatController(ILogger<CatController> logger, HerreriaDb context )
        {
            _logger = logger;
            db = context;
        }

      
          public async Task<IActionResult> AñadirC()
        {   
             ViewBag.Categ =  db.CatDB.OrderBy(cat => cat.categoria).ToList();
            return  View();
        }
        [HttpPost]
         public  async  Task<IActionResult> Categ(CategoriaModel c)
        {   
            db.CatDB.Add(c);
            db.SaveChanges();
           
            return RedirectToAction ("AñadirC");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}