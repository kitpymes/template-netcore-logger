using Core.Logger.Abstractions;

namespace Core.Logger.Serilog
{
    public class SerilogEmailSettings
    {
        public const string DefaultSubject = "Log Error";

        public const bool DefaultEnableSsl = true;

        public const bool DefaultIsBodyHtml = true;

        public const int DefaultPort = 465;

        public const string DefaultOutputTemplate = "{SourceContext} {MachineName} {Process} {Thread}{NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}";

        public const LoggerMinimumLevel DefaultMinimumLevel = LoggerMinimumLevel.Error;

        public SerilogEmailSettings() { }

        public SerilogEmailSettings
        (
            string userName,

            string password,

            string server,

            string from,

            string to,

            bool enableSsl = DefaultEnableSsl,

            int port = DefaultPort,

            string subject = DefaultSubject,

            bool isBodyHtml = DefaultIsBodyHtml,

            LoggerMinimumLevel loggerMinimumLevel = DefaultMinimumLevel,

            string outputTemplate = DefaultOutputTemplate
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

            UserName = userName;

            Password = password;

            Server = server;

            From = from;

            To = to;

            EnableSsl = enableSsl;

            Port = port;

            Subject = subject;

            IsBodyHtml = isBodyHtml;

            MinimumLevel = loggerMinimumLevel.ToString();

            OutputTemplate = outputTemplate;

            Enabled = true;
        }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Server { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }


        private bool _enabled = false;
        public bool? Enabled
        {
            get => _enabled;
            set
            {
                if (value.HasValue)
                {
                    _enabled = value.Value;
                }
            }
        }

        private bool _enableSsl = DefaultEnableSsl;
        public bool? EnableSsl
        {
            get => _enableSsl;
            set
            {
                if (value.HasValue)
                {
                    _enableSsl = value.Value;
                }
            }
        }


        private int _port = DefaultPort;
        public int? Port
        {
            get => _port;
            set
            {
                if (value.HasValue)
                {
                    _port = value.Value;
                }
            }
        }

        private bool _isBodyHtml = DefaultIsBodyHtml;
        public bool? IsBodyHtml
        {
            get => _isBodyHtml;
            set
            {
                if (value.HasValue)
                {
                    _isBodyHtml = value.Value;
                }
            }
        }

        private string _subject = DefaultSubject;
        public string? Subject
        {
            get => _subject;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _subject = value;
                }
            }
        }

        private string _minimumLevel = DefaultMinimumLevel.ToString();
        public string? MinimumLevel
        {
            get => _minimumLevel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _minimumLevel = value;
                }
            }
        }

        private string _outputTemplate = DefaultOutputTemplate;
        public string? OutputTemplate
        {
            get => _outputTemplate;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _outputTemplate = value;
                }
            }
        }
    }
}
