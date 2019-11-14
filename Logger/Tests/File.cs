using Core.Logger;
using System;

namespace Logger.Test
{
    public class File
    {
        public static File Write { get; } = new File();

        static readonly dynamic User = new { Id = 1, Name = "Pepe" };

        public File Default(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.File()
                    .Info("InfoDefault_WithMessage")
                    .Info("InfoDefault_WithData", User)
                    .Info("InfoDefaul_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name)
                    .Error("ErrorDefault_WithMessage")
                    .Error("ErrorDefault_WithData", User)
                    .Error("ErrorDefault_WithException", new Exception("Fatal error App"))
                    .Error("ErrorDefault_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name); 
            }

            return this;
        }

        public File Custom(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.File
                (
                    x => x
                    .WithFilePath("Logs\\CUSTOM_.log")
                    .WithSourceContext("ContextCustom:")
                    .WithOutputTemplate("{SourceContext}{NewLine}{Timestamp:HH:mm:ss} [{Level}] {Message:lj} {Data}{NewLine}{Exception}")
                )
                .Info("InfoCustom_WithMessage")
                .Info("InfoCustom_WithData", User)
                .Info("InfoCustom_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name)
                .Error("ErrorCustom_WithMessage")
                .Error("ErrorCustom_WithData", User)
                .Error("ErrorCustom_WithException", new Exception("Fatal error App"))
                .Error("ErrorCustom_WithProperties", "Id: {Id} Name: {Name}", User.Id, User.Name); 
            }

            return this;
        }
    }
}
