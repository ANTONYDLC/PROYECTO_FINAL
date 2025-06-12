using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using System.Collections.Generic;
using System.Linq;

namespace HamburguesasTienda.Controllers
{
    public class CuentaController : Controller
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            var encontrado = usuarios.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (encontrado != null)
            {
                HttpContext.Session.SetString("usuario", encontrado.Nombre);
                HttpContext.Session.SetString("rol", encontrado.EsAdmin ? "admin" : "cliente");

                return encontrado.EsAdmin
                    ? RedirectToAction("Panel", "Admin")
                    : RedirectToAction("Index", "Producto");
            }

            ViewBag.Error = "Credenciales inválidas.";
            return View();
        }

        public IActionResult Registro() => View();

        [HttpPost]
        public IActionResult Registro(Usuario nuevo)
        {
            usuarios.Add(nuevo);
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
