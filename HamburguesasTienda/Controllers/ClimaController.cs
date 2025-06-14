using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburguesasTienda.Controllers
{
    public class ClimaController : Controller
    {
        private readonly OpenWeatherService _climaService;

        public ClimaController(OpenWeatherService climaService)
        {
            _climaService = climaService;
        }

        public async Task<IActionResult> Index(string ciudad = "Lima")
        {
            var clima = await _climaService.ObtenerClimaAsync(ciudad);
            return View(clima);
        }
    }
}
