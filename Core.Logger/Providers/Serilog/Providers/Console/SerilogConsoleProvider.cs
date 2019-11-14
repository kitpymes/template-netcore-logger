using Serilog;

namespace Core.Logger
{
    public class SerilogConsoleProvider : SerilogProvider, ISerilogConsoleProvider
    {
        public SerilogConsoleProvider(SerilogConsoleSettings settings = null)
        {
            settings ??= new SerilogConsoleSettings();

            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithSourceContext(settings.SourceContext)
                .WriteTo.Console
                (
                    outputTemplate: settings.OutputTemplate,

                    restrictedToMinimumLevel: GetMinimumLevel(settings.LoggerMinimumLevel)
                )
                .CreateLogger();
        }
    }
}
