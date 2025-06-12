using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class CuentaController : Controller
    {
        private static List<Usuario> usuarios = new();

        public IActionResult Registro() => View();

        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (usuarios.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Este correo ya está registrado.");
                    return View(model);
                }

                usuarios.Add(new Usuario
                {
                    Nombre = model.Nombre,
                    Email = model.Email,
                    Contraseña = model.Contraseña,
                    EsAdmin = false
                });

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == model.Email && u.Contraseña == model.Contraseña);
            if (usuario != null)
            {
                HttpContext.Session.SetString("usuario", usuario.Email);
                HttpContext.Session.SetString("esAdmin", usuario.EsAdmin.ToString());
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}