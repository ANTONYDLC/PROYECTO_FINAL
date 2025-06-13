public class Anuncio
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public string? ImagenUrl { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}
