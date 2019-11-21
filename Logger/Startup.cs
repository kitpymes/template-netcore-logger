using Core.Logger;
using Core.Logger.Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Logger
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

            // Option 1
            services.LoadLogger(Configuration);

            // Option 2
            services.LoadLogger(loggers =>
            {
                loggers.UseSerilog(new SerilogSettings
                {
                    // Custom values
                });
            });

            // Option 3
            services.LoadLogger(loggers =>
            {
                loggers.UseSerilog(options =>
                {
                    options.Console = new SerilogConsoleSettings
                    {
                        // Custom values
                    };

                    options.File = new SerilogFileSettings
                    {
                        // Custom values
                    };

                    options.Email = new SerilogEmailSettings()
                    {
                        // Custom values
                    };
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
