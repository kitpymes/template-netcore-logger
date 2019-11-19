using Core.Logger;
using System;

namespace Logger.Test
{
    public class Email
    {
        static readonly dynamic User = new { Id = 1, Name = "Pepe Email" };

        public static void Write(bool enabled = true)
        {
            if (enabled)
            {
                var logger = Log.Serilog
                    .Email
                    (
                        userName: "",

                        password: "",

                        server: "smtp.gmail.com",

                        from: "",

                        to: ""
                    )
                    .CreateLogger();

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
