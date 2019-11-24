using Kitpymes.Core.Logger.Abstractions;

namespace Kitpymes.Core.Logger.Serilog
{
    public class SerilogEmailSettings
    {
        public const string DefaultSubject = "Log Error";

        public const bool DefaultEnableSsl = true;

        public const bool DefaultIsBodyHtml = false;

        public const int DefaultPort = 465;

        public const string DefaultOutputTemplate = "SourceContext: {SourceContext} | MachineName: {MachineName} | Process: {Process} | Thread: {Thread} => {NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u}] {Message:lj}{NewLine}";

        public const LoggerMinimumLevel DefaultMinimumLevel = LoggerMinimumLevel.Error;


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
