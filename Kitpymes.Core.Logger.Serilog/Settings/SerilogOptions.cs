using Kitpymes.Core.Logger.Abstractions;

namespace Kitpymes.Core.Logger.Serilog
{
    public class SerilogOptions
    {
        public SerilogSettings SerilogSettings { get; private set; } = new SerilogSettings();
        
        public SerilogOptions AddConsole
        (
            LoggerMinimumLevel minimumLevel = SerilogConsoleSettings.DefaultMinimumLevel,

            string outputTemplate = SerilogConsoleSettings.DefaultOutputTemplate
        )
        {
            SerilogSettings.Console = new SerilogConsoleSettings
            {
                MinimumLevel = minimumLevel.ToString(),

                OutputTemplate = outputTemplate,

                Enabled = true
            };

            return this;
        }

        public SerilogOptions AddFile
        (
            string filePath = SerilogFileSettings.DefaultFilePath,

            LoggerMinimumLevel minimumLevel = SerilogFileSettings.DefaultMinimumLevel,

            LoggerInterval interval = SerilogFileSettings.DefaultLoggerInterval
        )
        {
            SerilogSettings.File = new SerilogFileSettings
            {
                FilePath = filePath,

                MinimumLevel = minimumLevel.ToString(),

                Interval = interval.ToString(),

                Enabled = true
            };

            return this;
        }

        public SerilogOptions AddEmail
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
            if (string.IsNullOrWhiteSpace(userName))
                throw new System.ArgumentNullException(nameof(userName));

            if (string.IsNullOrWhiteSpace(password))
                throw new System.ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(server))
                throw new System.ArgumentNullException(nameof(server));

            if (string.IsNullOrWhiteSpace(from))
                throw new System.ArgumentNullException(nameof(from));

            if (string.IsNullOrWhiteSpace(to))
                throw new System.ArgumentNullException(nameof(to));

            SerilogSettings.Email = new SerilogEmailSettings
            {
                UserName = userName,

                Password = password,

                Server = server,

                From = from,

                To = to,

                EnableSsl = enableSsl,

                Port = port,

                Subject = subject,

                IsBodyHtml = isBodyHtml,

                MinimumLevel = loggerMinimumLevel.ToString(),

                OutputTemplate = outputTemplate,

                Enabled = true
            };

            return this;
        }
    }
}
