// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger
{
    using Kitpymes.Core.Logger.Serilog;

    /// <summary>
    /// Clase de configuración <c>LoggerSettings</c>.
    /// Contiene las propiedades para configurar los proveedores de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todos los proveedores de errores.</para>
    /// </remarks>
    public class LoggerSettings
    {
        /// <summary>
        /// Propiedad donde se setea la configuración del logeo de errores de Serilog.
        /// </summary>
        public SerilogSettings? Serilog { get; set; } = new SerilogSettings();
    }
}
