// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.

namespace Kitpymes.Core.Logger.Serilog
{
    using global::Serilog.Core;
    using global::Serilog.Events;

    /*
       Clase para enriquecer el logeo de errores TitleEnricher
       Contiene el título para mostrar en el logeo de errores
    */

    /// <summary>
    /// Clase para enriquecer el logeo de errores <c>TitleEnricher</c>.
    /// Contiene el título para mostrar en el logeo de errores.
    /// </summary>
    public class TitleEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Nombre de la propiedad donde se va a indexar el título del log.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private LogEventProperty? _lastValue;

        private string? _title;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TitleEnricher"/>.
        /// </summary>
        /// <param name="title">Título del log.</param>
        public TitleEnricher(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            }

            _title = title;
        }

        /// <summary>
        /// Enriquecer el evento de registro.
        /// </summary>
        /// <param name="logEvent">El evento de registro para enriquecer.</param>
        /// <param name="propertyFactory">Fábrica para crear nuevas propiedades para agregar al evento.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var last = _lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != _title)
            {
                _lastValue = last = new LogEventProperty(TitlePropertyName, new ScalarValue(_title));

                logEvent?.AddPropertyIfAbsent(last);
            }
        }
    }
}
