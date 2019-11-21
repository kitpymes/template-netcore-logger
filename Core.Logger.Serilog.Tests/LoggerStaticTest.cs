using Core.Logger.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core.Logger.Serilog.Tests
{
    [TestClass]
    public class LoggerStaticTest
    {
        private dynamic Data { get; } = new { Id = 1, Name = "Name" };

        private ILoggerService DefaultLogger => Log.Serilog.CreateLogger("Default Serilog Test");

        private ILoggerService CustomLogger => Log.Serilog
            .Console(options =>
            {
                options.MinimumLevel = LoggerMinimumLevel.Debug.ToString();
                options.OutputTemplate = "{SourceContext}{NewLine}[{Level}] - {Message}{NewLine}";
            })
            .File(options =>
            {
                options.FilePath = "Logs\\CUSTOM_.log";
                options.MinimumLevel = LoggerMinimumLevel.Debug.ToString();
                options.Interval = LoggerInterval.Hour.ToString();
            })
            .Email
            (
                userName: "admin@app.com",
                password: "password",
                server: "smtp.gmail.com",
                from: "admin@app.com",
                to: "error@app.com"
            )
            .CreateLogger("Custom Serilog Test");

        #region Info

        [TestMethod]
        public void DefaultInfoWithMessage()
        {
            DefaultLogger.Info(nameof(DefaultInfoWithMessage));
        }

        [TestMethod]
        public void DefaultInfoWithMessageWithData()
        {
            DefaultLogger.Info(nameof(DefaultInfoWithMessageWithData), Data);
        }

        [TestMethod]
        public void DefaultInfoWithMessageWithProperties()
        {
            DefaultLogger.Info(nameof(DefaultInfoWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        [TestMethod]
        public void DefaultInfoWithMultipleDataInline()
        {
            DefaultLogger
                .Info("One", new { Id = 1, Name = "Name1" })
                .Info("Two", new { Id = 2, Name = "Name2" })
                .Info("Three", new { Id = 3, Name = "Name3" });
        }

        [TestMethod]
        public void CustomInfoWithMessage()
        {
            CustomLogger.Info(nameof(CustomInfoWithMessage));
        }

        [TestMethod]
        public void CustomInfoWithMessageWithData()
        {
            CustomLogger.Info(nameof(CustomInfoWithMessageWithData), Data);
        }

        [TestMethod]
        public void CustomLoggerWithMessageWithProperties()
        {
            CustomLogger.Info(nameof(CustomLoggerWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        [TestMethod]
        public void CustomInfoWithMultipleDataInline()
        {
            CustomLogger
                .Info("One", new { Id = 1, Name = "Name1" })
                .Info("Two", new { Id = 2, Name = "Name2" })
                .Info("Three", new { Id = 3, Name = "Name3" });
        }

        #endregion Info

        #region Error

        [TestMethod]
        public void DefaultErrorWithMessage()
        {
            DefaultLogger.Error(nameof(DefaultErrorWithMessage));
        }

        [TestMethod]
        public void DefaultErrorWithMessageWithData()
        {
            DefaultLogger.Error(nameof(DefaultErrorWithMessageWithData), Data);
        }

        [TestMethod]
        public void DefaultErrorWithException()
        {
            DefaultLogger.Error(new ArgumentNullException(nameof(DefaultErrorWithException)));
        }

        [TestMethod]
        public void DefaultErrorWithMessageWithProperties()
        {
            DefaultLogger.Error(nameof(DefaultErrorWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        [TestMethod]
        public void CustomErrorWithMessage()
        {
            CustomLogger.Error(nameof(CustomErrorWithMessage));
        }

        [TestMethod]
        public void CustomErrorWithMessageWithData()
        {
            CustomLogger.Error(nameof(CustomErrorWithMessageWithData), Data);
        }

        [TestMethod]
        public void CustomErrorWithException()
        {
            CustomLogger.Error(new ArgumentNullException(nameof(CustomErrorWithException)));
        }

        [TestMethod]
        public void CustomErrorWithMessageWithProperties()
        {
            CustomLogger.Error(nameof(DefaultErrorWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        #endregion Error
    }
}
