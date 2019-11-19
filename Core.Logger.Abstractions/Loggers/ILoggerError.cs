using System;

namespace Core.Logger.Abstractions
{
    public interface ILoggerError<TLogger>
    {
        TLogger Error(string message);

        TLogger Error(string message, object data);

        TLogger Error(string message, string propertyName, object propertyValue);

        TLogger Error(string eventName, string message, params object[] propertyValues);

        TLogger Error(string message, Exception exception);

        TLogger Error(Exception exception);

        TLogger Error(Exception exception, object data);
    }

    public interface ILoggerError
    {
        void Error(string message);

        void Error(string message, object data);

        void Error(string message, string propertyName, object propertyValue);

        void Error(string eventName, string message, params object[] propertyValues);

        void Error(string message, Exception exception);

        void Error(Exception exception);

        void Error(Exception exception, object data);
    }
}
