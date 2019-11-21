using Core.Logger;
using Core.Logger.Abstractions;
using System;

namespace Logger.Tests.Serilog
{
    public abstract class Shared
    {
        static readonly dynamic User = new { Id = 1, Name = "Albert" };

        protected static void Execute(LoggerService logger)
        {
            logger
                .Info("Message")
                .Info("User", User)
                .Info("New User", "Id: {Id} Name: {Name}", User.Id, User.Name)
                .Error("Message")
                .Error("Ocurrio un error con el usuario", User)
                .Error(new OutOfMemoryException("Fatal error App"))
                .Error("Ocurrio un error con el usuario", "Id: {Id} Name: {Name}", User.Id, User.Name);
        }
    }
}
