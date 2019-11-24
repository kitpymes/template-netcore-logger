using Kitpymes.Core.Logger.Serilog;

namespace Kitpymes.Core.Logger
{
    public class LoggerSettings
    {
        public SerilogSettings? Serilog { get; set; } = new SerilogSettings();
    }
}
