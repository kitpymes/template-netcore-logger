// -----------------------------------------------------------------------
// <copyright file="SerilogServiceCollectionExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using System;
    using Kitpymes.Core.Logger.Abstractions;
    using Kitpymes.Core.Shared;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /*
       Clase de extensión SerilogServiceCollectionExtensions
       Contiene las extensiones de los servicios del logeo de errores para Serilog
    */

    /// <summary>
    /// Clase de extensión <c>SerilogServiceCollectionExtensions</c>.
    /// Contiene las extensiones de los servicios del logeo de errores para Serilogs.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones de los servicios para el logeo de errores de Serilog.</para>
    /// </remarks>
    public static class SerilogServiceCollectionExtensions
    {
        /// <summary>
        /// Carga el servicio de logeo de errores de Serilog.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="settings">Configuración de Serilog.</param>
        /// <returns>La interface ILoggerService.</returns>
        public static ILoggerService LoadSerilog(
            this IServiceCollection services,
            SerilogSettings settings)
        {
            services.TryAddSingleton<ILoggerService>(new SerilogProvider(settings));

            return services.BuildServiceProvider().GetService<ILoggerService>();
        }

        /// <summary>
        /// Carga el servicio de logeo de errores de Serilog.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <param name="options">Configuración de Serilog.</param>
        /// <returns>La interface ILoggerService.</returns>
        public static ILoggerService LoadSerilog(
            this IServiceCollection services,
            Action<SerilogOptions> options)
        => services.LoadSerilog(options.ToConfigureOrDefault().SerilogSettings);
    }
}
