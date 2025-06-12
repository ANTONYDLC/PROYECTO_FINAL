using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new()
        {
        new Producto { Id = 1, Nombre = "La Perucha Clásica 🍔🔥", Descripcion = "Hamburguesa tradicional con queso y tomate.", Precio = 5.99m, ImagenUrl = "/images/ham_1.webp", Categoria = "Clásica", Valoracion = 4 },
        new Producto { Id = 2, Nombre = "La Criolla 🍔🔥", Descripcion = "Con su salsa criolla y toque peruano", Precio = 7.49m, ImagenUrl = "/images/ham_2.webp", Categoria = "Premium", Valoracion = 5 },
        new Producto { Id = 3, Nombre = "La Anticuchera 🍔🔥", Descripcion = "Con su carne marinada y papas nativas crocantes.", Precio = 6.25m, ImagenUrl = "/images/ham_3.webp", Categoria = "Especial", Valoracion = 3 },
        new Producto { Id = 4, Nombre = "La Lomo Saltado 🍔🔥", Descripcion = "Con su lomo saltado, papas fritas y salsa criolla.", Precio = 5.50m, ImagenUrl = "/images/ham_4.webp", Categoria = "Vegana", Valoracion = 4 },
        new Producto { Id = 5, Nombre = "La Huachana 🍔🔥", Descripcion = "Con su chorizo huachano, huevo frito y salsas peruanas.", Precio = 6.90m, ImagenUrl = "/images/ham_5.webp", Categoria = "Clásica", Valoracion = 5 },
        new Producto { Id = 6, Nombre = "La Trilogía Andina 🍔🔥", Descripcion = "Con su mezcla de res, alpaca y cerdo, queso andino y rocoto.", Precio = 6.75m, ImagenUrl = "/images/ham_6.webp", Categoria = "Premium", Valoracion = 4 },
        new Producto { Id = 7, Nombre = "Champiñones", Descripcion = "Con hongos salteados y salsa especial.", Precio = 6.40m, ImagenUrl = "/images/ham_1.webp", Categoria = "Especial", Valoracion = 3 },
        new Producto { Id = 8, Nombre = "Crispy Chicken", Descripcion = "Hamburguesa de pollo crujiente.", Precio = 6.20m, ImagenUrl = "/images/crispy.jpg", Categoria = "Pollo", Valoracion = 4 },
        new Producto { Id = 9, Nombre = "Hawaiana", Descripcion = "Con piña y salsa dulce.", Precio = 6.10m, ImagenUrl = "/images/hawaiana.jpg", Categoria = "Especial", Valoracion = 2 },
        new Producto { Id = 10, Nombre = "Blue Cheese", Descripcion = "Con queso azul y rúcula.", Precio = 6.85m, ImagenUrl = "/images/bluecheese.jpg", Categoria = "Premium", Valoracion = 5 },
        new Producto { Id = 11, Nombre = "Mexicana", Descripcion = "Con guacamole y nachos crujientes.", Precio = 6.50m, ImagenUrl = "/images/mexicana.jpg", Categoria = "Especial", Valoracion = 4 },
        new Producto { Id = 12, Nombre = "Deluxe", Descripcion = "Nuestra hamburguesa más completa y sabrosa.", Precio = 7.99m, ImagenUrl = "/images/deluxe.jpg", Categoria = "Deluxe", Valoracion = 5 }
        };

        public IActionResult Index() => View(productos);

        public static Producto? ObtenerPorId(int id) =>
            productos.FirstOrDefault(p => p.Id == id);
    }
}
