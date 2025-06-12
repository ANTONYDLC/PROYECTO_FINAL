using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;

namespace HamburguesasTienda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Página de inicio
        public IActionResult Index()
        {
            _logger.LogInformation("Se accedió a la página de inicio.");
            return View();
        }

        // Página de contacto
        public IActionResult Contacto()
        {
            _logger.LogInformation("Se accedió a la página de contacto.");
            return View();
        }

        // Página acerca de
        public IActionResult Acerca()
        {
            _logger.LogInformation("Se accedió a la página acerca de.");
            return View();
        }

        // Página de privacidad
        public IActionResult Privacy()
        {
            _logger.LogInformation("Se accedió a la política de privacidad.");
            return View();
        }

        // Página de error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Se generó un error en la aplicación.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
