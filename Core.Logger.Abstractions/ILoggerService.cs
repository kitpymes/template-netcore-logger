namespace Core.Logger.Abstractions
{
    public interface ILoggerService : ILoggerInfo<LoggerService>, ILoggerError<LoggerService>
    {
        LoggerService CreateLogger(string? sourceContext = null);

        LoggerService CreateLogger<TSourceContext>();
    }
}
