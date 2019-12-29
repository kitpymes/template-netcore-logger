using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitpymes.Core.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Tests.Api.Nuget
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Test
            services.LoadLogger(loggers =>
            {
                loggers.UseSerilog(serilog =>
                {
                    serilog
                        .AddConsole
                        (

                        )
                        .AddFile
                        (
                            minimumLevel: Kitpymes.Core.Logger.Abstractions.LoggerLevel.Info
                        );
                        //.AddEmail
                        //(
                        //    userName: "admin@app.com",
                        //    password: "password",
                        //    server: "smtp.gmail.com",
                        //    from: "admin@app.com",
                        //    to: "error@app.com"
                        //);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
