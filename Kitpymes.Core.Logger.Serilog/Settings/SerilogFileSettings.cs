// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    using Kitpymes.Core.Logger.Abstractions;

    /*
        Clase de configuración SerilogFileSettings
        Contiene la configuración del logeo de errores de archivo
   */

    /// <summary>
    /// Clase de configuración <c>SerilogFileSettings</c>.
    /// Contiene la configuración del logeo de errores de archivo.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las configuraciones para el logeo de errores de archivo.</para>
    /// </remarks>
    public class SerilogFileSettings
    {
        /// <summary>
        /// Nombre de los archivos por defecto.
        /// </summary>
        public const string DefaultFilePath = @"Logs\\.log";

        /// <summary>
        /// Nivel mínimo de error habilidato por defecto.
        /// </summary>
        public const LoggerLevel DefaultMinimumLevel = LoggerLevel.Error;

        /// <summary>
        /// Intervalo de creación de archivos por defecto.
        /// </summary>
        public const LoggerFileInterval DefaultLoggerInterval = LoggerFileInterval.Day;

        private bool enabled = false;

        private string filePath = DefaultFilePath;

        private string minimumLevel = DefaultMinimumLevel.ToString();

        private string interval = DefaultLoggerInterval.ToString();

        /// <summary>
        /// Propiedad donde se setea si el logeo de errores de archivos esta habiliato.
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
        /// Propiedad donde se setea la ruta donde se generaran los archivos de errores.
        /// </summary>
        public string? FilePath
        {
            get => this.filePath;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.filePath = value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea si el nivel mínimo de error.
        /// </summary>
        public string? MinimumLevel
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
        /// Propiedad donde se setea el intervalo para la creación de archivos.
        /// </summary>
        public string? Interval
        {
            get => this.interval;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.interval = value;
                }
            }
        }
    }
}
