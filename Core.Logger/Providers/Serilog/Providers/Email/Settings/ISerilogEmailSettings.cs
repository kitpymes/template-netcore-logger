namespace Core.Logger
{
    public interface ISerilogEmailSettings : ILoggerSettings<ISerilogEmailSettings>
    {
        ISerilogEmailSettings WithSubject(string subject);

        ISerilogEmailSettings WithEnableSsl(bool enableSsl);

        ISerilogEmailSettings WithPort(int port);
    }
}
