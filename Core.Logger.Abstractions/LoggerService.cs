using System;

namespace Core.Logger.Abstractions
{
    public abstract class LoggerService : ILoggerService
    {
        public abstract LoggerService CreateLogger(string? sourceContext = null);
        public abstract LoggerService CreateLogger<TSourceContext>();
        public abstract LoggerService Error(string message);
        public abstract LoggerService Error(string message, object data);
        public abstract LoggerService Error(string message, string propertyName, object propertyValue);
        public abstract LoggerService Error(string eventName, string message, params object[] propertyValues);
        public abstract LoggerService Error(string message, Exception exception);
        public abstract LoggerService Error(Exception exception);
        public abstract LoggerService Error(Exception exception, object data);
        public abstract LoggerService Info(string message);
        public abstract LoggerService Info(string message, object data);
        public abstract LoggerService Info(string message, string propertyName, object propertyValue);
        public abstract LoggerService Info(string eventName, string message, params object[] propertyValues);
    }
}
