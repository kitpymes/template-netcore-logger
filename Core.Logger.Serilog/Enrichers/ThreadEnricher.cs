using Serilog.Core;
using Serilog.Events;
using System;
using System.Threading;

namespace Core.Logger.Serilog
{
    public class ThreadEnricher : ILogEventEnricher
    {
        public const string ThreadPropertyName = "Thread";

        private LogEventProperty? _lastValue;
      
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var threadId = Environment.CurrentManagedThreadId;

            var threadName = Thread.CurrentThread.Name;

            string threadValue = "";

            if (threadId > 0)
            {
                threadValue = $"| {ThreadPropertyName}: {threadId.ToString()}";
            }

            if (!string.IsNullOrWhiteSpace(threadName))
            {
                threadValue += $" - {threadName}";
            }

            var last = _lastValue;

            if (last is null || (string)((ScalarValue)last.Value).Value != threadValue)
            {
                _lastValue = last = new LogEventProperty(ThreadPropertyName, new ScalarValue(threadValue));

                logEvent.AddPropertyIfAbsent(last);
            }
        }
    }
}
