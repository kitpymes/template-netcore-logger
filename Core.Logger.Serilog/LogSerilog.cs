using Core.Logger.Abstractions;
using System;

namespace Core.Logger.Serilog
{
    public class LogSerilog
    {
        private SerilogProvider? SerilogProvider { get; set; }
        private SerilogSettings SerilogSettings { get; set; } = new SerilogSettings();


        public LogSerilog Set(Action<SerilogSettings> settings)
        {
            SerilogSettings = settings.Configure();

            return this;
        }

        public LogSerilog Console(Action<SerilogConsoleSettings> settings)
        {
            SerilogSettings.Console = settings.Configure();

            return this;
        }

        public LogSerilog File(Action<SerilogFileSettings> settings)
        {
            SerilogSettings.File = settings.Configure();

            return this;
        }


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
            return Email(new SerilogEmailSettings
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

        public LogSerilog Email(SerilogEmailSettings settings)
        {
            SerilogSettings.Email = settings;

            return this;
        }

        #endregion Email

        public LoggerService CreateLogger<TSourceContext>()
        => CreateLogger(typeof(TSourceContext).Name);

        public LoggerService CreateLogger(string sourceContext)
        {
            SerilogProvider = new SerilogProvider(SerilogSettings);

            return SerilogProvider.CreateLogger(sourceContext); 
        } 

        public void CloseLogger()
        {
            SerilogProvider?.CloseLogger();
        }
    }
}
