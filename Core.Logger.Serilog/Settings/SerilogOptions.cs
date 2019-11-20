using Core.Logger.Abstractions;
using System;

namespace Core.Logger.Serilog
{
    public class SerilogOptions
    {
        public bool IsSourceContext => !string.IsNullOrWhiteSpace(SourceContext);
        public string? SourceContext { get; private set; }
        public SerilogOptions WithSourceContext(string? sourceContext)
        {
            SourceContext = sourceContext;

            return this;
        }

        public SerilogOptions WithSourceContext<T>()
        => WithSourceContext(typeof(T).Name);

        #region Console

        public bool IsConsoleEnabled { get; private set; } = false;
        public SerilogConsoleSettings? SerilogConsoleSettings { get; private set; }
        public SerilogOptions WithConsole
        (
            LoggerMinimumLevel minimumLevel = SerilogConsoleSettings.DefaultMinimumLevel,

            string outputTemplate = SerilogConsoleSettings.DefaultOutputTemplate
        )
        {
            return WithConsole(new SerilogConsoleSettings
            {
                Enabled = true,

                MinimumLevel = minimumLevel.ToString(),

                OutputTemplate = outputTemplate
            });
        }

        public SerilogOptions WithConsole(Action<SerilogConsoleSettings> settings)
        {
            return WithConsole(settings.ConfigureOrDefault());
        }

        public SerilogOptions WithConsole(SerilogConsoleSettings settings)
        {
            SerilogConsoleSettings = settings;

            if (settings.Enabled.HasValue)
                IsConsoleEnabled = settings.Enabled.Value;

            return this;
        }

        #endregion Console

        #region File

        public bool IsFileEnabled { get; private set; } = false;
        public SerilogFileSettings? SerilogFileSettings { get; private set; }
        public SerilogOptions WithFile
        (
            string filePath = SerilogFileSettings.DefaultFilePath, 
            
            LoggerMinimumLevel loggerMinimumLevel = SerilogFileSettings.DefaultMinimumLevel, 
            
            LoggerInterval loggerInterval = SerilogFileSettings.DefaultLoggerInterval
        )
        {
            return WithFile(new SerilogFileSettings
            {
                Enabled = true,

                FilePath = filePath,

                Interval = loggerInterval.ToString(),

                MinimumLevel = loggerMinimumLevel.ToString()
            });
        }

        public SerilogOptions WithFile(Action<SerilogFileSettings> settings)
        {
            return WithFile(settings.ConfigureOrDefault());
        }

        public SerilogOptions WithFile(SerilogFileSettings settings)
        {
            SerilogFileSettings = settings;

            if (settings.Enabled.HasValue)
                IsFileEnabled = settings.Enabled.Value;

            return this;
        }

        #endregion File

        #region Email

        public bool IsEmailEnabled { get; private set; } = false;
        public SerilogEmailSettings? SerilogEmailSettings { get; private set; }
        public SerilogOptions WithEmail
        (
           string userName,

            string password,

            string server,

            string from,

            string to,

            bool enableSsl = SerilogEmailSettings.DefaultEnableSsl,

            int port = SerilogEmailSettings.DefaultPort,

            string subject = SerilogEmailSettings.DefaultSubject,

            bool isBodyHtml = SerilogEmailSettings.DefaultIsBodyHtml,

            LoggerMinimumLevel loggerMinimumLevel = SerilogEmailSettings.DefaultMinimumLevel,

            string outputTemplate = SerilogEmailSettings.DefaultOutputTemplate
        )
        {
            return WithEmail(new SerilogEmailSettings
            (
               userName,

                password,

                server,

                from,

                to,

                enableSsl,

                port,

                subject,

                isBodyHtml,

                loggerMinimumLevel,

                outputTemplate
            )
            {
                Enabled = true
            });
        }

        public SerilogOptions WithEmail(SerilogEmailSettings settings)
        {
            SerilogEmailSettings = settings;

            if(settings.Enabled.HasValue)
                IsEmailEnabled = settings.Enabled.Value;

            return this;
        }

        #endregion Email
    }
}
