namespace Core.Logger.Abstractions
{
    public enum LoggerInterval
    {
        //
        // Resumen:
        //     The log file will never roll; no time period information will be appended to
        //     the log file name.
        Infinite = 0,
        //
        // Resumen:
        //     Roll every year. Filenames will have a four-digit year appended in the pattern
        //     yyyy
        //     .
        Year = 1,
        //
        // Resumen:
        //     Roll every calendar month. Filenames will have
        //     yyyyMM
        //     appended.
        Month = 2,
        //
        // Resumen:
        //     Roll every day. Filenames will have
        //     yyyyMMdd
        //     appended.
        Day = 3,
        //
        // Resumen:
        //     Roll every hour. Filenames will have
        //     yyyyMMddHH
        //     appended.
        Hour = 4,
        //
        // Resumen:
        //     Roll every minute. Filenames will have
        //     yyyyMMddHHmm
        //     appended.
        Minute = 5
    }
}
