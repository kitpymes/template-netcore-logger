using System;

namespace Core.Logger
{
    public class LogSerilog
    {
        public ISerilogConsoleProvider Console(Action<SerilogConsoleSettings> settings = null)
        {
            var defaultSettings = new SerilogConsoleSettings();

            settings?.Invoke(defaultSettings);

            return new SerilogConsoleProvider(defaultSettings);
        }

        public ISerilogFileProvider File(Action<SerilogFileSettings> settings = null)
        {
            var defaultSettings = new SerilogFileSettings();

            settings?.Invoke(defaultSettings);

            return new SerilogFileProvider(defaultSettings);
        }

        public ISerilogEmailProvider Email
        (
             string userName,

             string password,

             string server,

             string from,

             string to,

            Action<SerilogEmailSettings> settings = null
        )
        {
            var defaultSettings = new SerilogEmailSettings(userName, password, server, from, to);

            settings?.Invoke(defaultSettings);

            return new SerilogEmailProvider(defaultSettings);
        }

        public void Close()
        {
            SerilogProvider.Close();
        }
    }
}
