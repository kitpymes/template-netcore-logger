using Core.Logger.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Core.Logger.Serilog
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadSerilog
        (
            this IServiceCollection services,

            Action<SerilogOptions> options
        )
        {

            var settings = options.ConfigureOrDefault();

            var loggerConfiguration = new LoggerConfiguration().AddDefaultSettings();

            if (settings.IsConsoleEnabled)
            {
                loggerConfiguration.AddConsole(settings.SerilogConsoleSettings);
            }

            if (settings.IsFileEnabled)
            {
                loggerConfiguration.AddFile(settings.SerilogFileSettings);
            }

            if (settings.IsEmailEnabled)
            {
                loggerConfiguration.AddEmail(settings.SerilogEmailSettings);
            }

            if (settings.IsSourceContext)
            {
                loggerConfiguration.Enrich.WithSourceContext(settings.SourceContext);
            }

            services.AddSingleton<ILoggerService>(new SerilogProvider(loggerConfiguration));

            return services;
        }
    }
}
