using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using asshole.Models;


public class WeatherController : Controller
{
    private readonly HttpClient _client = new HttpClient
    {
        DefaultRequestHeaders =
    {
        { "User-Agent", "MyAspNetApp (learning project)" }
    }
    };

    private const string url = "https://catfact.ninja/fact";

    // Метод контроллера, который вызывается при заходе на /Weather/Index
    public async Task<IActionResult> Index()
    {
        // 1. Делаем GET-запрос
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var code = response.StatusCode;
        
        global::System.Console.WriteLine(code);
        // 2. Читаем тело ответа
        string json = await response.Content.ReadAsStringAsync();

        //global::System.Console.WriteLine(json);
        // 3. Десериализуем JSON в объект
        CatFact data = JsonSerializer.Deserialize<CatFact>(json);

        // 4. Передаём данные во View
        return View(data);
    }
}
