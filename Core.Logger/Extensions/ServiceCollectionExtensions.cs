using Core.Logger.Abstractions;
using Core.Logger.Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Logger
{
    public static class ServiceCollectionExtensions
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
            var settings = options.ConfigureOrDefault();

            if (settings.IsSerilogEnabled)
            {
                services.LoadSerilog(settings.SerilogSettings);
            }

            return services;
        }
    }
}
