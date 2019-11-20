namespace Core.Logger.Abstractions
{
    public interface ILoggerInfo<TLogger>
    {
        TLogger Info(string message);

        TLogger Info(string message, object data);

        TLogger Info(string eventName, string template, params object[] propertyValues);
    }

    public interface ILoggerInfo
    {
        void Info(string message);

        void Info(string message, object data);

        void Info(string eventName, string template, params object[] propertyValues);
    }
}
