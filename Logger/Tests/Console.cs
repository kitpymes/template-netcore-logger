using Core.Logger;
using System;

namespace Logger.Test
{
    public class Console
    {
        public static Console Write { get; } = new Console();

        static readonly dynamic User = new { Id = 1, Name = "Pepe" };

        public Console Default(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.Console()
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

        public Console Custom(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.Console
                (
                    x => x
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
