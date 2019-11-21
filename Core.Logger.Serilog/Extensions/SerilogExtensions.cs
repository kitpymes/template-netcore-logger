using Core.Logger.Abstractions;
using Serilog;
using Serilog.Events;
using System;
using System.Linq;
using System.Net;
using Seri = Serilog;

namespace Core.Logger.Serilog
{
    public static class SerilogExtensions
    {
        public static LoggerConfiguration AddDefaultSettings(this LoggerConfiguration loggerConfiguration)
        {
            Seri.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));

            Seri.Debugging.SelfLog.Enable(Console.Error);

            return loggerConfiguration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcess()
                .Enrich.WithThread();
        }

        public static LoggerConfiguration AddConsole(this LoggerConfiguration loggerConfiguration, SerilogConsoleSettings? settings)
        {
            if(settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                loggerConfiguration.WriteTo.Console
                (
                    theme: Seri.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code,

                    outputTemplate: settings.OutputTemplate,

                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel()
                );
            }

            return loggerConfiguration;
        }

        public static LoggerConfiguration AddFile(this LoggerConfiguration loggerConfiguration, SerilogFileSettings? settings)
        {
            if (settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                loggerConfiguration.WriteTo.Async(x => x.File
                (
                    formatter: new Seri.Formatting.Compact.RenderedCompactJsonFormatter(),

                    path: settings.FilePath,

                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel(),

                    rollingInterval: settings.Interval.ToRollingInterval(),

                    shared: true
                ));
            }

            return loggerConfiguration;
        }

        public static LoggerConfiguration AddEmail(this LoggerConfiguration loggerConfiguration, SerilogEmailSettings? settings)
        {
            if(settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                if (string.IsNullOrWhiteSpace(settings.UserName))
                    throw new ArgumentNullException(nameof(settings.UserName));

                if (string.IsNullOrWhiteSpace(settings.Password))
                    throw new ArgumentNullException(nameof(settings.Password));

                if (string.IsNullOrWhiteSpace(settings.Server))
                    throw new ArgumentNullException(nameof(settings.Server));

                if (string.IsNullOrWhiteSpace(settings.From))
                    throw new ArgumentNullException(nameof(settings.From));

                if (string.IsNullOrWhiteSpace(settings.To))
                    throw new ArgumentNullException(nameof(settings.To));

                if (!settings.Port.HasValue)
                    throw new ArgumentNullException(nameof(settings.Port));

                if (!settings.EnableSsl.HasValue)
                    throw new ArgumentNullException(nameof(settings.EnableSsl));

                loggerConfiguration.WriteTo.Email
                (
                    new Seri.Sinks.Email.EmailConnectionInfo
                    {
                        NetworkCredentials = new NetworkCredential
                        {
                            UserName = settings.UserName,
                            Password = settings.Password
                        },

                        MailServer = settings.Server,

                        Port = settings.Port.Value,

                        EnableSsl = settings.EnableSsl.Value,

                        FromEmail = settings.From,

                        ToEmail = settings.To,

                        EmailSubject = settings.Subject
                    },

                    outputTemplate: settings.OutputTemplate,

                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel()
                );
            }

            return loggerConfiguration;
        }

        public static LogEventLevel ToMinimumLevel(this LoggerMinimumLevel loggerMinimumLevel)
        {
            return loggerMinimumLevel.ToString().ToMinimumLevel();
        }

        public static LogEventLevel ToMinimumLevel(this string? loggerMinimumLevel)
        {
            var logEventLevel = loggerMinimumLevel switch
            {
                "Trace" => LogEventLevel.Verbose,
                "Debug" => LogEventLevel.Debug,
                "Info" => LogEventLevel.Information,
                "Error" => LogEventLevel.Error,
                "Fatal" => LogEventLevel.Fatal,
                _ => LogEventLevel.Information,
            };

            return logEventLevel;
        }

        public static RollingInterval ToRollingInterval(this LoggerInterval loggerInterval)
        {
            return loggerInterval.ToString().ToRollingInterval();
        }

        public static RollingInterval ToRollingInterval(this string? loggerInterval)
        {
            var rollingInterval = loggerInterval switch
            {
                "Infinite" => RollingInterval.Infinite,
                "Year" => RollingInterval.Year,
                "Month" => RollingInterval.Month,
                "Hour" => RollingInterval.Hour,
                "Minute" => RollingInterval.Minute,
                _ => RollingInterval.Day,
            };

            return rollingInterval;
        }
    }
}
