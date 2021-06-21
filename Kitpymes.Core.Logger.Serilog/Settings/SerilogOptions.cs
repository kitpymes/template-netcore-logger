// -----------------------------------------------------------------------
// <copyright file="SerilogOptions.cs" company="Kitpymes">
// Copyright (c) Kitpymes. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project docs folder for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Kitpymes.Core.Logger.Serilog
{
    using Kitpymes.Core.Logger.Abstractions;

    /*
       Clase de opciones SerilogOptions
       Contiene las opciones para configurar los proveedores de error de Serilog
    */

    /// <summary>
    /// Clase de opciones <c>SerilogOptions</c>.
    /// Contiene las opciones para configurar los proveedores de error de Serilog.
    /// </summary>
    /// <remarks>
    /// <para>En esta clase se pueden agregar todas las opciones de configuración para los proveedores de errores de Serilog.</para>
    /// </remarks>
    public class SerilogOptions
    {
        /// <summary>
        /// Obtiene la configuración de Serilog.
        /// </summary>
        public SerilogSettings SerilogSettings { get; private set; } = new SerilogSettings();

        /// <summary>
        /// Habilita el proveedor de consola para el logeo de errores.
        /// </summary>
        /// <param name="minimumLevel">Nivel mínimo de error habilidato por defecto.</param>
        /// <param name="outputTemplate">Plantilla de salida por defecto.</param>
        /// <returns>La clase SerilogOptions.</returns>
        public SerilogOptions AddConsole(
            LoggerLevel minimumLevel = SerilogConsoleSettings.DefaultMinimumLevel,
            string outputTemplate = SerilogConsoleSettings.DefaultOutputTemplate)
        {
            this.SerilogSettings.Console = new SerilogConsoleSettings
            {
                MinimumLevel = minimumLevel.ToString(),

                OutputTemplate = outputTemplate,

                Enabled = true,
            };

            return this;
        }

        /// <summary>
        /// Habilita el proveedor de archivos para el logeo de errores.
        /// </summary>
        /// <param name="filePath">Ruta donde se crearán los archivos.</param>
        /// <param name="minimumLevel">Nivel mínimo de error habilidato por defecto.</param>
        /// <param name="interval">Intervalo para la creaciñon de archivos.</param>
        /// <returns>La clase SerilogOptions.</returns>
        public SerilogOptions AddFile(
            string filePath = SerilogFileSettings.DefaultFilePath,
            LoggerLevel minimumLevel = SerilogFileSettings.DefaultMinimumLevel,
            LoggerFileInterval interval = SerilogFileSettings.DefaultLoggerInterval)
        {
            this.SerilogSettings.File = new SerilogFileSettings
            {
                FilePath = filePath,
                MinimumLevel = minimumLevel.ToString(),
                Interval = interval.ToString(),
                Enabled = true,
            };

            return this;
        }

        /// <summary>
        /// Habilita el proveedor de email para el logeo de errores.
        /// </summary>
        /// <param name="userName">Nombre del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="server">Servidor del proveedor de correo.</param>
        /// <param name="from">Email de quien envia el correo. </param>
        /// <param name="to">Email del destinatario.</param>
        /// <param name="enableSsl">Envio de email con Ssl.</param>
        /// <param name="port">Puerto del proveedor de envio de email.</param>
        /// <param name="subject">Asunto del email.</param>
        /// <param name="isBodyHtml">Si esta habilitado el cuerpo del correo con Html.</param>
        /// <param name="loggerMinimumLevel">El nivel mínimo de error.</param>
        /// <param name="outputTemplate">Plantilla de salida.</param>
        /// <returns>La clase SerilogOptions.</returns>
        public SerilogOptions AddEmail(
            string userName,
            string password,
            string server,
            string from,
            string to,
            bool enableSsl = SerilogEmailSettings.DefaultEnableSsl,
            int port = SerilogEmailSettings.DefaultPort,
            string subject = SerilogEmailSettings.DefaultSubject,
            bool isBodyHtml = SerilogEmailSettings.DefaultIsBodyHtml,
            LoggerLevel loggerMinimumLevel = SerilogEmailSettings.DefaultMinimumLevel,
            string outputTemplate = SerilogEmailSettings.DefaultOutputTemplate)
        {
            this.SerilogSettings.Email = new SerilogEmailSettings
            {
                UserName = userName,
                Password = password,
                Server = server,
                From = from,
                To = to,
                EnableSsl = enableSsl,
                Port = port,
                Subject = subject,
                IsBodyHtml = isBodyHtml,
                MinimumLevel = loggerMinimumLevel.ToString(),
                OutputTemplate = outputTemplate,
                Enabled = true,
            };

            return this;
        }

        /// <summary>
        /// Habilita el proveedor de SqlServer para el logeo de errores.
        /// </summary>
        /// <param name="connectionString">Conexión de la base de datos donde se guardaran los errores.</param>
        /// <param name="schemaName">Nombre del esquema de la tabla donde se guardaran los erroreso.</param>
        /// <param name="tableName">Nombre de la tabla donde se guardaran los errores.</param>
        /// <param name="autoCreateDb">Si se debe crear la DB.</param>
        /// <param name="loggerMinimumLevel">El nivel mínimo de error.</param>
        /// <returns>La clase SerilogOptions.</returns>
        public SerilogOptions AddSqlServer(
            string connectionString,
            string schemaName = SerilogSqlServerSettings.DefaultSchemaName,
            string tableName = SerilogSqlServerSettings.DefaultTableName,
            bool autoCreateDb = SerilogSqlServerSettings.DefaultAutoCreateDB,
            LoggerLevel loggerMinimumLevel = SerilogEmailSettings.DefaultMinimumLevel)
        {
            this.SerilogSettings.SqlServer = new SerilogSqlServerSettings
            {
                ConnectionString = connectionString,
                SchemaName = schemaName,
                TableName = tableName,
                MinimumLevel = loggerMinimumLevel.ToString(),
                AutoCreateDB = autoCreateDb,
                Enabled = true,
            };

            return this;
        }
    }
}
