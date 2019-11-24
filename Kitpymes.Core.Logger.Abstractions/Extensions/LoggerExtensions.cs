using System;

namespace Kitpymes.Core.Logger.Abstractions
{
    public static class LoggerExtensions
    {
        public static TOptions Configure<TOptions>
        (
            this Action<TOptions>? action,

            TOptions defaultOptions
        )
            where TOptions : class
        {
            if (defaultOptions is null)
                throw new ArgumentNullException(nameof(defaultOptions));

            action?.Invoke(defaultOptions);

            return defaultOptions;
        }

        public static TOptions Configure<TOptions>(this Action<TOptions>? action)
            where TOptions : class, new()
        {
            var defaultOptions = new TOptions();

            return action.Configure(defaultOptions);
        }
    }
}
