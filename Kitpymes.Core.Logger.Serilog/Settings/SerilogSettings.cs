// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    /*
       Clase de configuración SerilogSettings
       Contiene las propiedades para configurar los proveedores de error de Serilog
    */

    /// <summary>
    /// Clase de configuración <c>SerilogSettings</c>.
    /// Contiene las propiedades para configurar los proveedores de error de Serilog.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todos los proveedores de errores de Serilog.</para>
    /// </remarks>
    public class SerilogSettings
    {
        /// <summary>
        /// Propiedad donde se setea la configuración del logeo de errores de consola.
        /// </summary>
        public SerilogConsoleSettings Console { get; set; } = new SerilogConsoleSettings();

        /// <summary>
        /// Propiedad donde se setea la configuración del logeo de errores de archivos.
        /// </summary>
        public SerilogFileSettings File { get; set; } = new SerilogFileSettings();

        /// <summary>
        /// Propiedad donde se setea la configuración del logeo de errores de email.
        /// </summary>
        public SerilogEmailSettings Email { get; set; } = new SerilogEmailSettings();
    }
}
