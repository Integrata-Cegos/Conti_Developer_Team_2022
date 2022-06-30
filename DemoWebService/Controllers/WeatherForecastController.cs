using Microsoft.AspNetCore.Mvc;

namespace DemoWebService.Controllers;

[ApiController]
[Route("[controller]")]
public class WetterAussichtenController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private static readonly string[] Countries = new[]
    {
        "Germany", "Algeria", "Haiti", "Malawi", "Egypt", "Monaco", "Zimbabwe", "Sierra Leone", "Thailand", "Afghanistan", "Uruguay", "United Kingdom",
        "Brazil", "Cambodia", "Cuba", "Dominican Republic", "France" 
    };

    private readonly ILogger<WetterAussichtenController> _logger;

    public WetterAussichtenController(ILogger<WetterAussichtenController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Country = Countries[Random.Shared.Next(Countries.Length)]
        })
        .ToArray();
    }
}
