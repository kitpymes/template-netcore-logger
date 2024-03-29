﻿// -----------------------------------------------------------------------
// <copyright file="SerilogEnrichersExtensions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using global::Serilog;
    using global::Serilog.Configuration;
    using global::Serilog.Context;
    using Kitpymes.Core.Shared;

    /*
        Clase de extensión SerilogEnrichersExtensions
        Contiene las extensiones de las propiedades del log
    */

    /// <summary>
    /// Clase de extensión <c>SerilogEnrichersExtensions</c>.
    /// Contiene las extensiones de las propiedades del log.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las extensiones de las propiedades para enriquecer el logeo de errores.</para>
    /// </remarks>
    public static class SerilogEnrichersExtensions
    {
        /// <summary>
        /// Agrega una propiedad con el id y nombre del hilo.
        /// </summary>
        /// <param name="enrichmentConfiguration">Controla la configuración de las propiedades.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration WithThread(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        => enrichmentConfiguration.ToIsNullOrEmptyThrow(nameof(enrichmentConfiguration)).With<ThreadEnricher>();

        /// <summary>
        /// Agrega una propiedad con el nombre de la máquina.
        /// </summary>
        /// <param name="enrichmentConfiguration">Controla la configuración de las propiedades.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration WithMachineName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
            => enrichmentConfiguration.ToIsNullOrEmptyThrow(nameof(enrichmentConfiguration)).With<MachineNameEnricher>();

        /// <summary>
        /// Agrega una propiedad con el id y el nombre del proceso.
        /// </summary>
        /// <param name="enrichmentConfiguration">Controla la configuración de las propiedades.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration WithProcess(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        => enrichmentConfiguration.ToIsNullOrEmptyThrow(nameof(enrichmentConfiguration)).With<ProcessEnricher>();

        /// <summary>
        /// Agrega una propiedad con el título del log.
        /// </summary>
        /// <param name="enrichmentConfiguration">Controla la configuración de las propiedades.</param>
        /// <param name="title">El título del log.</param>
        /// <returns>La clase LoggerConfiguration.</returns>
        public static LoggerConfiguration WithTitle(this LoggerEnrichmentConfiguration enrichmentConfiguration, string title)
        => enrichmentConfiguration.ToIsNullOrEmptyThrow(nameof(enrichmentConfiguration)).With(new TitleEnricher(title));
    }
}
