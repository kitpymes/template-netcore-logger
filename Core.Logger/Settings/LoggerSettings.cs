using Core.Logger.Serilog;

namespace Core.Logger
{
    public class LoggerSettings
    {
        public SerilogSettings? Serilog { get; set; } = new SerilogSettings();
    }
}
