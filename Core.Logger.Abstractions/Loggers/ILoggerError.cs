using System;

namespace Core.Logger.Abstractions
{
    public interface ILoggerError<TLogger>
    {
        TLogger Error(string message);

        TLogger Error(string message, object data);

        TLogger Error(string eventName, string template, params object[] propertyValues);

        TLogger Error(Exception exception);
    }

    public interface ILoggerError
    {
        void Error(string message);

        void Error(string message, object data);

        void Error(string eventName, string template, params object[] propertyValues);

        void Error(Exception exception);
    }
}
