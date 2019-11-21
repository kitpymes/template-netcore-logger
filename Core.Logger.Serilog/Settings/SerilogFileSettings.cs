using Core.Logger.Abstractions;

namespace Core.Logger.Serilog
{
    public class SerilogFileSettings
    {
        public const string DefaultFilePath = @"Logs\\.log";

        public const LoggerMinimumLevel DefaultMinimumLevel = LoggerMinimumLevel.Error;

        public const LoggerInterval DefaultLoggerInterval = LoggerInterval.Day;

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

        private string _filePath = DefaultFilePath;
        public string? FilePath
        {
            get => _filePath;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _filePath = value;
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

        private string _interval = DefaultLoggerInterval.ToString();
        public string? Interval
        {
            get => _interval;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _interval = value;
                }
            }
        }
    }
}
