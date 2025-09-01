using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController() : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Log.Information("Weather info returned");

            return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })];
        }

        [HttpGet("force500")]
        public IActionResult ForceInternalServerError()
        {
            Log.Error("Error 500: Este es un log de prueba desde la app .NET");
            return StatusCode(500, "Error forzado para pruebas de monitoreo");
        }


        [HttpGet("force400")]
        public IActionResult ForceBadRequest()
        {
            Log.Warning("Error 400: Testing");

            return BadRequest("Solicitud inválida para pruebas de monitoreo");
        }
    }
}
