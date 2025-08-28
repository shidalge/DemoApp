
using Prometheus;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

// Logging with Loki

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.GrafanaLoki(
        uri: "http://loki:3100",
        labels:
        [
            new LokiLabel { Key = "app", Value = "demo-app" }
        ]
    )
    .CreateLogger();

Log.Information("Aplicación iniciada correctamente");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para métricas HTTP
app.UseHttpMetrics();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoint para Prometheus
app.MapMetrics();

app.Run();
