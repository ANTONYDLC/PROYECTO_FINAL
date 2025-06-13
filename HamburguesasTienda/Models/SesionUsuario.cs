using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class SesionUsuario
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string TokenSesion { get; set; } = "";

        public DateTime FechaInicio { get; set; } = DateTime.Now;
    }
}
