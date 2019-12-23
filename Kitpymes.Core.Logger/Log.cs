// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger
{
    using System;
    using Kitpymes.Core.Logger.Abstractions;
    using Kitpymes.Core.Logger.Serilog;
    using Microsoft.Extensions.Configuration;

    /*
      Clase de opciones para el logeo de errores estático
      Contiene las opciones para configurar el logeo de errores estático
    */

    /// <summary>
    /// Clase de para el <c>Log</c> estático.
    /// Contiene las opciones para configurar el logeo de errores estático.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las opciones de configuración para los proveedores de errores estático.</para>
    /// </remarks>
    public static class Log
    {
        /// <summary>
        /// Habilita el proveedor de errores Serilog.
        /// </summary>
        /// <param name="configuration">El appsettings con su configuración.</param>
        /// <returns>La interface ILoggerService.</returns>
        public static ILoggerService UseSerilog(IConfiguration configuration)
        {
            var settings = configuration?.GetSection(nameof(LoggerSettings))?.Get<LoggerSettings>();

            var serilog = settings?.Serilog;

            return new SerilogProvider(serilog ??= new SerilogSettings());
        }

        /// <summary>
        /// Habilita el proveedor de errores Serilog.
        /// </summary>
        /// <param name="options">Las opciones del proveedor de errores Serilog.</param>
        /// <returns>La interface ILoggerService.</returns>
        public static ILoggerService UseSerilog(Action<SerilogOptions> options) 
        => UseSerilog(options.ToConfigureOrDefault().SerilogSettings);

        /// <summary>
        /// Habilita el proveedor de errores Serilog.
        /// </summary>
        /// <param name="settings">La configuración del proveedor de errores Serilog.</param>
        /// <returns>La interface ILoggerService.</returns>
        public static ILoggerService UseSerilog(SerilogSettings settings)
        => new SerilogProvider(settings);
    }
}
