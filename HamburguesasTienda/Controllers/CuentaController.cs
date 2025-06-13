using HamburguesasTienda.Data;
using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamburguesasTienda.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AppDbContext _context;

        public CuentaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Cuenta/Registro
        public IActionResult Registro() => View();

        // POST: /Cuenta/Registro
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existe = await _context.Usuarios.AnyAsync(u => u.Email == model.Email);
                if (existe)
                {
                    ModelState.AddModelError("", "Este correo ya está registrado.");
                    return View(model);
                }

                var usuario = new Usuario
                {
                    Nombre = model.Nombre,
                    Email = model.Email,
                    Contraseña = model.Contraseña,
                    Rol = "Cliente"
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Cuenta/Login
        public IActionResult Login() => View();

        // POST: /Cuenta/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Contraseña == model.Contraseña);

            if (usuario != null)
            {
                HttpContext.Session.SetString("usuario", usuario.Email);
                HttpContext.Session.SetString("esAdmin", usuario.EsAdmin.ToString());

                return RedirectToAction("Inicio", "Home"); // redirección correcta
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
