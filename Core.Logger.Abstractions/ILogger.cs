namespace Core.Logger.Abstractions
{
    public interface ILogger : ILoggerInfo<ILogger>, ILoggerError<ILogger> { }
}
