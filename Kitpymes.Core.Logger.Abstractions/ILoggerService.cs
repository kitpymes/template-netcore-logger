namespace Kitpymes.Core.Logger.Abstractions
{
    public interface ILoggerService
    {
        ILogger CreateLogger(string sourceContext);

        ILogger CreateLogger<TSourceContext>();
    }
}
