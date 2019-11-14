namespace Core.Logger
{
    public interface ISerilogProvider : ILoggerProvider, ILoggerInfo<ISerilogProvider>, ILoggerError<ISerilogProvider>
    {
    }
}
