using Kitpymes.Core.Logger;
using Kitpymes.Core.Logger.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Tests.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Test
           // var logger = Log.UseSerilog(serilog =>
           // {
           //     serilog
           //         .AddConsole
           //         (
                        
           //         )
           //         .AddFile
           //         (
           //             minimumLevel: LoggerLevel.Info,
           //             filePath: "Logs\\host\\.log"
           //         )
           //         //.AddSqlServer
           //         //(
           //         //    autoCreateDb: true,
           //         //    connectionString: "Server=PC-SFERRARI\\SQL2017DEV;Database=LoggerDB;Integrated Security=true;MultipleActiveResultSets=true;"
           //         //)
           //         .AddEmail
           //         (
           //             userName: "sferrari.net@gmail.com",
           //             password: "Eos14zara",
           //             server: "smtp.gmail.com",
           //             from: "admin@app.com",
           //             to: "sferrari.net@gmail.com"
           //         );
           // })
           //.CreateLogger<Program>();

            try
            {
                //logger.Info("Init Host...");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception)
            {
                //logger.Error(ex);

                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
