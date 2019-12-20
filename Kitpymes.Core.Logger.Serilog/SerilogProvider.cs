// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    using System;
    using System.Linq;
    using global::Serilog;

    /*
      Clase del servicio SerilogProvider
      Contiene la implemetación del servicio del logeo de errores de Serilog
    */

    /// <summary>
    /// Clase del servicio <c>ILoggerService</c>.
    /// Contiene la implemetación del servicio del logeo de errores de Serilog.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las acciones del servicio de Serilog.</para>
    /// </remarks>
    public class SerilogProvider : Abstractions.ILogger, Abstractions.ILoggerService
    {
        /// <summary>
        /// Implementación de la clase <c>SerilogProvider</c>.
        /// </summary>
        /// <param name="settings">Configuración de Serilog.</param>
        public SerilogProvider(SerilogSettings settings)
        => SerilogSettings = settings;

        private SerilogSettings SerilogSettings { get; }

        private ILogger? Logger { get; set; }

        /// <summary>
        /// Crea un log nuevo.
        /// </summary>
        /// <param name="title">Título del log.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger CreateLogger(string title)
        {
            Logger = new LoggerConfiguration()
                .AddDefaultSettings(title)
                .AddConsole(SerilogSettings.Console)
                .AddFile(SerilogSettings.File)
                .AddEmail(SerilogSettings.Email)
                .CreateLogger();

            return this;
        }

        /// <summary>
        /// Crea un log nuevo.
        /// </summary>
        /// <typeparam name="TSourceContext">Título del log.</typeparam>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger CreateLogger<TSourceContext>()
        => CreateLogger(typeof(TSourceContext).Name);

        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel mas bajo.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Trace(string message)
        {
            Logger?.Verbose(message);

            return this;
        }

        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel mas bajo.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Trace(string message, object data)
        {
            Logger?.Verbose(message + " => {Data}", data);

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Debug(string message)
        {
            Logger?.Debug(message);

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Debug(string message, object data)
        {
            Logger?.Debug(message + " => {Data}", data);

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Info(string message)
        {
            Logger?.Information(message);

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Info(string message, object data)
        {
             Logger?.Information(message + " => {Data}", data);

             return this;
        }

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="eventName">El nombre del evento.</param>
        /// <param name="templateMessage">El mensaje tipo template, para indexar las propiedades.</param>
        /// <param name="propertyValues">Las propiedades a indexar en el template.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Info(string eventName, string templateMessage, params object[] propertyValues)
        {
            var message = "{EventName} => " + templateMessage;

            var values = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Information(message, values);

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(string message)
        {
            Logger?.Error(message);

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="data">El detalle a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(string message, object data)
        {
            Logger?.Error(message + " => {Data}", data);

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="eventName">El nombre del evento.</param>
        /// <param name="templateMessage">El mensaje tipo template, para indexar las propiedades.</param>
        /// <param name="propertyValues">Las propiedades a indexar en el template.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(string eventName, string templateMessage, params object[] propertyValues)
        {
            var message = "{EventName} => " + templateMessage;

            var values = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Error(message, values);

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="exception">La excepción ocurrida a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(Exception exception)
        {
            Logger?.Error("Exception => {Exception}", exception);

            return this;
        }
    }
}
