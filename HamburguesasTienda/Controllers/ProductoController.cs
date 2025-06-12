using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using System.Collections.Generic;

namespace HamburguesasTienda.Controllers
{
    public class ProductoController : Controller
    {
        public static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Hamburguesa Clásica", Precio = 8.99M, ImagenUrl = "/img/classic.jpg" },
            new Producto { Id = 2, Nombre = "Doble Queso", Precio = 10.49M, ImagenUrl = "/img/double.jpg" },
            new Producto { Id = 3, Nombre = "Vegana", Precio = 9.99M, ImagenUrl = "/img/vegan.jpg" }
        };

        public IActionResult Index()
        {
            return View(productos);
        }
    }
}
