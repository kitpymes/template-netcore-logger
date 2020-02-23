// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger
{
    using System;
    using Kitpymes.Core.Logger.Serilog;

    /*
      Clase de opciones LoggerOptions
      Contiene las opciones para configurar los proveedores de error
   */

    /// <summary>
    /// Clase de opciones <c>LoggerOptions</c>.
    /// Contiene las opciones para configurar los proveedores de error.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las opciones de configuración para los proveedores de errores.</para>
    /// </remarks>
    public class LoggerOptions
    {
        /// <summary>
        /// Propiedad donde se setea si el proveedor de errores Serilog esta habiliato.
        /// </summary>
        public bool IsSerilogEnabled { get; private set; } = false;

        /// <summary>
        /// Propiedad donde se setea si las opciones del proveedor de errores Serilog.
        /// </summary>
        public Action<SerilogOptions> SerilogOptions { get; private set; } = x => { };

        /// <summary>
        /// Habilita el proveedor de errores Serilog.
        /// </summary>
        /// <param name="options">Las opciones del proveedor de errores Serilog.</param>
        /// <returns>La clase LoggerOptions.</returns>
        public LoggerOptions UseSerilog(Action<SerilogOptions> options)
        {
            this.SerilogOptions = options;

            this.IsSerilogEnabled = true;

            return this;
        }
    }
}
