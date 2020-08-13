// -----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Abstractions
{
    using System;

    /*
       Interface de ILogger
       Contiene los contratos para logear los errores
    */

    /// <summary>
    /// Interface de <c>ILogger</c>.
    /// Contiene los contratos para logear los errores.
    /// </summary>
    /// <remarks>
    /// <para>En esta interface se pueden agregar todos los contratos que deberán ser implementados por los diferentes proveedores para logear los errores.</para>
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel mas bajo.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Trace(string message);

        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel mas bajo.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Trace(string message, object data);

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Debug(string message);

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Debug(string message, object data);

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Info(string message);

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Info(string message, object data);

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="eventName">El nombre del evento.</param>
        /// <param name="templateMessage">El mensaje tipo template, para indexar las propiedades.</param>
        /// <param name="propertyValues">Las propiedades a indexar en el template.</param>
        /// <returns>La interface ILogger.</returns>
        ILogger Info(string eventName, string templateMessage, params object[] propertyValues);

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Los identificadores no deben coincidir con palabras clave", Justification = "<pendiente>")]
        ILogger Error(string message);

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Los identificadores no deben coincidir con palabras clave", Justification = "<pendiente>")]
        ILogger Error(string message, object data);

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="eventName">El nombre del evento.</param>
        /// <param name="templateMessage">El mensaje tipo template, para indexar las propiedades.</param>
        /// <param name="propertyValues">Las propiedades a indexar en el template.</param>
        /// <returns>La interface ILogger.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Los identificadores no deben coincidir con palabras clave", Justification = "<pendiente>")]
        ILogger Error(string eventName, string templateMessage, params object[] propertyValues);

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="exception">La excepción ocurrida a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Los identificadores no deben coincidir con palabras clave", Justification = "<pendiente>")]
        ILogger Error(Exception exception);

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="exception">La excepción ocurrida a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Los identificadores no deben coincidir con palabras clave", Justification = "<pendiente>")]
        ILogger Error(string message, Exception exception);
    }
}
