﻿using Serilog.Core;
using Serilog.Events;
using System;

namespace Core.Logger
{
    public class SourceContextEnricher : ILogEventEnricher
    {
        public const string SourceContextPropertyName = "SourceContext";

        private LogEventProperty _lastValue;

        private string _sourceContext;

        public SourceContextEnricher(string sourceContext)
        {
            _sourceContext = sourceContext;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var last = _lastValue;

            if (!string.IsNullOrWhiteSpace(_sourceContext) && (last is null || (string)((ScalarValue)last.Value).Value != _sourceContext))
            {
                _lastValue = last = new LogEventProperty(SourceContextPropertyName, new ScalarValue(_sourceContext));

                logEvent.AddPropertyIfAbsent(last);
            }
        }
    }
}
