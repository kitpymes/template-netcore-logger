using Kitpymes.Core.Logger.Abstractions;
using Kitpymes.Core.Logger.Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kitpymes.Core.Logger
{
    public static class LoggerServiceCollectionExtensions
    {
        public static IServiceCollection LoadLogger
        (
            this IServiceCollection services,

            IConfiguration configuration
        )
        {
            var settings = configuration.GetSection(nameof(LoggerSettings))?.Get<LoggerSettings>();

            if (settings?.Serilog != null)
            {
                services.LoadSerilog(settings.Serilog);
            }

            return services;
        }

        public static IServiceCollection LoadLogger
        (
            this IServiceCollection services,

            Action<LoggerOptions> options
        )
        {
            var settings = options.Configure();

            if (settings.IsSerilogEnabled)
            {
                services.LoadSerilog(settings.SerilogOptions);
            }

            return services;
        }
    }
}
