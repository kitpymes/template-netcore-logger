﻿// -----------------------------------------------------------------------
// <copyright file="ProcessEnricher.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using global::Serilog.Core;
    using global::Serilog.Events;
    using Kitpymes.Core.Shared;

    /*
        Clase para enriquecer el logeo de errores ProcessEnricher
        Contiene el id y el nombre del proceso para mostrar en el logeo de errores
    */

    /// <summary>
    /// Clase para enriquecer el logeo de errores <c>ProcessEnricher</c>.
    /// Contiene el id y el nombre del proceso para mostrar en el logeo de errores.
    /// </summary>
    public class ProcessEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Nombre de la propiedad donde se va a indexar el id y nombre del proceso.
        /// </summary>
        public const string ProcessPropertyName = "Process";

        private LogEventProperty? lastValue;

        /// <summary>
        /// Enriquecer el evento de registro.
        /// </summary>
        /// <param name="logEvent">El evento de registro para enriquecer.</param>
        /// <param name="propertyFactory">Fábrica para crear nuevas propiedades para agregar al evento.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();

            string processValue = string.Empty;

            if (process?.Id > 0)
            {
                processValue = process.Id.ToStringFormat();
            }

            if (!string.IsNullOrWhiteSpace(process?.ProcessName))
            {
                processValue += process?.Id > 0 ? $" - {process.ProcessName}" : process?.ProcessName;
            }

            var last = this.lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != processValue)
            {
                this.lastValue = last = new LogEventProperty(ProcessPropertyName, new ScalarValue(processValue));

                logEvent?.AddPropertyIfAbsent(last);
            }
        }
    }
}