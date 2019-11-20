namespace Core.Logger.Serilog
{
    public class SerilogSettings
    {
        public SerilogConsoleSettings? Console { get; set; }

        public SerilogFileSettings? File { get; set; }

        public SerilogEmailSettings? Email { get; set; }
    }
}
