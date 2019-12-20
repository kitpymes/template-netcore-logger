// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Abstractions
{
    /*
      Interface de ILoggerService
      Contiene los contratos para crear el logeo
    */

    /// <summary>
    /// Interface <c>ILoggerService</c>.
    /// Contiene los contratos para crear el logeo de errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta interface se pueden agregar todos los contratos que deberán ser implementados por los diferentes proveedores para crear el logeo.</para>
    /// </remarks>
    public interface ILoggerService
    {
        /// <summary>
        /// Crea el logeo de errores.
        /// </summary>
        /// <param name="title">El título del logeo.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger CreateLogger(string title);

        /// <summary>
        /// Crea el logeo de errores.
        /// </summary>
        /// <typeparam name="TTitle">El tipo del título del logeo.</typeparam>
        /// <returns>La interface ILogger.</returns>
        ILogger CreateLogger<TTitle>();
    }
}
