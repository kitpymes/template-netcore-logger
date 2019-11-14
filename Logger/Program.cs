using Core.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Log Serilog Console
                Test.Console.Write.Default().Custom();

                // Log Serilog File
                Test.File.Write.Default().Custom();

                // Simulate exception
                throw new System.Exception(null);

                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                // Log Serilog Email
                Test.Email.Write.Default();

                Test.Email.Write.Custom();

                throw;
            }
            finally
            {
                // Log Serilog dispose
                Log.Serilog.Close();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
