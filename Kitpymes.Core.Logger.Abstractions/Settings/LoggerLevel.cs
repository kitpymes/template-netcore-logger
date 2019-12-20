// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Abstractions
{
    /*
        Enumeración de LoggerLevel
        Contiene los tipos de niveles del logeo de errores
    */

    /// <summary>
    /// Enumeración de <c>LoggerLevel</c>.
    /// Contiene los tipos de niveles del logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta enumeración se pueden agregar todos los tipos de niveles del logeo de errores.</para>
    /// </remarks>
    public enum LoggerLevel
    {
        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel más bajo.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        Info = 2,

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        Error = 3,
    }
}
