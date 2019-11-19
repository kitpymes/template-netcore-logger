using Core.Logger;
using Core.Logger.Abstractions;
using Core.Logger.Serilog;
using System;

namespace Logger.Test
{
    public class Console
    {
        static readonly dynamic User = new { Id = 1, Name = "Pepe Console" };

        public static void Write(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog
                    .Console() // Default
                    .Console // Custom
                    (
                        loggerMinimumLevel: LoggerMinimumLevel.Debug,

                        outputTemplate: "{SourceContext}{NewLine}{Timestamp:HH:mm:ss} [{Level}] {Message:lj} {Data}{NewLine}{Exception}"
                    )
                    .CreateLogger("SOURCE CONTEXT CONSOLE:");

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
