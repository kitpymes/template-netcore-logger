namespace Core.Logger.Abstractions
{
    public interface ILoggerInfo<TLogger>
    {
        TLogger Info(string message);

        TLogger Info(string message, object data);

        TLogger Info(string message, string propertyName, object propertyValue);

        TLogger Info(string eventName, string message, params object[] propertyValues);
    }

    public interface ILoggerInfo
    {
        void Info(string message);

        void Info(string message, object data);

        void Info(string message, string propertyName, object propertyValue);

        void Info(string eventName, string message, params object[] propertyValues);
    }
}
