using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Herreria_web.Models;
using Herreria_web.Models.ViewModel;
using Microsoft.Extensions.Logging;

namespace Herreria_web.Controllers
{
    
    public class ProdController : Controller
    {
        private readonly ILogger<ProdController> _logger;
        private readonly HerreriaDb db;
        private readonly IWebHostEnvironment server;
        public ProdController(ILogger<ProdController> logger,HerreriaDb contex, IWebHostEnvironment web  )
        {
            _logger = logger;
            db = contex;
            server =web;
        }

        public IActionResult Prod()
        {   /* drop list de categoria*/
            ViewBag.Categoria = db.CatDB.OrderBy(car => car.categoria).ToList();
            ViewBag.Productos =db.ProDB.ToList();
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> AñadirPAsync(ProControlModel a)
        {   
            string guidImage = null;
              
            
               string ficheroimg = Path.Combine(server.WebRootPath,"imagen");
              
             guidImage = Guid.NewGuid().ToString() + a.img.FileName ;
               string rutadef = Path.Combine(ficheroimg,guidImage);
               await a.img.CopyToAsync(new FileStream(rutadef,FileMode.Create));
               ProductoModel prod = new ProductoModel();
               prod.nombre = a.nombre;
               prod.catid = a.catid;
               prod.rutaimg = guidImage;
               db.ProDB.Add(prod);
               db.SaveChanges();
            
            return RedirectToAction("Prod");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}