using Kitpymes.Core.Logger.Abstractions;
using Kitpymes.Core.Logger.Serilog;
using System;

namespace Kitpymes.Core.Logger
{
    public class Log
    {
        public static ILoggerService UseSerilog(Action<SerilogOptions> options) 
        => UseSerilog(options.Configure().SerilogSettings);

        public static ILoggerService UseSerilog(SerilogSettings settings)
        => new SerilogProvider(settings);
    }
}
