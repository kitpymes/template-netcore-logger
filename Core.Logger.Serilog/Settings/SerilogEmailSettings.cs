using Core.Logger.Abstractions;

namespace Core.Logger.Serilog
{
    public class SerilogEmailSettings
    {
        public const string DefaultSubject = "Error Log";

        public const bool DefaultEnableSsl = true;

        public const int DefaultPort = 465;

        public const string DefaultOutputTemplate = "[{Timestamp:HH:mm:ss:ff} {Level:u}] {Message:lj} {Data}{NewLine}{Exception}{NewLine}";

        public const LoggerMinimumLevel DefaultMinimumLevel = LoggerMinimumLevel.Error;

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

            Enabled = enableSsl;

            Port = port;

            Subject = subject;

            MinimumLevel = loggerMinimumLevel.ToString();

            OutputTemplate = outputTemplate;
        }

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

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Server { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public bool? EnableSsl { get; set; }
        public int? Port { get; set; }
    }
}
