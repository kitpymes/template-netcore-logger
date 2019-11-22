using System;

namespace Core.Logger.Abstractions
{
    public abstract class LoggerService : ILoggerService, ILoggerInfo<LoggerService>, ILoggerError<LoggerService>
    {
        public abstract LoggerService CreateLogger(string sourceContext);
        public abstract LoggerService CreateLogger<TSourceContext>();

        public abstract LoggerService Error(string message);
        public abstract LoggerService Error(string message, object data);
        public abstract LoggerService Error(string eventName, string template, params object[] propertyValues);
        public abstract LoggerService Error(Exception exception);

        public abstract LoggerService Info(string message);
        public abstract LoggerService Info(string message, object data);
        public abstract LoggerService Info(string eventName, string template, params object[] propertyValues);
    }
}
