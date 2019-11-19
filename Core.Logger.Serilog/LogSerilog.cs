using Core.Logger.Abstractions;
using Serilog;

namespace Core.Logger.Serilog
{
    public class LogSerilog
    {
        private LoggerConfiguration LoggerConfiguration { get; set; } = new LoggerConfiguration().AddDefaultSettings();

        #region Console

        public LogSerilog Console(bool enabled = true)
        {
            LoggerConfiguration.AddConsole(new SerilogConsoleSettings { Enabled = enabled });

            return this;
        }

        public LogSerilog Console(LoggerMinimumLevel loggerMinimumLevel, string outputTemplate, bool enabled = true)
        {
            LoggerConfiguration.AddConsole(new SerilogConsoleSettings 
            {
                Enabled = enabled,

                MinimumLevel = loggerMinimumLevel.ToString(),

                OutputTemplate = outputTemplate                 
            });

            return this;
        }

        #endregion Console

        #region File

        public LogSerilog File(bool enabled = true)
        {
            LoggerConfiguration.AddFile(new SerilogFileSettings
            {
                Enabled = enabled
            });

            return this;
        }

        public LogSerilog File(string filePath, LoggerMinimumLevel loggerMinimumLevel, LoggerInterval loggerInterval, bool enabled = true)
        {
            LoggerConfiguration.AddFile(new SerilogFileSettings
            {
                Enabled = enabled,

                FilePath = filePath,

                Interval = loggerInterval.ToString(),

                MinimumLevel = loggerMinimumLevel.ToString()
            });

            return this;
        }

        #endregion File

        #region Email

        public LogSerilog Email
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

            string outputTemplate = SerilogEmailSettings.DefaultOutputTemplate,

            bool enabled = true
        )
        {
            LoggerConfiguration.AddEmail(new SerilogEmailSettings
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
                Enabled = enabled 
            });

            return this;
        }

        #endregion Email

        public LoggerService CreateLogger<TSourceContext>()
        {
            return CreateLogger(typeof(TSourceContext).Name);
        }

        public LoggerService CreateLogger(string? sourceContext = null)
        {
            return new SerilogProvider(LoggerConfiguration).CreateLogger(sourceContext);
        }

        public void CloseLogger() => Log.CloseAndFlush();
    }
}
