using Core.Logger.Abstractions;
using Serilog;
using System;
using System.Linq;

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
             Logger?.Information(message + " => {Data}", data);

            return this;
        }

        public override LoggerService Info(string eventName, string template, params object[] propertyValues)
        {
            var messageTemplate = "{EventName} => " + template;

            var messageValues = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Information(messageTemplate, messageValues);

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
            Logger?.Error(message + " => {Data}", data);

            return this;
        }

        public override LoggerService Error(string eventName, string template, params object[] propertyValues)
        {
            var messageTemplate = "{EventName} => " + template;

            var messageValues = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Error(messageTemplate, messageValues);

            return this;
        }

        public override LoggerService Error(Exception exception)
        {
            Logger?.Error("Exception => {Exception}", exception.Message);

            return this;
        }

        #endregion Error

        public override LoggerService CreateLogger<TSourceContext>()
        {
            return CreateLogger(typeof(TSourceContext).Name);
        }

        public override LoggerService CreateLogger(string sourceContext)
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
