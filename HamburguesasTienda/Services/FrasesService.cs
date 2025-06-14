using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HamburguesasTienda.Services
{
    public class FrasesService
    {
        private readonly HttpClient _httpClient;

        public FrasesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObtenerFraseAsync()
        {
            var response = await _httpClient.GetAsync("https://zenquotes.io/api/random");
            response.EnsureSuccessStatusCode();

            var contenido = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(contenido);
            var frase = json.RootElement[0].GetProperty("q").GetString();
            var autor = json.RootElement[0].GetProperty("a").GetString();

            return $"\"{frase}\" - {autor}";
        }
    }
}
