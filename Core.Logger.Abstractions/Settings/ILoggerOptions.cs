namespace Core.Logger.Abstractions
{
    public interface ILoggerOptions<TOptions>
    {
        TOptions WithSourceContext(string? sourceContext);

        TOptions WithSourceContext<T>();
    }
}
