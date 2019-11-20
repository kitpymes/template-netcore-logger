using Core.Logger.Abstractions;
using Core.Logger.Serilog;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Logger
{
    public class LoggerOptions
    {
        #region Serilog

        public bool IsSerilogEnabled { get; private set; } = false;
        public SerilogSettings SerilogSettings { get; private set; } = new SerilogSettings();
        public LoggerOptions UseSerilog(Action<SerilogSettings> settings)
        {
            SerilogSettings = settings.ConfigureOrDefault();

            IsSerilogEnabled = true;

            return this;
        }

        public LoggerOptions UseSerilog(IConfiguration configuration)
        {
            var settings = configuration.GetSection("LoggerSettings:Serilog")?.Get<SerilogSettings>();

            if(settings != null)
            {
                SerilogSettings = settings;

                IsSerilogEnabled = true;
            }

            return this;
        }

        #endregion Serilog
    }
}
