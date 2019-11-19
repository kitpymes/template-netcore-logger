using Core.Logger.Abstractions;
using Core.Logger.Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Core.Logger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadLogger
        (
            this IServiceCollection services,

            Action<LoggerOptions> options
        )
        {
            var settings = options.ConfigureOrDefault();

            if (settings.IsSerilogEnabled)
            {
                services.LoadSerilog(settings.SerilogOptions);
            }

            return services;
        }
    }
}
