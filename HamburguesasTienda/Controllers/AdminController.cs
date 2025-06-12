using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class AdminController : Controller
    {
        private static List<Usuario> usuarios => CuentaControllerReflection.GetUsuarios();

        public IActionResult Panel()
        {
            if (!EsAdmin()) return RedirectToAction("Login", "Cuenta");
            return View(usuarios);
        }

        public IActionResult Editar(string email)
        {
            var user = usuarios.FirstOrDefault(u => u.Email == email);
            return View(user);
        }

        [HttpPost]
        public IActionResult Editar(Usuario userEditado)
        {
            var user = usuarios.FirstOrDefault(u => u.Email == userEditado.Email);
            if (user != null)
            {
                user.Nombre = userEditado.Nombre;
                user.EsAdmin = userEditado.EsAdmin;
            }
            return RedirectToAction("Panel");
        }

        [HttpPost]
        public IActionResult Eliminar(string email)
        {
            var user = usuarios.FirstOrDefault(u => u.Email == email);
            if (user != null) usuarios.Remove(user);
            return RedirectToAction("Panel");
        }

        private bool EsAdmin()
        {
            return HttpContext.Session.GetString("esAdmin") == "True";
        }
    }

    // Simulación de acceso estático a usuarios desde CuentaController
    public static class CuentaControllerReflection
    {
        private static List<Usuario>? _usuariosField;

        public static List<Usuario> GetUsuarios()
        {
            if (_usuariosField == null)
            {
                // Acceso al campo privado del otro controlador (hack simple para ejemplo sin DB)
                var cuentaControllerType = typeof(CuentaController);
                var field = cuentaControllerType.GetField("usuarios", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                _usuariosField = field?.GetValue(null) as List<Usuario> ?? new List<Usuario>();
            }
            return _usuariosField;
        }
    }
}
