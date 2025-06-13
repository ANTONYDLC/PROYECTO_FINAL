using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public string Rol { get; set; } = "Cliente";

        public bool EsAdmin => Rol == "Admin";
    }
}
