// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    using Kitpymes.Core.Logger.Abstractions;

    /*
         Clase de configuración SerilogEmailSettings
         Contiene la configuración del logeo de errores de email
    */

    /// <summary>
    /// Clase de configuración <c>SerilogEmailSettings</c>.
    /// Contiene la configuración del logeo de errores de email.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las configuraciones para el logeo de errores de email.</para>
    /// </remarks>
    public class SerilogEmailSettings
    {
        /// <summary>
        /// Asunto del email por defecto.
        /// </summary>
        public const string DefaultSubject = "Log Error";

        /// <summary>
        /// Habilita el uso de Ssl por defecto.
        /// </summary>
        public const bool DefaultEnableSsl = true;

        /// <summary>
        /// Desabilita el uso de Body Html por defecto.
        /// </summary>
        public const bool DefaultIsBodyHtml = false;

        /// <summary>
        /// Número de puerto usado por defecto.
        /// </summary>
        public const int DefaultPort = 465;

        /// <summary>
        /// Plantilla de salida por defecto.
        /// </summary>
        public const string DefaultOutputTemplate = "SourceContext: {SourceContext} | MachineName: {MachineName} | Process: {Process} | Thread: {Thread} => {NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u}] {Message:lj}{NewLine}";

        /// <summary>
        /// Nivel mínimo de error habilidato por defecto.
        /// </summary>
        public const LoggerLevel DefaultMinimumLevel = LoggerLevel.Error;

        private bool _enabled = false;

        private bool _enableSsl = DefaultEnableSsl;

        private int _port = DefaultPort;

        private bool _isBodyHtml = DefaultIsBodyHtml;

        private string _subject = DefaultSubject;

        private string _minimumLevel = DefaultMinimumLevel.ToString();

        private string _outputTemplate = DefaultOutputTemplate;

        /// <summary>
        /// Propiedad donde se setea el nombre del usuario para el envio de email.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Propiedad donde se setea la contraseña para el envio de email.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Propiedad donde se setea el servidor para el envio de email.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// Propiedad donde se setea el email que envia el correo.
        /// </summary>
        public string? From { get; set; }

        /// <summary>
        /// Propiedad donde se setea el email a quien va dirigido el correo.
        /// </summary>
        public string? To { get; set; }

        /// <summary>
        /// Propiedad donde se setea si el logeo de errores de email esta habiliato.
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
        /// Propiedad donde se setea si el uso de Ssl esta habiliato.
        /// </summary>
        public bool? EnableSsl
        {
            get => _enableSsl;
            set
            {
                if (value.HasValue)
                {
                    _enableSsl = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea el puerto para el envio del email.
        /// </summary>
        public int? Port
        {
            get => _port;
            set
            {
                if (value.HasValue)
                {
                    _port = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea si el uso de Body Html esta habiliato.
        /// </summary>
        public bool? IsBodyHtml
        {
            get => _isBodyHtml;
            set
            {
                if (value.HasValue)
                {
                    _isBodyHtml = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea asunto del correo.
        /// </summary>
        public string? Subject
        {
            get => _subject;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _subject = value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea si el nivel mínimo de error.
        /// </summary>
        public string? MinimumLevel
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
