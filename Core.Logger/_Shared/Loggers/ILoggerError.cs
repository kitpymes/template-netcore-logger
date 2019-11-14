using System;

namespace Core.Logger
{
    public interface ILoggerError<TLogger>
    {
        TLogger Error(string message);

        TLogger Error(string message, object data);

        TLogger Error(string eventName, string message, params object[] propertyValues);

        TLogger Error(string message, Exception exception);

        TLogger Error(Exception exception);

        TLogger Error(Exception exception, object data);
    }
}
