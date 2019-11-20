using Core.Logger;
using Core.Logger.Abstractions;

namespace Logger.Tests.Serilog
{
    public class File : Shared
    {
        public static File Write = new File();

         public File Default(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog.File().CreateLogger("Test Serilog File Default");

                Execute(logger);
            }

            return this;
        }

        public File Custom(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog.File
                (
                    filePath: "Logs\\CUSTOM_.log",

                    loggerMinimumLevel: LoggerMinimumLevel.Debug,

                    loggerInterval: LoggerInterval.Hour
                )
                .CreateLogger("Test Serilog File Custom");

                Execute(logger);
            }

            return this;
        }
    }
}
