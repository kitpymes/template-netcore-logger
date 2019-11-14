namespace Core.Logger
{
    public interface ILoggerSettings<TSettings>
    {
        TSettings WithSourceContext(string sourceContext);

        TSettings WithSourceContext<T>();

        TSettings WithMinimumLevel(LoggerMinimumLevel minimumLevel);

        TSettings WithOutputTemplate(string outputTemplate);
    }
}
