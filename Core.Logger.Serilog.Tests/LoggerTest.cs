using Core.Logger.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core.Logger.Serilog.Tests
{
    [TestClass]
    public class LoggerTest
    {
        private readonly ILogger _loggerService;

        private dynamic Data { get; } = new { Id = 1, Name = "Name" };

        public LoggerTest()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var settings = configuration?.GetSection("LoggerSettings:Serilog")?.Get<SerilogSettings>();

            if(settings != null)
            {
                _loggerService = services.LoadSerilog(settings).CreateLogger(nameof(LoggerTest));
            }
        }

        #region Info

        [TestMethod]
        public void InfoWithMessage()
        {
            _loggerService.Info(nameof(InfoWithMessage));
        }

        [TestMethod]
        public void InfoWithMessageWithData()
        {
            _loggerService.Info(nameof(InfoWithMessageWithData), Data);
        }

        [TestMethod]
        public void InfoWithMessageWithProperties()
        {
            _loggerService.Info(nameof(InfoWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        [TestMethod]
        public void InfoWithMultipleDataInline()
        {
            _loggerService
                .Info("One", new { Id = 1, Name = "Name1" })
                .Info("Two", new { Id = 2, Name = "Name2" })
                .Info("Three", new { Id = 3, Name = "Name3" });
        }

        #endregion Info

        #region Error

        [TestMethod]
        public void ErrorWithMessage()
        {
            _loggerService.Error(nameof(ErrorWithMessage));
        }

        [TestMethod]
        public void ErrorWithMessageWithData()
        {
            _loggerService.Error(nameof(ErrorWithMessageWithData), Data);
        }

        [TestMethod]
        public void ErrorWithException()
        {
            _loggerService.Error(new ArgumentNullException(nameof(ErrorWithException)));
        }

        #endregion Error
    }
}
