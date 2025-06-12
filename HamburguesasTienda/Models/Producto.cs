namespace HamburguesasTienda.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        public bool Disponible { get; set; }
        public string Categoria { get; set; }
        public int Valoracion { get; set; } = 4; // Valor por defecto si no viene de base de datos

    }
}
