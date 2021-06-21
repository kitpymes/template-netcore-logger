// -----------------------------------------------------------------------
// <copyright file="SerilogProvider.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
        /// Inicializa una nueva instancia de la clase <see cref="SerilogProvider"/>.
        /// </summary>
        /// <param name="settings">Configuración de Serilog.</param>
        public SerilogProvider(SerilogSettings settings)
        => this.SerilogSettings = settings;

        private SerilogSettings SerilogSettings { get; }

        private ILogger? Logger { get; set; }

        /// <summary>
        /// Crea un log nuevo.
        /// </summary>
        /// <param name="title">Título del log.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger CreateLogger(string title)
        {
            this.Logger = new LoggerConfiguration()
                .AddDefaultSettings(title)
                .AddConsole(this.SerilogSettings.Console)
                .AddFile(this.SerilogSettings.File)
                .AddEmail(this.SerilogSettings.Email)
                .AddSqlserver(this.SerilogSettings.SqlServer)
                .CreateLogger();

            return this;
        }

        /// <summary>
        /// Crea un log nuevo.
        /// </summary>
        /// <typeparam name="TSourceContext">Título del log.</typeparam>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger CreateLogger<TSourceContext>()
        => this.CreateLogger(typeof(TSourceContext).Name);

        /// <summary>
        /// Logea cualquier cosa que ocurra, es el nivel mas bajo.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Trace(string message)
        {
            this.Logger?.Verbose(message);

            Close();

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
            this.Logger?.Verbose(message + " => {Data}", data);

            Close();

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema interno cuando se ejecuta en modo debug.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Debug(string message)
        {
            this.Logger?.Debug(message);

            Close();

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
            this.Logger?.Debug(message + " => {Data}", data);

            Close();

            return this;
        }

        /// <summary>
        /// Logea los eventos del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Info(string message)
        {
            this.Logger?.Information(message);

            Close();

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
            this.Logger?.Information(message + " => {Data}", data);

            Close();

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

            this.Logger?.Information(message, values);

            Close();

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(string message)
        {
            this.Logger?.Error(message);

            Close();

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
            this.Logger?.Error(message + " => {Data}", data);

            Close();

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

            this.Logger?.Error(message, values);

            Close();

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="exception">La excepción ocurrida a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(Exception exception)
        {
            this.Logger?.Error("Exception => {Exception}", exception);

            Close();

            return this;
        }

        /// <summary>
        /// Loguea los errores customizados o cuando surge alguna excepción no controlada del sistema.
        /// </summary>
        /// <param name="message">El mensaje personalizado a mostrar.</param>
        /// <param name="exception">La excepción ocurrida a mostrar.</param>
        /// <returns>La interface ILogger.</returns>
        public Abstractions.ILogger Error(string message, Exception exception)
        {
            this.Logger?.Error(message + " => {Exception}", exception);

            Close();

            return this;
        }

        private void Close() => Log.CloseAndFlush();
    }
}
