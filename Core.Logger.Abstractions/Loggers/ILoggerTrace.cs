namespace Core.Logger.Abstractions
{
    public interface ILoggerTrace
    {
        void Trace(string message);

        void Trace(string message, object data);

        void Trace(string eventName, string message, params object[] propertyValues);
    }
}
