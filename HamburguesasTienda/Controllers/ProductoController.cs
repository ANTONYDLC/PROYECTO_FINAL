using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new()
        {
        new Producto { Id = 1, Nombre = "Clásica", Descripcion = "Hamburguesa tradicional con queso y tomate.", Precio = 5.99m, ImagenUrl = "/img/classic.jpg", Categoria = "Clásica", Valoracion = 4 },
        new Producto { Id = 2, Nombre = "Doble Carne", Descripcion = "Doble porción de carne con queso cheddar.", Precio = 7.49m, ImagenUrl = "/img/doble.jpg", Categoria = "Premium", Valoracion = 5 },
        new Producto { Id = 3, Nombre = "Picante", Descripcion = "Con jalapeños y salsa especial picante.", Precio = 6.25m, ImagenUrl = "/img/picante.jpg", Categoria = "Especial", Valoracion = 3 },
        new Producto { Id = 4, Nombre = "Vegetariana", Descripcion = "Con medallón de lentejas y vegetales.", Precio = 5.50m, ImagenUrl = "/img/veggie.jpg", Categoria = "Vegana", Valoracion = 4 },
        new Producto { Id = 5, Nombre = "Bacon Lover", Descripcion = "Con crujiente tocino y cheddar.", Precio = 6.90m, ImagenUrl = "/img/bacon.jpg", Categoria = "Clásica", Valoracion = 5 },
        new Producto { Id = 6, Nombre = "BBQ Suprema", Descripcion = "Con salsa barbacoa y cebolla caramelizada.", Precio = 6.75m, ImagenUrl = "/img/bbq.jpg", Categoria = "Premium", Valoracion = 4 },
        new Producto { Id = 7, Nombre = "Champiñones", Descripcion = "Con hongos salteados y salsa especial.", Precio = 6.40m, ImagenUrl = "/img/champ.jpg", Categoria = "Especial", Valoracion = 3 },
        new Producto { Id = 8, Nombre = "Crispy Chicken", Descripcion = "Hamburguesa de pollo crujiente.", Precio = 6.20m, ImagenUrl = "/img/crispy.jpg", Categoria = "Pollo", Valoracion = 4 },
        new Producto { Id = 9, Nombre = "Hawaiana", Descripcion = "Con piña y salsa dulce.", Precio = 6.10m, ImagenUrl = "/img/hawaiana.jpg", Categoria = "Especial", Valoracion = 2 },
        new Producto { Id = 10, Nombre = "Blue Cheese", Descripcion = "Con queso azul y rúcula.", Precio = 6.85m, ImagenUrl = "/img/bluecheese.jpg", Categoria = "Premium", Valoracion = 5 },
        new Producto { Id = 11, Nombre = "Mexicana", Descripcion = "Con guacamole y nachos crujientes.", Precio = 6.50m, ImagenUrl = "/img/mexicana.jpg", Categoria = "Especial", Valoracion = 4 },
        new Producto { Id = 12, Nombre = "Deluxe", Descripcion = "Nuestra hamburguesa más completa y sabrosa.", Precio = 7.99m, ImagenUrl = "/img/deluxe.jpg", Categoria = "Deluxe", Valoracion = 5 }
        };

        public IActionResult Index() => View(productos);

        public static Producto? ObtenerPorId(int id) =>
            productos.FirstOrDefault(p => p.Id == id);
    }
}
