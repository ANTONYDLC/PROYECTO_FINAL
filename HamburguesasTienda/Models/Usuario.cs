namespace HamburguesasTienda.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool EsAdmin { get; set; }
    }
}
