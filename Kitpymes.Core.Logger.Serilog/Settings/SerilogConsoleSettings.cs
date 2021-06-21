// -----------------------------------------------------------------------
// <copyright file="SerilogConsoleSettings.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using Kitpymes.Core.Logger.Abstractions;

    /*
         Clase de configuración SerilogConsoleSettings
         Contiene la configuración del logeo de errores de consola
    */

    /// <summary>
    /// Clase de configuración <c>SerilogConsoleSettings</c>.
    /// Contiene la configuración del logeo de errores de consola.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las configuraciones para el logeo de errores de consola.</para>
    /// </remarks>
    public class SerilogConsoleSettings
    {
        /// <summary>
        /// Plantilla de salida por defecto.
        /// </summary>
        public const string DefaultOutputTemplate = "{NewLine}{Timestamp:HH:mm:ss:fff} | {Title} {Level:u3} {Message:lj}";

        /// <summary>
        /// Nivel mínimo de error habilidato por defecto.
        /// </summary>
        public const LoggerLevel DefaultMinimumLevel = LoggerLevel.Info;

        private bool enabled;

        private string minimumLevel = DefaultMinimumLevel.ToString();

        private string outputTemplate = DefaultOutputTemplate;

        /// <summary>
        /// Obtiene o establece si el logeo de errores de consola esta habiliato.
        /// </summary>
        public bool? Enabled
        {
            get => this.enabled;
            set
            {
                if (value.HasValue)
                {
                    this.enabled = value.Value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nivel mínimo de error.
        /// </summary>
        public string MinimumLevel
        {
            get => this.minimumLevel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.minimumLevel = value;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la plantilla de salida por defecto.
        /// </summary>
        public string? OutputTemplate
        {
            get => this.outputTemplate;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.outputTemplate = value;
                }
            }
        }
    }
}
