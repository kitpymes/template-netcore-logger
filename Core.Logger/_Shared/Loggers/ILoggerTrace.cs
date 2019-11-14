namespace Core.Logger
{
    public interface ILoggerTrace
    {
        void Trace(string message);

        void Trace(string message, object data);

        void Trace(string eventName, string message, params object[] propertyValues);
    }
}
