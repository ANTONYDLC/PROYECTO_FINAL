using System.ComponentModel.DataAnnotations.Schema;

namespace HamburguesasTienda.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!; // propiedad de navegación

        public int Cantidad { get; set; }

        public string UsuarioId { get; set; } = string.Empty;
        public required string Nombre { get; set; }  
         public decimal Precio { get; set; }
}

}
