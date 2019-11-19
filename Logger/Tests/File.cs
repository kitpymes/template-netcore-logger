using Core.Logger;
using Core.Logger.Abstractions;
using System;

namespace Logger.Test
{
    public class File
    {
        static readonly dynamic User = new { Id = 1, Name = "Pepe File" };

        public static void Write(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog
                    .File() // Default
                    .File // Custom
                    (
                        filePath: "Logs\\CUSTOM_.log",

                        loggerMinimumLevel: LoggerMinimumLevel.Debug,

                        loggerInterval: LoggerInterval.Day
                    )
                    .CreateLogger("SOURCE CONTEXT FILE:");

                logger.Info("Info_WithMessage");
                logger.Info("Info_WithData", User);
                logger.Info("Info_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name);
                logger.Error("Error_WithMessage");
                logger.Error("Error_WithData", User);
                logger.Error("Error_WithException", new Exception("Fatal error App"));
                logger.Error("Error_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name);
            }
        }
    }
}
