using System;

namespace Core.Logger.Abstractions
{
    public interface ILoggerService : ILoggerInfo<LoggerService>, ILoggerError<LoggerService>
    {
        LoggerService CreateLogger(string sourceContext);

        LoggerService CreateLogger<TSourceContext>();

        void CloseLogger();
    }
}
