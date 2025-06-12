using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class RegistroViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        [DataType(DataType.Password)]
        public string ConfirmarContraseña { get; set; }
    }
}
