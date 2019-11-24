using Kitpymes.Core.Logger.Abstractions;

namespace Kitpymes.Core.Logger.Serilog
{
    public class SerilogConsoleSettings
    {
        public const string DefaultOutputTemplate = "{SourceContext}{NewLine}{Timestamp:HH:mm:ss:ff} [{Level:u3}] {Message:lj}{NewLine}";

        public const LoggerMinimumLevel DefaultMinimumLevel = LoggerMinimumLevel.Info;

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
