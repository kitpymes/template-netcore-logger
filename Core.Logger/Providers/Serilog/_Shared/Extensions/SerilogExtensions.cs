using Serilog;
using System.Linq;
using System.Text;

namespace Core.Logger
{
    public static class SerilogExtensions
    {
        public static ILogger With(this ILogger logger, string propertyName, object value)
        {
            return logger.ForContext(propertyName, value, destructureObjects: true);
        }

        public static ILogger WithData(this ILogger logger, object data)
        {
            return logger.With("Data", data);
        }

        public static (string eventMessage, object[] eventProperties) WithEvent(string eventName, string message, params object[] propertyValues)
        {
            return ("{EventName:l} => " + message, new object[] { eventName }.Concat(propertyValues).ToArray());
        }
    }
}
