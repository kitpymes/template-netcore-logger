using System;

namespace Core.Logger.Abstractions
{
    public static class LoggerExtensions
    {
        public static TOptions Configure<TOptions>
        (
            this Action<TOptions> action,

            TOptions defaultOptions
        )
            where TOptions : class
        {
            if (defaultOptions is null)
                throw new ArgumentNullException(nameof(defaultOptions));

            action?.Invoke(defaultOptions);

            return defaultOptions;
        }

        public static TOptions ConfigureOrDefault<TOptions>
        (
            this Action<TOptions> action,

            TOptions? defaultOptions = null
        )
            where TOptions : class, new()
        {
            defaultOptions ??= new TOptions();

            return action.Configure(defaultOptions);
        }
    }
}
