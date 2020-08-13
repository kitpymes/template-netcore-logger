// -----------------------------------------------------------------------
// <copyright file="LoggerServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger
{
    using System;
    using Kitpymes.Core.Logger.Serilog;
    using Kitpymes.Core.Shared;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /*
        Clase de extensión LoggerServiceCollectionExtensions
        Contiene las extensiones de los servicios del logeo de errores
    */

    /// <summary>
    /// Clase de extensión <c>LoggerServiceCollectionExtensions</c>.
    /// Contiene las extensiones de los servicios del logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones de los servicios para el logeo de errores.</para>
    /// </remarks>
    public static class LoggerServiceCollectionExtensions
    {
        /// <summary>
        /// Carga el servicio de logeo de errores.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="configuration">El appsettings con su configuración.</param>
        /// <returns>La interface IServiceCollection.</returns>
        public static IServiceCollection LoadLogger(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration?.GetSection(nameof(LoggerSettings))?.Get<LoggerSettings>();

            if (settings?.SerilogSettings != null)
            {
                services.LoadSerilog(settings.SerilogSettings);
            }

            return services;
        }

        /// <summary>
        /// Carga el servicio de logeo de errores.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Las opciones personalizadas.</param>
        /// <returns>La interface IServiceCollection.</returns>
        public static IServiceCollection LoadLogger(this IServiceCollection services, Action<LoggerOptions> options)
        {
            var settings = options.ToConfigureOrDefault();

            if (settings.IsSerilogEnabled)
            {
                services.LoadSerilog(settings.SerilogOptions);
            }

            return services;
        }
    }
}
