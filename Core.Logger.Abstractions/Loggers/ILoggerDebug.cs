namespace Core.Logger.Abstractions
{
    public interface ILoggerDebug
    {
        void Debug(string message);

        void Debug(string message, object data);

        void Debug(string eventName, string message, params object[] propertyValues);
    }
}
