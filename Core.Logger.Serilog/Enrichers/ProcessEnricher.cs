using Serilog.Core;
using Serilog.Events;

namespace Core.Logger.Serilog
{
    public class ProcessEnricher : ILogEventEnricher
    {
        public const string ProcessPropertyName = "Process";

        private LogEventProperty? _lastValue;
      
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var processId = System.Diagnostics.Process.GetCurrentProcess().Id;

            var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            string processValue = "";

            if (processId > 0)
            {
                processValue = processId.ToString();
            }

            if(!string.IsNullOrWhiteSpace(processName))
            {
                processValue += $" - {processName}";
            }

            var last = _lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != processValue)
            {
                _lastValue = last = new LogEventProperty(ProcessPropertyName, new ScalarValue(processValue));

                logEvent.AddPropertyIfAbsent(last);
            }
        }
    }
}
