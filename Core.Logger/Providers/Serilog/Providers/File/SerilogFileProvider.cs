using Serilog;

namespace Core.Logger
{
    public class SerilogFileProvider : SerilogProvider, ISerilogFileProvider
    {
        public SerilogFileProvider(SerilogFileSettings settings = null)
        {
            settings ??= new SerilogFileSettings();

            _logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .Enrich.WithSourceContext(settings.SourceContext)
               .Enrich.WithMachineName()
               .Enrich.WithProcess()
               .Enrich.WithThread()
               .WriteTo.File
               (
                   //formatter: new Serilog.Formatting.Compact.CompactJsonFormatter(),

                   path: settings.FilePath,

                   outputTemplate: settings.OutputTemplate,

                   restrictedToMinimumLevel: GetMinimumLevel(settings.LoggerMinimumLevel),

                   rollingInterval: GetRollingInterval(settings.LoggerInterval)
               )
               .CreateLogger();
        }
    }
}
