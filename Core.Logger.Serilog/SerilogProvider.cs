using Core.Logger.Abstractions;
using Serilog;
using System;
using System.Linq;

namespace Core.Logger.Serilog
{
    public class SerilogProvider : LoggerService, ILoggerService
    {
        private SerilogSettings SerilogSettings { get; }

        private ILogger? Logger { get; set; }

        public SerilogProvider(SerilogSettings settings)
        => SerilogSettings = settings;

        public override LoggerService CreateLogger(string sourceContext)
        {
            Logger = new LoggerConfiguration()
                .AddDefaultSettings(sourceContext)
                .AddConsole(SerilogSettings.Console)
                .AddFile(SerilogSettings.File)
                .AddEmail(SerilogSettings.Email)
                .CreateLogger();

            return this;
        }

        public override LoggerService CreateLogger<TSourceContext>()
        => CreateLogger(typeof(TSourceContext).Name);

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
            Logger?.Error("Exception => {Exception}", exception);

            return this;
        }

        #endregion Error
    }
}
