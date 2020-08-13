// -----------------------------------------------------------------------
// <copyright file="MachineNameEnricher.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using System;
    using global::Serilog.Core;
    using global::Serilog.Events;

    /*
        Clase para enriquecer el logeo de errores MachineNameEnricher
        Contiene el nombre de la máquina para mostrar en el logeo de errores
    */

    /// <summary>
    /// Clase para enriquecer el logeo de errores <c>MachineNameEnricher</c>.
    /// Contiene el nombre de la máquina para mostrar en el logeo de errores.
    /// </summary>
    public class MachineNameEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Nombre de la propiedad donde se va a indexar el nombre de la máquina.
        /// </summary>
        public const string MachineNamePropertyName = "MachineName";

        private LogEventProperty? lastValue;

        /// <summary>
        /// Enriquecer el evento de registro.
        /// </summary>
        /// <param name="logEvent">El evento de registro para enriquecer.</param>
        /// <param name="propertyFactory">Fábrica para crear nuevas propiedades para agregar al evento.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var machineName = Environment.MachineName;

            var last = this.lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != machineName)
            {
                this.lastValue = last = new LogEventProperty(MachineNamePropertyName, new ScalarValue(machineName));

                logEvent?.AddPropertyIfAbsent(last);
            }
        }
    }
}
