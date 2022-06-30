namespace DemoWebService;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public int TemperatureF => TemperatureC + 100;

    public string? Summary { get; set; }

    public string Test {get; set; }
}
