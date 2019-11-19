using Core.Logger.Abstractions;

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
            SerilogConsoleSettings = new SerilogConsoleSettings
            {
                Enabled = true,

                MinimumLevel = minimumLevel.ToString(),

                OutputTemplate = outputTemplate
            };

            IsConsoleEnabled = true;

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
            SerilogFileSettings = new SerilogFileSettings
            {
                Enabled = true,

                FilePath = filePath,

                Interval = loggerInterval.ToString(),

                MinimumLevel = loggerMinimumLevel.ToString()
            };

            IsFileEnabled = true;

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

            LoggerMinimumLevel loggerMinimumLevel = SerilogEmailSettings.DefaultMinimumLevel,

            string outputTemplate = SerilogEmailSettings.DefaultOutputTemplate
        )
        {
            SerilogEmailSettings = new SerilogEmailSettings
            (
                userName,

                password,

                server,

                from,

                to,

                enableSsl,

                port,

                subject,

                loggerMinimumLevel,

                outputTemplate
            )
            {
                Enabled = true
            };

            IsEmailEnabled = true;

            return this;
        }

        #endregion Email
    }
}
