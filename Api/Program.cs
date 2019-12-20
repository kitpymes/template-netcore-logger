using Kitpymes.Core.Logger;
using Kitpymes.Core.Logger.Abstractions;
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
            var logger = Log.UseSerilog(serilog => 
            {
                serilog
                    .AddConsole
                    (
                        // Custom values
                    )
                    .AddFile
                    (
                        minimumLevel: LoggerLevel.Info
                    );
                    //.AddEmail
                    //(
                    //    userName: "admin@app.com",
                    //    password: "password",
                    //    server: "smtp.gmail.com",
                    //    from: "admin@app.com",
                    //    to: "error@app.com"
                    //);
            })
            .CreateLogger<Program>();

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
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // (OPTIONAL) Clear default logging
                .ConfigureLogging(providers => providers.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
