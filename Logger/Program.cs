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
                Tests.Serilog.Console.Write.Default().Custom();

                Tests.Serilog.File.Write.Default().Custom();

                // Simulate exception
                //throw new Exception(null);

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Tests.Serilog.Email.Write(false);

                throw ex;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // (OPTIONAL) Clear default logging
                // .ConfigureLogging(providers => providers.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
