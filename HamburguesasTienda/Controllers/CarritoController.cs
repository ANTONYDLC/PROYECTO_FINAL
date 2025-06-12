using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using System.Collections.Generic;
using System.Linq;
using HamburguesasTienda.Helpers;


namespace HamburguesasTienda.Controllers
{
    public class CarritoController : Controller
    {
        private const string CarritoKey = "carrito";

        public IActionResult Index()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>(CarritoKey) ?? new List<Producto>();
            return View(carrito);
        }

        public IActionResult Agregar(int id)
        {
            var producto = ProductoController.productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                var carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>(CarritoKey) ?? new List<Producto>();
                carrito.Add(producto);
                HttpContext.Session.SetObjectAsJson(CarritoKey, carrito);
            }
            return RedirectToAction("Index", "Producto");
        }

        public IActionResult Eliminar(int id)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<Producto>>(CarritoKey);
            if (carrito != null)
            {
                var producto = carrito.FirstOrDefault(p => p.Id == id);
                if (producto != null)
                    carrito.Remove(producto);

                HttpContext.Session.SetObjectAsJson(CarritoKey, carrito);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Pagar()
        {
            HttpContext.Session.Remove(CarritoKey);
            ViewBag.Mensaje = "Gracias por tu compra 🧾🍔";
            return View();
        }
    }
}
