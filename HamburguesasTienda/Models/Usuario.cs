using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }  // ← ESTA DEBE EXISTIR
        public required string Contraseña { get; set; }
        [Required]
        public required string Rol { get; set; } // "admin" o "usuario"

        // Propiedad calculada que puedes usar en toda la app
        public bool EsAdmin => Rol?.ToLower() == "admin"; 

        // Propiedad calculada que puedes usar en toda la app

    }
}