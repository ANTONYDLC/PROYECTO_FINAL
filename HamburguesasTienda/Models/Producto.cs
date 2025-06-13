using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public decimal Precio { get; set; }

        public string Descripcion { get; set; } = "";

        public string ImagenUrl { get; set; } = "/img/hamburguesa-generica.jpg";
        public required string Categoria { get; set; }
        public int Valoracion { get; set; }
         
         public int Ventas { get; set; } = 0;

    }
}
