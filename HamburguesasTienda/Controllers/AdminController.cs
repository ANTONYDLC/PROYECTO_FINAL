using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using System.Linq;

namespace HamburguesasTienda.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Panel()
        {
            if (HttpContext.Session.GetString("rol") != "admin")
                return RedirectToAction("Login", "Cuenta");

            return View(CuentaController.usuarios);
        }

        public IActionResult Editar(string email)
        {
            var usuario = CuentaController.usuarios.FirstOrDefault(u => u.Email == email);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario actualizado)
        {
            var usuario = CuentaController.usuarios.FirstOrDefault(u => u.Email == actualizado.Email);
            if (usuario != null)
            {
                usuario.Nombre = actualizado.Nombre;
                usuario.Password = actualizado.Password;
                usuario.EsAdmin = actualizado.EsAdmin;
            }
            return RedirectToAction("Panel");
        }

        [HttpPost]
        public IActionResult Eliminar(string email)
        {
            var usuario = CuentaController.usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario != null)
                CuentaController.usuarios.Remove(usuario);

            return RedirectToAction("Panel");
        }
    }
}
