using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Tests.Serilog.Console.Write.Default(false).Custom(false);

                Tests.Serilog.File.Write.Default(false).Custom(false);

                Tests.Serilog.Email.Write(false);

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Tests.Serilog.Shared.CloseLogger();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(providers => providers.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
