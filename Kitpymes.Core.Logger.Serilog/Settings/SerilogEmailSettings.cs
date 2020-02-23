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

        private bool enabled = false;

        private bool enableSsl = DefaultEnableSsl;

        private int port = DefaultPort;

        private bool isBodyHtml = DefaultIsBodyHtml;

        private string subject = DefaultSubject;

        private string minimumLevel = DefaultMinimumLevel.ToString();

        private string outputTemplate = DefaultOutputTemplate;

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
        /// Propiedad donde se setea si el uso de Ssl esta habiliato.
        /// </summary>
        public bool? EnableSsl
        {
            get => this.enableSsl;
            set
            {
                if (value.HasValue)
                {
                    this.enableSsl = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea el puerto para el envio del email.
        /// </summary>
        public int? Port
        {
            get => this.port;
            set
            {
                if (value.HasValue)
                {
                    this.port = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea si el uso de Body Html esta habiliato.
        /// </summary>
        public bool? IsBodyHtml
        {
            get => this.isBodyHtml;
            set
            {
                if (value.HasValue)
                {
                    this.isBodyHtml = value.Value;
                }
            }
        }

        /// <summary>
        /// Propiedad donde se setea asunto del correo.
        /// </summary>
        public string? Subject
        {
            get => this.subject;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.subject = value;
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
        /// Propiedad donde se setea la plantilla de salida por defecto.
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
