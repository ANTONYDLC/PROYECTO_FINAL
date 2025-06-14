using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class OpenWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "2bee68b246f0ceefa5159b835dcc18e9"; // Reemplaza con tu clave real

    public OpenWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ObtenerClimaAsync(string ciudad)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={_apiKey}&units=metric&lang=es";
        var respuesta = await _httpClient.GetAsync(url);

        if (!respuesta.IsSuccessStatusCode)
        {
            return "No se pudo obtener el clima.";
        }

        var contenido = await respuesta.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(contenido);
        var descripcion = json.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();
        var temperatura = json.RootElement.GetProperty("main").GetProperty("temp").GetDecimal();

        return $"{descripcion}, {temperatura}°C";
    }
}
