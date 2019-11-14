using System;

namespace Core.Logger
{
    public interface ILogFatal
    {
        void Fatal(string message);

        void Fatal(string message, object data);

        void Fatal(string eventName, string message, params object[] propertyValues);

        void Fatal(string message, Exception exception);

        void Fatal(Exception exception);

        void Fatal(Exception exception, object data);
    }
}
