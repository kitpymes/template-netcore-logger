using Serilog;
using System;
using System.Linq;
using CoreLogger = Core.Logger.Abstractions;

namespace Core.Logger.Serilog
{
    public class SerilogProvider : CoreLogger.ILogger, CoreLogger.ILoggerService
    {
        private SerilogSettings SerilogSettings { get; }

        private ILogger? Logger { get; set; }

        public SerilogProvider(SerilogSettings settings)
        => SerilogSettings = settings;

        public CoreLogger.ILogger CreateLogger(string sourceContext)
        {
            Logger = new LoggerConfiguration()
                .AddDefaultSettings(sourceContext)
                .AddConsole(SerilogSettings.Console)
                .AddFile(SerilogSettings.File)
                .AddEmail(SerilogSettings.Email)
                .CreateLogger();

            return this;
        }

        public CoreLogger.ILogger CreateLogger<TSourceContext>()
        => CreateLogger(typeof(TSourceContext).Name);

        #region Info

        public CoreLogger.ILogger Info(string message)
        {
            Logger?.Information(message);

            return this;
        }

        public CoreLogger.ILogger Info(string message, object data)
        {
             Logger?.Information(message + " => {Data}", data);

            return this;
        }

        public CoreLogger.ILogger Info(string eventName, string template, params object[] propertyValues)
        {
            var messageTemplate = "{EventName} => " + template;

            var messageValues = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Information(messageTemplate, messageValues);

            return this;
        }

        #endregion Info

        #region Error

        public CoreLogger.ILogger Error(string message)
        {
            Logger?.Error(message);

            return this;
        }

        public CoreLogger.ILogger Error(string message, object data)
        {
            Logger?.Error(message + " => {Data}", data);

            return this;
        }

        public CoreLogger.ILogger Error(string eventName, string template, params object[] propertyValues)
        {
            var messageTemplate = "{EventName} => " + template;

            var messageValues = new object[] { eventName }.Concat(propertyValues).ToArray();

            Logger?.Error(messageTemplate, messageValues);

            return this;
        }

        public CoreLogger.ILogger Error(Exception exception)
        {
            Logger?.Error("Exception => {Exception}", exception);

            return this;
        }

        #endregion Error
    }
}
