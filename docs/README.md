﻿# Logger

_Logeo de errores para multiples proveedores_

<p align="left">
  <a href="https://github.com/kitpymes/netcore-logger/actions">
	<img alt="GitHub Actions status" src="https://github.com/actions/setup-dotnet/workflows/Main%20workflow/badge.svg">
  </a>
</p>

## 🚀 Comenzando 

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

Mira **Instalación** para conocer como desplegar el proyecto.

### 📋 Pre-requisitos 

_- Tener instalado Visual Studio >= 2019_

_- Tener instalada una version >= .NET Core 3_

_- Conocer sobre inyección de dependencia_


### 🔧 Instalación 

**Opcion 1: Descargar ZIP**

![Descargar ZIP](screenshot/instalacion_zip.png)

**Opcion 2: Clonar**

| Copiar link | Clonar proyecto |
| :---: | :---: |
| ![Copiar link para clonar](screenshot/instalacion_clonar_github.png)  |  ![Clonamos el proyecto](screenshot/instalacion_clonar_visualstudio.png)  |


**NOTAS**

```
- Si descargamos el proyecto no copiarlo en el escritorio, es posible que tengamos problemas con los permisos de escritura.

- Para probar el envio de email, es posible que tengamos problemas de permisos con nuestro proveedor, eso pasa con gmail por ejemplo.
```

## ⌨️ Código

### ILoggerService

```cs
public interface ILoggerService
{
    ILogger CreateLogger(string sourceContext);

    ILogger CreateLogger<TSourceContext>();
}
```

### ILogger

```cs
public interface ILogger
{
	ILogger Info(string message);

	ILogger Info(string message, object data);

	ILogger Info(string eventName, string template, params object[] propertyValues);

	ILogger Error(string message);

	ILogger Error(string message, object data);

	ILogger Error(string eventName, string template, params object[] propertyValues);

	ILogger Error(Exception exception);
}
```

### AppSettings

```js
{
    "LoggerSettings": {
        "Serilog": {
            "Console": {
                "Enabled": null, // (bool) Default: false
                "MinimumLevel": null, // (string) Default: "Info" | Options: Info, Error
                "OutputTemplate": null // (string) Default: "{SourceContext}{NewLine}{Timestamp:HH:mm:ss:ff} [{Level:u3}] {Message:lj}{NewLine}"
            },
            "File": {
                "Enabled": null, // (bool) Default: false
                "FilePath": null, // (string) Default: "Logs\\.log"
                "Interval": null, // (string) Default: "Day" | Options: Infinite, Year, Month, Day, Hour, Minute
                "MinimumLevel": null // (string) Default: "Error" | Options: Info, Error
            },
            "Email": {
                "Enabled": null, // (bool) Default: false
                "UserName": null, // (string)
                "Password": null, // (string)
                "Server": null, // (string)
                "From": null, // (string)
                "To": null, // (string)
                "EnableSsl": null, // (bool) Default: true
                "Port": null, // (int) Default: 465
                "Subject": null, // (string) Default: "Log Error"
				"IsBodyHtml": null, // (bool) Default: false
                "MinimumLevel": null, // (string) Default: "Error" | Options: Info, Error,
                "OutputTemplate": null // (string) Default: "SourceContext: {SourceContext} | MachineName: {MachineName} | Process: {Process} | Thread: {Thread} => {NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u}] {Message:lj}{NewLine}"
            }
        }
    }
}
```

### Como cargar el logeo de errores para ser utilizado con inyección de dependencia ?

**Option 1**

```cs
services.LoadLogger(Configuration);
```

**Option 2**

```cs
services.LoadLogger(loggers =>
{
    loggers.UseSerilog(serilog =>
    {
		serilog
			.AddConsole()
			.AddFile()
			.AddEmail
			(
				userName: "admin@app.com", 
				password: "password",
				server: "smtp.gmail.com",
				from: "admin@app.com",
				to: "error@app.com"
			);
    });
});
```

### Como utilizar el logeo de errores con inyección de dependencia ?

```cs
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private ILogger Logger { get; }

    public WeatherForecastController(ILoggerService logger)
    {
        Logger = logger.CreateLogger<WeatherForecastController>();
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        // Enable and customize logger in appsettings, or in Startup class.
        Logger
            .Info("Get Summaries")
            .Info("Summary 1", Summaries[0])
            .Info("Summary 2", Summaries[1])
            .Info("Summary 3", Summaries[2])
            .Info("All Summaries", Summaries);

        var rng = new Random();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
```

### Como cargar el logeo de errores estático ?

**Option 1**

```cs
var logger = Log.UseSerilog(serilog => 
{
	serilog
		.AddConsole()
		.AddFile()
		.AddEmail
		(
			userName: "admin@app.com", 
			password: "password",
			server: "smtp.gmail.com",
			from: "admin@app.com",
			to: "error@app.com"
		);
})
.CreateLogger<Program>();
```

**Option 2**

```cs
var logger = Log.UseSerilog(new SerilogSettings 
{
	// Custom values

}).CreateLogger<Program>();
```

### Como utilizar el logeo de errores estático ?

```cs
public class Program
{
    public static void Main(string[] args)
    {	
        var logger = Log.UseSerilog(serilog => 
		{
			serilog
				.AddConsole()
				.AddFile()
				.AddEmail
				(
					userName: "admin@app.com", 
					password: "password",
					server: "smtp.gmail.com",
					from: "admin@app.com",
					to: "error@app.com"
				);
		})
		.CreateLogger<Program>();

        try
        {
            logger.Info("Init Host...");

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex);

            throw ex;
        }
    }
}
```

## 🔩 Resultados

**Resultado en la consola**

![Resultado en la consola](screenshot/resultados_consola.png)


**Resultado en los archivos**

![Resultado en los archivos](screenshot/resultados_archivos.png)


## ⚙️ Pruebas Unitarias

_Cada proveedor de logeo de errores tiene su proyecto de test, se ejecutan desde el "Explorador de pruebas"_

![Tests](screenshot/pruebas_unitarias.png)


## 🛠️ Construido con 

* [NET Core](https://dotnet.microsoft.com/download) - Framework de trabajo
* [C#](https://docs.microsoft.com/es-es/dotnet/csharp/) - Lenguaje de programación
* [Inserción de dependencias](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0) - Patrón de diseño de software
* [MSTest](https://docs.microsoft.com/es-es/dotnet/core/testing/unit-testing-with-mstest) - Pruebas unitarias
* [Nuget](https://www.nuget.org/) - Manejador de dependencias
* [Visual Studio](https://visualstudio.microsoft.com/) - Entorno de programacion
* [Serilog](https://serilog.net/) - Proveedor de logeo de errores


## ✒️ Autores 

* **Kitpymes** - *Trabajo Inicial* - [kitpymes](https://github.com/kitpymes)


## 📄 Licencia 

Este proyecto está bajo la Licencia [LICENSE.md](LICENSE.md)


## 🎁 Gratitud 

* Este proyecto fue diseñado para compartir, creemos que es la mejor forma de ayudar 📢
* Cada persona que contribuya sera invitada a tomar una 🍺 
* Gracias a todos! 🤓

---
[Kitpymes](https://github.com/kitpymes) 😊