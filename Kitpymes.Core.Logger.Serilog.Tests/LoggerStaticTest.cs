using Kitpymes.Core.Logger.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Kitpymes.Core.Logger.Serilog.Tests
{
    [TestClass]
    public class LoggerStaticTest
    {
        private dynamic Data { get; } = new { Id = 1, Name = "Name" };

        private ILogger Logger => Log.UseSerilog(serilog => 
        {
            serilog.AddConsole
            (
                minimumLevel: LoggerLevel.Debug,
                outputTemplate:"{SourceContext}{NewLine}[{Level}] - {Message}{NewLine}"
            )
            .AddFile
            (
                filePath: "Logs\\CUSTOM_.log",
                minimumLevel: LoggerLevel.Debug,
                interval: LoggerFileInterval.Hour
            )
            .AddEmail
            (
                userName: "admin@app.com",
                password: "password",
                server: "smtp.gmail.com",
                from: "admin@app.com",
                to: "error@app.com"
            )
            .AddSqlServer
            (
                connectionString: "Data Source=PC-SFERRARI\\SQL2017DEV;Initial Catalog=LoggerDB;Persist Security Info=True;User ID=sa;Password=sapopepe;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;TrustServerCertificate=False;",
                schemaName  : "dbo",
                tableName: "Log"
            );
        })
        .CreateLogger("Custom Serilog Test");

        #region Info

        [TestMethod]
        public void InfoWithMessage()
        {
            Logger.Info(nameof(InfoWithMessage));
        }

        [TestMethod]
        public void InfoWithMessageWithData()
        {
            Logger.Info(nameof(InfoWithMessageWithData), Data);
        }

        [TestMethod]
        public void InfoWithMessageWithProperties()
        {
            Logger.Info(nameof(InfoWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        [TestMethod]
        public void InfoWithMultipleDataInline()
        {
            Logger
                .Info(nameof(InfoWithMultipleDataInline) + " 1", new { Id = 1, Name = "Name1" })
                .Info(nameof(InfoWithMultipleDataInline) + " 2", new { Id = 2, Name = "Name2" })
                .Info(nameof(InfoWithMultipleDataInline) + " 3", new { Id = 3, Name = "Name3" });
        }

        #endregion Info

        #region Error

        [TestMethod]
        public void ErrorWithMessage()
        {
            Logger.Error(nameof(ErrorWithMessage));
        }

        [TestMethod]
        public void ErrorWithMessageWithData()
        {
            Logger.Error(nameof(ErrorWithMessageWithData), Data);
        }

        [TestMethod]
        public void ErrorWithException()
        {
            Logger.Error(new ArgumentNullException(nameof(ErrorWithException)));
        }

        [TestMethod]
        public void ErrorWithMessageWithProperties()
        {
            Logger.Error(nameof(ErrorWithMessageWithProperties), "Id: {Id} Name: {Name}", Data.Id, Data.Name);
        }

        #endregion Error
    }
}
