using Core.Logger.Serilog;

namespace Core.Logger
{
    public class Log
    {
        public static LogSerilog Serilog => new LogSerilog();
    }
}
