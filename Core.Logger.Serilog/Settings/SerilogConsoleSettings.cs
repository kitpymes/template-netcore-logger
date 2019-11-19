using Core.Logger.Abstractions;

namespace Core.Logger.Serilog
{
    public class SerilogConsoleSettings
    {
        public const string DefaultOutputTemplate = "[{Timestamp:HH:mm:ss:ff} {Level:u}] {Message:lj} {Data}{NewLine}{Exception}{NewLine}";

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
