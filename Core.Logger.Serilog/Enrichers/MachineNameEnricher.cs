using Serilog.Core;
using Serilog.Events;
using System;

namespace Core.Logger.Serilog
{
    public class MachineNameEnricher : ILogEventEnricher
    {
        public const string MachineNamePropertyName = "MachineName";

        private LogEventProperty? _lastValue;
      
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var machineName = $"| {MachineNamePropertyName}: {Environment.MachineName}";

            var last = _lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != machineName)
            {
                _lastValue = last = new LogEventProperty(MachineNamePropertyName, new ScalarValue(machineName));

                logEvent.AddPropertyIfAbsent(last);
            }
        }
    }
}
