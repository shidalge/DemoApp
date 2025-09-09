using System.Collections.Generic;
using System.Linq;
using DemoApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class WeatherForecastControllerTests
{
    private readonly WeatherForecastController _controller;

    public WeatherForecastControllerTests()
    {
        _controller = new WeatherForecastController();
    }

    [Fact]
    public void Get_ReturnsFiveWeatherForecasts()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.NotNull(result);
        var forecasts = result.ToList();
        Assert.Equal(5, forecasts.Count);

        foreach (var forecast in forecasts)
        {
            // Comprobamos que la temperatura está en el rango esperado
            Assert.InRange(forecast.TemperatureC, -20, 55);
            // Comprobamos que la fecha es futura
            Assert.True(forecast.Date > DateOnly.FromDateTime(DateTime.Now));
            // Comprobamos que el resumen no es nulo ni vacío
            Assert.False(string.IsNullOrEmpty(forecast.Summary));
        }
    }

    [Fact]
    public void ForceInternalServerError_ReturnsStatusCode500()
    {
        // Act
        var result = _controller.ForceInternalServerError() as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Error forzado para pruebas de monitoreo", result.Value);
    }

    [Fact]
    public void ForceBadRequest_ReturnsStatusCode400()
    {
        // Act
        var result = _controller.ForceBadRequest() as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Solicitud inválida para pruebas de monitoreo", result.Value);
    }
}
