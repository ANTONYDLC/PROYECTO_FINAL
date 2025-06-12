using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HamburguesasTienda.Controllers
{
    public class CarritoController : Controller
    {
        private const string SESSION_KEY = "carrito";

        public IActionResult Index()
        {
            var carrito = ObtenerCarrito();
            return View(carrito);
        }

        public IActionResult Agregar(int id)
        {
            var producto = ProductoController.ObtenerPorId(id);
            if (producto == null) return NotFound();

            var carrito = ObtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.ProductoId == id);
            if (item != null)
                item.Cantidad++;
            else
                carrito.Add(new CarritoItem
                {
                    ProductoId = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = 1
                });

            GuardarCarrito(carrito);
            return RedirectToAction("Index");
        }

        public IActionResult Quitar(int id)
        {
            var carrito = ObtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.ProductoId == id);
            if (item != null)
            {
                carrito.Remove(item);
                GuardarCarrito(carrito);
            }
            return RedirectToAction("Index");
        }

        private List<CarritoItem> ObtenerCarrito()
        {
            var json = HttpContext.Session.GetString(SESSION_KEY);
            return json == null ? new List<CarritoItem>() : JsonSerializer.Deserialize<List<CarritoItem>>(json)!;
        }

        private void GuardarCarrito(List<CarritoItem> carrito)
        {
            var json = JsonSerializer.Serialize(carrito);
            HttpContext.Session.SetString(SESSION_KEY, json);
        }
    }
}
