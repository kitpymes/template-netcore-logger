using Serilog;
using System;
using System.Threading;

namespace Core.Logger
{
    public class SerilogProvider: ISerilogProvider
    {
        protected static Serilog.Core.Logger _logger;

        protected SerilogProvider() { }

        public SerilogProvider(Serilog.Core.Logger logger)
        {
            _logger = logger;
        }

        #region Info

        public ISerilogProvider Info(string message)
        {
            _logger.Information(message);

            return this;
        }

        public ISerilogProvider Info(string message, object data)
        {
            _logger.WithData(data).Information(message);

            return this;
        }

        public ISerilogProvider Info(string eventName, string message, params object[] propertyValues)
        {
            var (eventMessage, eventProperties) = SerilogExtensions.WithEvent(eventName, message, propertyValues);

            _logger.Write(Serilog.Events.LogEventLevel.Information, eventMessage, eventProperties);

            return this;
        }

        #endregion Info

        #region Error

        public ISerilogProvider Error(string message)
        {
            _logger.Error(message);

            return this;
        }

        public ISerilogProvider Error(string message, object data)
        {
            _logger.WithData(data).Error(message);

            return this;
        }

        public ISerilogProvider Error(string eventName, string message, params object[] propertyValues)
        {
            var (eventMessage, eventProperties) = SerilogExtensions.WithEvent(eventName, message, propertyValues);

            _logger.Write(Serilog.Events.LogEventLevel.Error, eventMessage, eventProperties);

            return this;
        }

        public ISerilogProvider Error(string message, Exception exception)
        {
            _logger.Error(exception, message);

            return this;
        }

        public ISerilogProvider Error(Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return this;
        }

        public ISerilogProvider Error(Exception exception, object data)
        {
            _logger.WithData(data).Error(exception, exception.Message);

            return this;
        }

        #endregion Error

        #region Protected

        protected Serilog.Events.LogEventLevel GetMinimumLevel(LoggerMinimumLevel loggerMinimumLevel)
        {
            var logEventLevel = loggerMinimumLevel switch
            {
                LoggerMinimumLevel.Trace => Serilog.Events.LogEventLevel.Verbose,
                LoggerMinimumLevel.Debug => Serilog.Events.LogEventLevel.Debug,
                LoggerMinimumLevel.Info => Serilog.Events.LogEventLevel.Information,
                LoggerMinimumLevel.Error => Serilog.Events.LogEventLevel.Error,
                LoggerMinimumLevel.Fatal => Serilog.Events.LogEventLevel.Fatal,
                _ => Serilog.Events.LogEventLevel.Information,
            };

            return logEventLevel;
        }

        protected RollingInterval GetRollingInterval(LoggerInterval loggerInterval)
        {
            var rollingInterval = loggerInterval switch
            {
                LoggerInterval.Infinite => RollingInterval.Infinite,
                LoggerInterval.Year => RollingInterval.Year,
                LoggerInterval.Month => RollingInterval.Month,
                LoggerInterval.Hour => RollingInterval.Hour,
                LoggerInterval.Minute => RollingInterval.Minute,
                _ => RollingInterval.Day,
            };

            return rollingInterval;
        }

        #endregion Protected

        #region Disposable

        public static void Close()
        {
            var logger = Interlocked.Exchange(ref _logger, null);

            (logger as IDisposable)?.Dispose();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Close();
                }

                disposed = true;
            }
        }

        ~SerilogProvider() { Dispose(false); }

        #endregion
    }
}
