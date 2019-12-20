// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

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
        public const string DefaultOutputTemplate = "{Title}{NewLine}{Timestamp:HH:mm:ss:ff} [{Level:u3}] {Message:lj}{NewLine}";

        /// <summary>
        /// Nivel mínimo de error habilidato por defecto.
        /// </summary>
        public const LoggerLevel DefaultMinimumLevel = LoggerLevel.Info;

        private bool _enabled = false;

        private string _minimumLevel = DefaultMinimumLevel.ToString();

        private string _outputTemplate = DefaultOutputTemplate;

        /// <summary>
        /// Propiedad donde se setea si el logeo de errores de consola esta habiliato.
        /// </summary>
        public bool? Enabled
        {
            get => _enabled;
            set
            {
                if (value.HasValue)
                {
                    _enabled = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea si el nivel mínimo de error.
        /// </summary>
        public string MinimumLevel
        {
            get => _minimumLevel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _minimumLevel = value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea la plantilla de salida por defecto.
        /// </summary>
        public string? OutputTemplate
        {
            get => _outputTemplate;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _outputTemplate = value;
                }
            }
        }
    }
}
