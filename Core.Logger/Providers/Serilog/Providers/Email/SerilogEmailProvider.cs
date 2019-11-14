using Serilog;
using System.Net;

namespace Core.Logger
{
    public class SerilogEmailProvider : SerilogProvider, ISerilogEmailProvider
    {
        public SerilogEmailProvider(SerilogEmailSettings settings)
        {
            _logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .Enrich.WithSourceContext(settings.SourceContext)
               .Enrich.WithMachineName()
               .Enrich.WithProcess()
               .Enrich.WithThread()
               .WriteTo.Email
               (
                    new Serilog.Sinks.Email.EmailConnectionInfo
                    {
                        NetworkCredentials = new NetworkCredential
                        {
                            UserName = settings.UserName,
                            Password = settings.Password
                        },

                        MailServer = settings.Server,

                        Port = settings.Port,

                        EnableSsl = settings.EnableSsl,

                        FromEmail = settings.From,
                       
                        ToEmail = settings.To,
                     
                        EmailSubject = settings.Subject
                    },

                    restrictedToMinimumLevel: GetMinimumLevel(settings.LoggerMinimumLevel)
               )
               .CreateLogger();
        }
    }
}
