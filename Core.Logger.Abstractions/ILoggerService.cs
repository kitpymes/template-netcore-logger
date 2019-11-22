namespace Core.Logger.Abstractions
{
    public interface ILoggerService
    {
        LoggerService CreateLogger(string sourceContext);

        LoggerService CreateLogger<TSourceContext>();
    }
}
