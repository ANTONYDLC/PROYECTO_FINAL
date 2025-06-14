using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HamburguesasTienda.Models;
using Microsoft.Extensions.Logging;
using HamburguesasTienda.Services;
using System.Text.Json;


namespace HamburguesasTienda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OpenWeatherService _climaService;
        
        // Inyección de logger y servicios
        public HomeController(
            ILogger<HomeController> logger,
            OpenWeatherService climaService
        )
        {
            _logger = logger;
            _climaService = climaService;
            
        }

        // Página de inicio
        public async Task<IActionResult> Inicio()
        {
            _logger.LogInformation("Se accedió a la página de inicio.");

            var clima = await _climaService.ObtenerClimaAsync("Lima");
            ViewBag.Clima = clima;
             // Obtener frase motivacional
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var respuesta = await httpClient.GetStringAsync("https://zenquotes.io/api/random");
                    var datos = JsonSerializer.Deserialize<List<FraseModel>>(respuesta);
                    ViewBag.Frase = datos?[0]?.q + " — " + datos?[0]?.a;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("No se pudo obtener la frase motivacional: " + ex.Message);
                    ViewBag.Frase = null;
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

        // Página de Delivery
        public IActionResult Delivery()
        {
            
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
