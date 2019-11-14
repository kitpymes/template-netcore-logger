namespace Core.Logger
{
    public class SerilogFileSettings : ISerilogFileSettings
    {
        private const string DefaultFilePath = "Logs\\error_.log";

        private const string DefaultOutputTemplate = "[{Timestamp:HH:mm:ss:ff} {Level:u}] {Message:lj} {Data}{NewLine}{Exception}{NewLine}";

        private const LoggerMinimumLevel DefaultLoggerMinimumLevel = LoggerMinimumLevel.Error;

        private const LoggerInterval DefaultLoggerInterval = LoggerInterval.Day;


        public string FilePath { get; private set; }
        public LoggerInterval LoggerInterval { get; private set; }
        public string OutputTemplate { get; private set; }
        public LoggerMinimumLevel LoggerMinimumLevel { get; private set; }
        public string SourceContext { get; private set; }

        public SerilogFileSettings
        (
            string filePath = DefaultFilePath,

            LoggerInterval loggerInterval = DefaultLoggerInterval,

            LoggerMinimumLevel loggerMinimumLevel = DefaultLoggerMinimumLevel,

            string outputTemplate = DefaultOutputTemplate,

            string sourceContext = null
        )
        {
            this
                .WithFilePath(filePath)
                .WithLoggerInterval(loggerInterval)
                .WithMinimumLevel(loggerMinimumLevel)
                .WithOutputTemplate(outputTemplate)
                .WithSourceContext(sourceContext);
        }

        public ISerilogFileSettings WithMinimumLevel(LoggerMinimumLevel minimumLevel)
        {
            LoggerMinimumLevel = minimumLevel;

            return this;
        }

        public ISerilogFileSettings WithSourceContext(string sourceContext)
        {
            SourceContext = sourceContext;

            return this;
        }

        public ISerilogFileSettings WithSourceContext<T>()
        {
            return WithSourceContext(typeof(T).Name);
        }

        public ISerilogFileSettings WithOutputTemplate(string outputTemplate)
        {
            OutputTemplate = outputTemplate;

            return this;
        }

        public ISerilogFileSettings WithFilePath(string filePath)
        {
            FilePath = filePath;

            return this;
        }

        public ISerilogFileSettings WithLoggerInterval(LoggerInterval loggerInterval)
        {
            LoggerInterval = loggerInterval;

            return this;
        }
    }
}
