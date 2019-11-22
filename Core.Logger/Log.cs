using Core.Logger.Abstractions;
using Core.Logger.Serilog;
using System;

namespace Core.Logger
{
    public class Log
    {
        public static ILoggerService UseSerilog(Action<SerilogOptions> options) 
        => new SerilogProvider(options.Configure().SerilogSettings);
    }
}
