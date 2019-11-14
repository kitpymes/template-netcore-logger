namespace Core.Logger
{
    public class SerilogConsoleSettings : ISerilogConsoleSettings
    {
        private const string DefaultOutputTemplate = "[{Timestamp:HH:mm:ss:ff} {Level:u3}] {Message:lj} {Data}{NewLine}{Exception}";

        private const LoggerMinimumLevel DefaultLoggerMinimumLevel = LoggerMinimumLevel.Info;

        public string OutputTemplate { get; private set; }
        public LoggerMinimumLevel LoggerMinimumLevel { get; private set; }
        public string SourceContext { get; private set; }

        public SerilogConsoleSettings
        (
            LoggerMinimumLevel loggerMinimumLevel = DefaultLoggerMinimumLevel,

            string outputTemplate = DefaultOutputTemplate,

            string sourceContext = null
        )
        {
            this
               .WithMinimumLevel(loggerMinimumLevel)
               .WithOutputTemplate(outputTemplate)
               .WithSourceContext(sourceContext);
        }

        public ISerilogConsoleSettings WithMinimumLevel(LoggerMinimumLevel minimumLevel)
        {
            LoggerMinimumLevel = minimumLevel;

            return this;
        }

        public ISerilogConsoleSettings WithSourceContext(string sourceContext)
        {
            SourceContext = sourceContext;

            return this;
        }

        public ISerilogConsoleSettings WithSourceContext<T>()
        {
            return WithSourceContext(typeof(T).Name);
        }

        public ISerilogConsoleSettings WithOutputTemplate(string outputTemplate)
        {
            OutputTemplate = outputTemplate;

            return this;
        }
    }
}
