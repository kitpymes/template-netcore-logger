using Core.Logger.Abstractions;
using Serilog;

namespace Core.Logger.Serilog
{
    public class LogSerilog
    {
        private LoggerConfiguration LoggerConfiguration { get; set; } = new LoggerConfiguration().AddDefaultSettings();

        #region Console

        public LogSerilog Console
        (
            LoggerMinimumLevel loggerMinimumLevel = SerilogConsoleSettings.DefaultMinimumLevel, 
            
            string outputTemplate = SerilogConsoleSettings.DefaultOutputTemplate
        )
        {
            LoggerConfiguration.AddConsole(new SerilogConsoleSettings 
            {
                Enabled = true,

                MinimumLevel = loggerMinimumLevel.ToString(),

                OutputTemplate = outputTemplate                 
            });

            return this;
        }

        #endregion Console

        #region File

        public LogSerilog File
        (
            string filePath = SerilogFileSettings.DefaultFilePath, 
            
            LoggerMinimumLevel loggerMinimumLevel = SerilogFileSettings.DefaultMinimumLevel, 
            
            LoggerInterval loggerInterval = SerilogFileSettings.DefaultLoggerInterval
        )
        {
            LoggerConfiguration.AddFile(new SerilogFileSettings
            {
                Enabled = true,

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

            bool isBodyHtml = SerilogEmailSettings.DefaultIsBodyHtml,

            LoggerMinimumLevel loggerMinimumLevel = SerilogEmailSettings.DefaultMinimumLevel,

            string outputTemplate = SerilogEmailSettings.DefaultOutputTemplate
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

                isBodyHtml,

                loggerMinimumLevel,

                outputTemplate
            )
            { 
                Enabled = true 
            });

            return this;
        }

        #endregion Email

        public LoggerService CreateLogger<TSourceContext>()
         => CreateLogger(typeof(TSourceContext).Name);

        public LoggerService CreateLogger(string sourceContext)
        => new SerilogProvider(LoggerConfiguration).CreateLogger(sourceContext);
    }
}
