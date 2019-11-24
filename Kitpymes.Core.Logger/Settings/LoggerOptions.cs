using Kitpymes.Core.Logger.Serilog;
using System;

namespace Kitpymes.Core.Logger
{
    public class LoggerOptions
    {
        #region Serilog

        public bool IsSerilogEnabled { get; private set; } = false;
        public Action<SerilogOptions> SerilogOptions { get; private set; } = x => { };
        public LoggerOptions UseSerilog(Action<SerilogOptions> options)
        {
            SerilogOptions = options;

            IsSerilogEnabled = true;

            return this;
        }

        #endregion Serilog
    }
}
