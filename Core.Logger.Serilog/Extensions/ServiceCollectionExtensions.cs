using Core.Logger.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace Core.Logger.Serilog
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadSerilog
        (
            this IServiceCollection services,

            SerilogSettings settings
        )
        {
            var loggerConfiguration = new LoggerConfiguration()
                .AddDefaultSettings()
                .AddConsole(settings.Console)
                .AddFile(settings.File)
                .AddEmail(settings.Email);

            services.AddSingleton<ILoggerService>(new SerilogProvider(loggerConfiguration));

            return services;
        }

        public static IServiceCollection LoadSerilog
        (
            this IServiceCollection services,

            Action<SerilogSettings> options
        )
        {
            var settings = options.ConfigureOrDefault();

            return services.LoadSerilog(settings);
        }
    }
}
