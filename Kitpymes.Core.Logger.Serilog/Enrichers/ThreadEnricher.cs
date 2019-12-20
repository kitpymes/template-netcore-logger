// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    using System;
    using System.Threading;
    using global::Serilog.Core;
    using global::Serilog.Events;
    using Kitpymes.Core.Logger.Abstractions;

    /*
        Clase para enriquecer el logeo de errores ThreadEnricher
        Contiene el id y el nombre del hilo para mostrar en el logeo de errores
    */

    /// <summary>
    /// Clase para enriquecer el logeo de errores <c>ProcessEnricher</c>.
    /// Contiene el id y el nombre del hilo para mostrar en el logeo de errores.
    /// </summary>
    public class ThreadEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Nombre de la propiedad donde se va a indexar el id y nombre del hilo.
        /// </summary>
        public const string ThreadPropertyName = "Thread";

        private LogEventProperty? _lastValue;

        /// <summary>
        /// Enriquecer el evento de registro.
        /// </summary>
        /// <param name="logEvent">El evento de registro para enriquecer.</param>
        /// <param name="propertyFactory">Fábrica para crear nuevas propiedades para agregar al evento.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var thread = Thread.CurrentThread;

            string threadValue = string.Empty;

            if (thread?.ManagedThreadId > 0)
            {
                threadValue = thread.ManagedThreadId.ToStringFormat();
            }

            if (!string.IsNullOrWhiteSpace(thread?.Name))
            {
                threadValue += thread?.ManagedThreadId > 0 ? $" - {thread.Name}" : thread?.Name;
            }

            var last = _lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != threadValue)
            {
                _lastValue = last = new LogEventProperty(ThreadPropertyName, new ScalarValue(threadValue));

                logEvent?.AddPropertyIfAbsent(last);
            }
        }
    }
}
