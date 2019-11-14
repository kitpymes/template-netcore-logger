using Core.Logger;
using System;

namespace Logger.Test
{
    public class Email
    {
        public static Email Write { get; } = new Email();

        static readonly dynamic User = new { Id = 1, Name = "Pepe" };

        public Email Default(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.Email
                (
                    userName: "", 
                    
                    password: "", 
                    
                    server: "smtp.gmail.com", 
                    
                    from: "", 
                    
                    to: ""
                )
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

        public Email Custom(bool enabled = true)
        {
            if (enabled)
            {
                Log.Serilog.Email
                (
                    userName: "",

                    password: "",

                    server: "smtp.gmail.com",

                    from: "",

                    to: "",
                
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
