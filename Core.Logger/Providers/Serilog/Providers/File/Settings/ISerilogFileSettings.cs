namespace Core.Logger
{
    public interface ISerilogFileSettings : ILoggerSettings<ISerilogFileSettings>
    {
        ISerilogFileSettings WithFilePath(string filePath);

        ISerilogFileSettings WithLoggerInterval(LoggerInterval loggerInterval);
    }
}
