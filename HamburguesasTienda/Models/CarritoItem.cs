public class CarritoItem
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    // Opcionales
    public string ImagenUrl { get; set; } = "/img/hamburguesa-generica.jpg";
    public string Descripcion { get; set; } = "";
}
