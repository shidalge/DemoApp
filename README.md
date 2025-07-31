# DemoApp

Este proyecto es una **demo de una API REST** construida con **ASP.NET Core Web API (.NET 8)**.

## ✨ Características

- Utiliza el controlador por defecto `WeatherForecastController`, que devuelve una lista de objetos con datos simulados de clima.
- Incluye un controlador adicional llamado `DemoController`, que expone un endpoint `GET` que devuelve un número incremental en cada solicitud, comenzando desde 0.

## 📂 Estructura del proyecto

- `Controllers/WeatherForecastController.cs`: controlador generado por defecto al crear el proyecto, útil como ejemplo de estructura básica de un endpoint RESTful.
- `Controllers/DemoController.cs`: controlador personalizado que implementa una lógica simple de contador en memoria.

## 🚀 Cómo ejecutar

1. Ejecuta el proyecto desde Visual Studio (`Ctrl + F5`) o con `dotnet run`.
2. Accede a Swagger UI en `https://localhost:{puerto}/swagger` para probar los endpoints disponibles.

## 📌 Notas

- El contador del `DemoController` se almacena en memoria y se reinicia al reiniciar la aplicación.
- Este proyecto está diseñado con fines demostrativos.

## Test
This is a test for GitHub Pull Request in Port.
