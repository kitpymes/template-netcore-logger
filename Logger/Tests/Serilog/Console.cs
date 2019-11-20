using Core.Logger;
using Core.Logger.Abstractions;
using System;

namespace Logger.Tests.Serilog
{
    public class Console : Shared
    {
        public static Console Write = new Console();

        public Console Default(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog.Console().CreateLogger("Test Serilog Console Default");

                Execute(logger);
            }

            return this;
        }

        public Console Custom(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog.Console 
                (
                    loggerMinimumLevel: LoggerMinimumLevel.Debug,

                    outputTemplate: "{SourceContext}{NewLine}[{Level}] - {Message}{NewLine}"
                )
                .CreateLogger("Test Serilog Console Custom");

                Execute(logger);
            }

            return this;
        }
    }
}
