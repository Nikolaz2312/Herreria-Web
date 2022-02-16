
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Herreria_web.Models
{
    public class ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int proid { get; set; }
        [Required(ErrorMessage ="Ingrese el nombre de del producto.")]
        public string nombre {get;set;}
        [Required(ErrorMessage ="Ingrese imagen.")]
        public string rutaimg {get;set;}
        [Required(ErrorMessage ="Ingrese Categoria.")]
        public int catid{get;set;}
        [ForeignKey("catid")]
        public  CategoriaModel CategoriaModel {get;set;}
        

    }
}