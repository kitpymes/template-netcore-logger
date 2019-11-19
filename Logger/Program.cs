using Core.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Log Serilog Console
                Test.Console.Write();

                // Log Serilog File
                Test.File.Write(false);

                // Simulate exception
             //   throw new System.Exception(null);

                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                // Log Serilog Email
                Test.Email.Write();

                throw;
            }
            finally
            {
                // Log Serilog dispose
                Log.Serilog.CloseLogger();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(providers => providers.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
