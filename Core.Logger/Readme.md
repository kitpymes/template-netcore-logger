# Core.Logger

The package provides interface and classe for **logger**.

## ILoggerService

```cs
public interface ILoggerService
{
    LoggerService CreateLogger(string sourceContext);

    LoggerService CreateLogger<TSourceContext>();

    void CloseLogger();

	LoggerService Error(string message);

    LoggerService Error(string message, object data);

    LoggerService Error(string eventName, string template, params object[] propertyValues);
    
	LoggerService Error(Exception exception);

    LoggerService Info(string message);

    LoggerService Info(string message, object data);

    LoggerService Info(string eventName, string template, params object[] propertyValues);
}
```

## AppSettings

```js
{
    "LoggerSettings": {
        "Serilog": {
            "Console": {
                "Enabled": null, // (bool) Default: false
                "MinimumLevel": null, // (string) Default: "Info" | Options: Info, Error
                "OutputTemplate": null // (string) Default: "{SourceContext} {MachineName} {Process} {Thread}{NewLine}{Timestamp:HH:mm:ss:ff} [{Level:u3}] {Message:lj}{NewLine}"
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
                "MinimumLevel": null, // (string) Default: "Error" | Options: Info, Error,
                "OutputTemplate": null // (string) Default: "{SourceContext} {MachineName} {Process} {Thread}{NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}"
            }
        }
    }
}
```

## Dependency Injection Logger

### Add logger

**Option 1**

```cs
services.LoadLogger(Configuration);
```

**Option 2**

```cs
services.LoadLogger(loggers =>
{
    loggers.UseSerilog(new SerilogSettings
    {
        // Custom values
    });
});
```

**Option 3**

```cs
services.LoadLogger(loggers =>
{
    loggers.UseSerilog(options =>
    {
        options.Console = new SerilogConsoleSettings
        {
            // Custom values
        };

        options.File = new SerilogFileSettings
        {
            // Custom values
        };

        options.Email = new SerilogEmailSettings()
        {
            // Custom values
        };
    });
});
```

### Use logger

```cs
private ILoggerService Logger { get; }

public WeatherForecastController(ILoggerService logger)
{
    Logger = logger.CreateLogger<WeatherForecastController>();
}
```

## Static Logger

### Use logger

**Option 1: Default logger**

```cs
 public class Program
{
    public static void Main(string[] args)
    {	
        var logger = Log.Serilog.CreateLogger<Program>();

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
        finally
        {
            logger.CloseLogger();
        }
    }
}
```

**Option 2: Custom logger**

```cs
 public class Program
{
    public static void Main(string[] args)
    {	
        var logger = Log.Serilog
			.Console(options =>
            {
                options.MinimumLevel = LoggerMinimumLevel.Debug.ToString();
                options.OutputTemplate = "{SourceContext}{NewLine}[{Level}] - {Message}{NewLine}";
            })
            .File(options =>
            {
                options.FilePath = "Logs\\CUSTOM_.log";
                options.MinimumLevel = LoggerMinimumLevel.Debug.ToString();
                options.Interval = LoggerInterval.Hour.ToString();
            })
            .Email
            (
                userName: "admin@app.com",
                password: "password",
                server: "smtp.gmail.com",
                from: "admin@app.com",
                to: "error@app.com"
            )
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
        finally
        {
            logger.CloseLogger();
        }
    }
}
```