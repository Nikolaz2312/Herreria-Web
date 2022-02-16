using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herreria_web.Models.ViewModel
{
    public class ProControlModel
    {
        [Required(ErrorMessage ="Ingrese el nombre de del producto.")]
        public string nombre {get;set;}
        [Required(ErrorMessage ="Ingrese imagen.")]
        public IFormFile img {get;set;}
        [Required(ErrorMessage ="Ingrese Categoria.")]
        public int catid{get;set;}
    }
}