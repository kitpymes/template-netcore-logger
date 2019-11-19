using Core.Logger.Abstractions;
using Serilog;
using System;
using Seri = Serilog;

namespace Core.Logger.Serilog
{
    public class SerilogProvider: LoggerService, ILoggerService
    {
        private LoggerConfiguration LoggerConfiguration { get; set; }

        private ILogger? Logger { get; set; }

        public SerilogProvider(LoggerConfiguration loggerConfiguration)
        {
            LoggerConfiguration = loggerConfiguration;
        }

        #region Info

        public override LoggerService Info(string message)
        {
            Logger?.Information(message);

            return this;
        }

        public override LoggerService Info(string message, object data)
        {
            Logger?.WithData(data).Information(message);

            return this;
        }

        public override LoggerService Info(string message, string propertyName, object propertyValue)
        {
            Logger?.WithProperty(propertyName, propertyValue).Information(message);

            return this;
        }

        public override LoggerService Info(string eventName, string message, params object[] propertyValues)
        {
            var (eventMessage, eventProperties) = SerilogExtensions.WithEvent(eventName, message, propertyValues);

            Logger?.Write(Seri.Events.LogEventLevel.Information, eventMessage, eventProperties);

            return this;
        }

        #endregion Info

        #region Error

        public override LoggerService Error(string message)
        {
            Logger?.Error(message);

            return this;
        }

        public override LoggerService Error(string message, object data)
        {
            Logger?.WithData(data).Error(message);

            return this;
        }

        public override LoggerService Error(string message, string propertyName, object propertyValue)
        {
            Logger?.WithProperty(propertyName, propertyValue).Error(message);

            return this;
        }

        public override LoggerService Error(string eventName, string message, params object[] propertyValues)
        {
            var (eventMessage, eventProperties) = SerilogExtensions.WithEvent(eventName, message, propertyValues);

            Logger?.Write(Seri.Events.LogEventLevel.Error, eventMessage, eventProperties);

            return this;
        }

        public override LoggerService Error(string message, Exception exception)
        {
            Logger?.Error(exception, message);

            return this;
        }

        public override LoggerService Error(Exception exception)
        {
            Logger?.Error(exception, exception.Message);

            return this;
        }

        public override LoggerService Error(Exception exception, object data)
        {
            Logger?.WithData(data).Error(exception, exception.Message);

            return this;
        }

        #endregion Error

        public override LoggerService CreateLogger<TSourceContext>()
        {
            return CreateLogger(typeof(TSourceContext).Name);
        }

        public override LoggerService CreateLogger(string? sourceContext = null)
        {
            if (!string.IsNullOrWhiteSpace(sourceContext))
            {
                LoggerConfiguration.Enrich.WithSourceContext(sourceContext);
            }

            Logger = LoggerConfiguration.CreateLogger();

            return this;
        }
    }
}
