namespace Core.Logger
{
    public interface ILoggerInfo<TLogger>
    {
        TLogger Info(string message);

        TLogger Info(string message, object data);

        TLogger Info(string eventName, string message, params object[] propertyValues);
    }
}
