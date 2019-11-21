using Core.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = Log.Serilog.CreateLogger<Program>();

            try
            {
                logger.Info("Init Host...");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                throw ex;
            }
            finally
            {
                logger.CloseLogger();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // (OPTIONAL) Clear default logging
                // .ConfigureLogging(providers => providers.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
