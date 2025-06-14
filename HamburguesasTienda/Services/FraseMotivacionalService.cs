using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class FraseMotivacionalService
{
    private readonly HttpClient _http;

    public FraseMotivacionalService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> ObtenerFraseTraducidaAsync()
    {
        // 1. Obtener frase en inglés de ZenQuotes
        var respuesta = await _http.GetFromJsonAsync<List<ZenQuote>>("https://zenquotes.io/api/random");
        var fraseIngles = respuesta?[0].q + " - " + respuesta?[0].a;

        // 2. Traducir al español usando LibreTranslate
        var requestData = new
        {
            q = fraseIngles,
            source = "en",
            target = "es",
            format = "text"
        };

        var content = JsonContent.Create(requestData);
        var respuestaTraduccion = await _http.PostAsync("https://libretranslate.com/translate", content);
        var json = await respuestaTraduccion.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);
        var fraseTraducida = doc.RootElement.GetProperty("translatedText").GetString();

        return fraseTraducida ?? fraseIngles;
    }

    private class ZenQuote
    {
        public string q { get; set; }
        public string a { get; set; }
    }
}
