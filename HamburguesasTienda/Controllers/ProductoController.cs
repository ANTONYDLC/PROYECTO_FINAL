using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new()
        {
            new Producto { Id = 1, Nombre = "Hamburguesa Clásica", Precio = 5.99m, ImagenUrl = "/img/classic.jpg", Disponible = true },
            new Producto { Id = 2, Nombre = "Hamburguesa BBQ", Precio = 6.99m, ImagenUrl = "/img/bbq.jpg", Disponible = true }
        };

        public IActionResult Index() => View(productos);

        public static Producto? ObtenerPorId(int id) =>
            productos.FirstOrDefault(p => p.Id == id);
    }
}
