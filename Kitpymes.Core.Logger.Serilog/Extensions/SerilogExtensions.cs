// -----------------------------------------------------------------------
// <copyright file="SerilogExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using System.Net;
    using global::Serilog;
    using Kitpymes.Core.Shared;
    using Seri = global::Serilog;

    /*
        Clase de extensión SerilogExtensions
        Contiene las extensiones del logeo de errores
    */

    /// <summary>
    /// Clase de extensión <c>SerilogExtensions</c>.
    /// Contiene las extensiones del logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones para el logeo de errores.</para>
    /// </remarks>
    public static class SerilogExtensions
    {
        /// <summary>
        /// Agrega las propiedades por defecto del log.
        /// </summary>
        /// <param name="loggerConfiguration">Objeto de configuración para crear instancias Serilog.ILogger.</param>
        /// <param name="title">El título del log.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration AddDefaultSettings(this LoggerConfiguration loggerConfiguration, string title)
        => loggerConfiguration.ToIsNullOrEmptyThrow(nameof(loggerConfiguration))
            .Enrich.FromLogContext()
            .Enrich.WithTitle(title)
            .Enrich.WithMachineName()
            .Enrich.WithProcess()
            .Enrich.WithThread();

        /// <summary>
        /// Habilita el log de consola.
        /// </summary>
        /// <param name="loggerConfiguration">Objeto de configuración para crear instancias Serilog.ILogger.</param>
        /// <param name="settings">Configuración del log de consola.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration AddConsole(this LoggerConfiguration loggerConfiguration, SerilogConsoleSettings? settings)
        {
            if (settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                loggerConfiguration.ToIsNullOrEmptyThrow(nameof(loggerConfiguration)).WriteTo.Console(
                    theme: Seri.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code,
                    outputTemplate: settings.OutputTemplate,
                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel());
            }

            return loggerConfiguration;
        }

        /// <summary>
        /// Habilita el log de archivos.
        /// </summary>
        /// <param name="loggerConfiguration">Objeto de configuración para crear instancias Serilog.ILogger.</param>
        /// <param name="settings">Configuración del log de archivos.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration AddFile(this LoggerConfiguration loggerConfiguration, SerilogFileSettings? settings)
        {
            if (settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                loggerConfiguration.ToIsNullOrEmptyThrow(nameof(loggerConfiguration)).WriteTo.Async(x => x.File(
                    formatter: new Seri.Formatting.Json.JsonFormatter(),
                    path: settings.FilePath,
                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel(),
                    rollingInterval: settings.Interval.ToRollingInterval(),
                    shared: true));
            }

            return loggerConfiguration;
        }

        /// <summary>
        /// Habilita el log de envio de email.
        /// </summary>
        /// <param name="loggerConfiguration">Objeto de configuración para crear instancias Serilog.ILogger.</param>
        /// <param name="settings">Configuración del log de envio de email.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration AddEmail(this LoggerConfiguration loggerConfiguration, SerilogEmailSettings? settings)
        {
            if (settings != null && settings.Enabled.HasValue && settings.Enabled.Value)
            {
                settings.UserName.ToIsNullOrEmptyThrow(nameof(settings.UserName));
                settings.Password.ToIsNullOrEmptyThrow(nameof(settings.Password));
                settings.From.ToIsNullOrEmptyThrow(nameof(settings.From));
                settings.To.ToIsNullOrEmptyThrow(nameof(settings.To));
                settings.Port.ToIsNullOrEmptyThrow(nameof(settings.Port));
                settings.EnableSsl.ToIsNullOrEmptyThrow(nameof(settings.EnableSsl));

                loggerConfiguration.ToIsNullOrEmptyThrow(nameof(loggerConfiguration)).WriteTo.Email(
                    new Seri.Sinks.Email.EmailConnectionInfo
                    {
                        NetworkCredentials = new NetworkCredential
                        {
                            UserName = settings.UserName,
                            Password = settings.Password,
                        },
                        MailServer = settings.Server,
                        Port = settings.Port.Value,
                        EnableSsl = settings.EnableSsl.Value,
                        FromEmail = settings.From,
                        ToEmail = settings.To,
                        EmailSubject = settings.Subject,
                    },
                    outputTemplate: settings.OutputTemplate,
                    restrictedToMinimumLevel: settings.MinimumLevel.ToMinimumLevel());
            }

            return loggerConfiguration;
        }

        /// <summary>
        /// Convierte el nivel del log génerico al nivel de log de Serilog.
        /// </summary>
        /// <param name="loggerLevel">El nivel mínimo habilitado para el log de errores.</param>
        /// <returns>El nivel mínimo de serilog LogEventLevel.</returns>
        public static Seri.Events.LogEventLevel ToMinimumLevel(this Abstractions.LoggerLevel loggerLevel)
        {
            return loggerLevel.ToString().ToMinimumLevel();
        }

        /// <summary>
        /// Convierte el nivel del log génerico al nivel de log de Serilog.
        /// </summary>
        /// <param name="loggerLevel">El nivel mínimo habilitado para el log de errores.</param>
        /// <param name="defaulLevel">Nivel por defecto a devolver.</param>
        /// <returns>El nivel mínimo de serilog LogEventLevel.</returns>
        public static Seri.Events.LogEventLevel ToMinimumLevel(this string? loggerLevel, Seri.Events.LogEventLevel defaulLevel = Seri.Events.LogEventLevel.Information)
        {
            var logEventLevel = loggerLevel switch
            {
                "Trace" => Seri.Events.LogEventLevel.Verbose,
                "Debug" => Seri.Events.LogEventLevel.Debug,
                "Info" => Seri.Events.LogEventLevel.Information,
                "Error" => Seri.Events.LogEventLevel.Error,
                "Fatal" => Seri.Events.LogEventLevel.Fatal,
                _ => defaulLevel,
            };

            return logEventLevel;
        }

        /// <summary>
        /// Convierte el intervalo génerico para la creación de archivos a el intervalo génerico de Serilog.
        /// </summary>
        /// <param name="loggerInterval">El intervalo génerico para la creación de archivos.</param>
        /// <returns>El intervalo de Serilog RollingInterval.</returns>
        public static RollingInterval ToRollingInterval(this Abstractions.LoggerFileInterval loggerInterval)
        {
            return loggerInterval.ToString().ToRollingInterval();
        }

        /// <summary>
        /// Convierte el intervalo génerico para la creación de archivos a el intervalo génerico de Serilog.
        /// </summary>
        /// <param name="loggerInterval">El intervalo génerico para la creación de archivos.</param>
        /// <param name="defaulInterval">Intervalo por defecto a devolver.</param>
        /// <returns>El intervalo de Serilog RollingInterval.</returns>
        public static RollingInterval ToRollingInterval(this string? loggerInterval, RollingInterval defaulInterval = RollingInterval.Day)
        {
            var rollingInterval = loggerInterval switch
            {
                "Infinite" => RollingInterval.Infinite,
                "Year" => RollingInterval.Year,
                "Month" => RollingInterval.Month,
                "Hour" => RollingInterval.Hour,
                "Minute" => RollingInterval.Minute,
                _ => defaulInterval,
            };

            return rollingInterval;
        }
    }
}
