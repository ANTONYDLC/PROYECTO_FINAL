using System;
using System.ComponentModel.DataAnnotations;

namespace HamburguesasTienda.Models
{
    public class Anuncio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        [StringLength(500)]
        public string Mensaje { get; set; }

        [Display(Name = "URL de la imagen")]
        public string? ImagenUrl { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
