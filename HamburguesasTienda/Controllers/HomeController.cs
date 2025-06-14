using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using Microsoft.Extensions.Logging;

namespace HamburguesasTienda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OpenWeatherService _climaService;

        // Inyección de logger y servicio del clima
        public HomeController(ILogger<HomeController> logger, OpenWeatherService climaService)
        {
            _logger = logger;
            _climaService = climaService;
        }

        // Página de inicio
        public async Task<IActionResult> Inicio()
        {
            _logger.LogInformation("Se accedió a la página de inicio.");

            var clima = await _climaService.ObtenerClimaAsync("Lima"); // Por defecto Lima
            ViewBag.Clima = clima;

            return View();
        }

        // ✅ Nueva acción para consultar clima por ciudad
        [HttpGet]
        public async Task<IActionResult> Clima(string ciudad)
        {
            if (!string.IsNullOrEmpty(ciudad))
            {
                try
                {
                    var clima = await _climaService.ObtenerClimaAsync(ciudad);
                    ViewBag.Clima = clima;
                    ViewBag.Ciudad = ciudad;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener clima.");
                    ViewBag.Error = "No se pudo obtener el clima.";
                }
            }

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

        // Página de política de privacidad
        public IActionResult Privacy()
        {
            _logger.LogInformation("Se accedió a la política de privacidad.");
            return View();
        }

        // Vista de errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Se generó un error en la aplicación.");
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
