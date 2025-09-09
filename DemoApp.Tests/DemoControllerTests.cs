using DemoApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Xunit;

public class DemoControllerTests
{
    private readonly DemoController _controller;

    public DemoControllerTests()
    {
        // Reiniciamos el contador para que los tests sean consistentes
        ResetCounter();
        _controller = new DemoController();
    }

    private void ResetCounter()
    {
        var field = typeof(DemoController).GetField("_contador", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new InvalidOperationException("No se encontró el campo '_contador' en DemoController");
        field.SetValue(null, -1);
    }


    [Fact]
    public void Get_ReturnsIncrementedValuesSequentially()
    {
        // Act & Assert
        var result1 = _controller.Get() as OkObjectResult;
        Assert.NotNull(result1);
        var value1 = result1!.Value;
        Assert.Equal(0, value1);

        var result2 = _controller.Get() as OkObjectResult;
        Assert.NotNull(result2);
        var value2 = result2!.Value;
        Assert.Equal(1, value2);

        var result3 = _controller.Get() as OkObjectResult;
        Assert.NotNull(result3);
        var value3 = result3!.Value;
        Assert.Equal(2, value3);
    }

}
