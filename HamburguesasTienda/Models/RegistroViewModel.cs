using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class RegistroViewModel
{
    public required string Nombre { get; set; }
    public required string Email { get; set; }
    public required string Contraseña { get; set; }
    public required string ConfirmarContraseña { get; set; }
}

}
