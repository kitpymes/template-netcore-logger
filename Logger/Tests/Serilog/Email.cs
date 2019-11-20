using Core.Logger;

namespace Logger.Tests.Serilog
{
    public class Email : Shared
    {
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
                    .CreateLogger("Test Serilog Email");

                Execute(logger);
            }
        }
    }
}
