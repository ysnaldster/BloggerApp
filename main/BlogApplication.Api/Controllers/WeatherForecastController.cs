using BlogApplication.Api;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")] // Dinamic Atribute Controller (Esto toma dinamicamente el nombre del controlador y se lo asigna. 
//Para que pueda accederse a la ruta /WeatherForeCast
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
    
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
        }
    }
    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("Get/weatherforecast")]
    //[Route("Get/weatherforecast2")]
    //Se pueden usar palabras dinamicas para tomar el nombre del método.
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }
    
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}