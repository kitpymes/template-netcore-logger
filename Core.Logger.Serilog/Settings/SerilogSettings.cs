namespace Core.Logger.Serilog
{
    public class SerilogSettings
    {
        public SerilogConsoleSettings Console { get; set; } = new SerilogConsoleSettings();

        public SerilogFileSettings File { get; set; } = new SerilogFileSettings();

        public SerilogEmailSettings Email { get; set; } = new SerilogEmailSettings();
    }
}
