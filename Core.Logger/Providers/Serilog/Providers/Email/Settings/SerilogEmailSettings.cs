namespace Core.Logger
{
    public class SerilogEmailSettings : ISerilogEmailSettings
    {
        private const string DefaultSubject = "Error Log";

        private const bool DefaultEnableSsl = true;

        private const int DefaultPort = 465;

        private const string DefaultOutputTemplate = "[{Timestamp:HH:mm:ss:ff} {Level:u}] {Message:lj} {Data}{NewLine}{Exception}{NewLine}";

        private const LoggerMinimumLevel DefaultLoggerMinimumLevel = LoggerMinimumLevel.Error;


        public string UserName { get; private set; }

        public string Password { get; private set; }

        public string Server { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public bool EnableSsl { get; private set; }

        public int Port { get; private set; }


        public string Subject { get; private set; }
        public string OutputTemplate { get; private set; }
        public LoggerMinimumLevel LoggerMinimumLevel { get; private set; }
        public string SourceContext { get; private set; }

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

            LoggerMinimumLevel loggerMinimumLevel = DefaultLoggerMinimumLevel,

            string outputTemplate = DefaultOutputTemplate,

            string sourceContext = null
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

            this
                .WithEnableSsl(enableSsl)
                .WithPort(port)
                .WithSubject(subject)
                .WithMinimumLevel(loggerMinimumLevel)
                .WithOutputTemplate(outputTemplate)
                .WithSourceContext(sourceContext);
        }

        public ISerilogEmailSettings WithMinimumLevel(LoggerMinimumLevel minimumLevel)
        {
            LoggerMinimumLevel = minimumLevel;

            return this;
        }

        public ISerilogEmailSettings WithSourceContext(string sourceContext)
        {
            SourceContext = sourceContext;

            return this;
        }

        public ISerilogEmailSettings WithSourceContext<T>()
        {
            return WithSourceContext(typeof(T).Name);
        }

        public ISerilogEmailSettings WithOutputTemplate(string outputTemplate)
        {
            OutputTemplate = outputTemplate;

            return this;
        }

        public ISerilogEmailSettings WithSubject(string subject)
        {
            Subject = subject;

            return this;
        }

        public ISerilogEmailSettings WithEnableSsl(bool enableSsl)
        {
            EnableSsl = enableSsl;

            return this;
        }

        public ISerilogEmailSettings WithPort(int port)
        {
            Port = port;

            return this;
        }
    }
}
